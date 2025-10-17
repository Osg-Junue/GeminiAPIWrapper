using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using GeminiAPIWrapper.ApiException;
using GeminiAPIWrapper.Attributes;
using GeminiAPIWrapper.Options;

namespace GeminiAPIWrapper;

/// <summary>
/// Gemini/Vertex AI の生成 API を呼び出すための HTTP クライアント実装。
/// <para>
/// - <see cref="IGeminiClient"/> を実装し、同期レスポンスとストリームレスポンスの両方を扱います。
/// - コンストラクタで渡されたオプションに基づきヘッダー（API キー/認可トークン）とベース URL を構成します。
/// - エンドポイントの末尾パスは <see cref="GenerateOptionAttribute"/> によりメソッド単位で切り替えます。
/// </para>
/// <remarks>
/// 本クラスは <see cref="HttpClient"/> を内部に保持します。インスタンスのライフサイクルは DI コンテナ等で調整し、不要になったら <see cref="Dispose"/> で破棄してください。
/// </remarks>
/// </summary>
internal class GeminiClient : IGeminiClient, IDisposable
{
    #region Fields
    /// <summary>
    /// 実際の HTTP 通信を担うクライアント。
    /// </summary>
    private readonly HttpClient _httpClient;
    /// <summary>
    /// API ベース URL（例: https://.../models/{model}:）。末尾に操作名（generateContent 等）を結合します。
    /// </summary>
    private readonly string _endpointBase;
    /// <summary>
    /// 送信コンテンツの MIME タイプ（例: application/json）。
    /// </summary>
    private readonly string _contentType;

    /// <summary>
    /// メソッド名 → 生成 API 操作名（<see cref="GenerateOptionAttribute"/>）の対応表。
    /// </summary>
    private static readonly Dictionary<string, string> _generateOptions = new()
    {
        [nameof(GenerateAsync)] = GetGenerateOption(nameof(GenerateAsync)),
        [nameof(StreamGenerateAsync)] = GetGenerateOption(nameof(StreamGenerateAsync))
    };
    #endregion

    #region Constructors
    /// <summary>
    /// Generative Language (API キー方式) 用コンストラクタ。
    /// </summary>
    /// <param name="options">エンドポイント、API キー、ヘッダー名、Content-Type を含むオプション。</param>
    /// <exception cref="ArgumentNullException">必須オプションが <c>null</c> の場合。</exception>
    public GeminiClient(GenerativeLanguageOptions options)
    {
        _endpointBase = options.EndpointBase ?? throw new ArgumentNullException(options.EndpointBase);
        _contentType = options.ContentType ?? throw new ArgumentNullException(options.ContentType);

        var keyHeader = options.KeyHeader ?? throw new ArgumentNullException(options.KeyHeader);
        var apiKey = options.ApiKey ?? throw new ArgumentNullException(options.ApiKey);

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_endpointBase),
            DefaultRequestHeaders = { { keyHeader, apiKey } },
        };
    }

    /// <summary>
    /// Vertex AI (トークン認可方式) 用コンストラクタ。
    /// </summary>
    /// <param name="options">エンドポイント、認可トークン、ヘッダー名、Content-Type を含むオプション。</param>
    /// <exception cref="ArgumentNullException">必須オプションが <c>null</c> の場合。</exception>
    public GeminiClient(VertexAIOptions options)
    {
        _endpointBase = options.EndpointBase ?? throw new ArgumentNullException(options.EndpointBase);
        _contentType = options.ContentType ?? throw new ArgumentNullException(options.ContentType);

        var authHeader = options.AuthHeader ?? throw new ArgumentNullException(options.AuthHeader);
        var authToken = options.AuthToken ?? throw new ArgumentNullException(options.AuthToken);

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_endpointBase),
            DefaultRequestHeaders = { { authHeader, authToken } },
        };
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// 非ストリーミングの生成 API を呼び出し、単一レスポンスを取得します。
    /// </summary>
    /// <param name="request">生成リクエスト。</param>
    /// <param name="cancellationToken">キャンセル トークン。</param>
    /// <returns>生成結果。失敗時は <c>null</c> ではなく例外を送出します。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/> が <c>null</c>。</exception>
    /// <exception cref="GeminiApiException">HTTP エラーまたは JSON デシリアライズ失敗。</exception>
    public async Task<GeminiResponse?> GenerateAsync(GeminiRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        // メソッド名に紐づく操作名（generateContent）を解決し、POST リクエストを構築
        using var httpRequest = BuildRequestMessage(nameof(GenerateAsync), request);

        // レスポンスコンテンツ受信後に制御を返す
        var completionOption = HttpCompletionOption.ResponseContentRead;

        using var responseMessage = await _httpClient.SendAsync(httpRequest, completionOption, cancellationToken).ConfigureAwait(false);

        if (!responseMessage.IsSuccessStatusCode)
        {
            var errorContent = await responseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            throw new GeminiApiException("API request failed", responseMessage.StatusCode, errorContent);
        }

        using var stream = await responseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync(stream, GeminiResponseJsonContext.Default.GeminiResponse, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// ストリーミングの生成 API を呼び出し、<see cref="IAsyncEnumerable{T}"/> 経由で順次メッセージを列挙します。
    /// </summary>
    /// <param name="request">生成リクエスト。</param>
    /// <param name="cancellationToken">キャンセル トークン（列挙中のキャンセルに対応）。</param>
    /// <returns>到着順に <see cref="GeminiResponse"/> を返す非同期列挙。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/> が <c>null</c>。</exception>
    /// <exception cref="GeminiApiException">HTTP エラーまたは JSON デシリアライズ失敗。</exception>
    /// <remarks>
    /// 呼び出し側は <c>await foreach</c> で列挙することで、サーバーから届くチャンクを逐次処理できます。
    /// 列挙を中断したい場合は <paramref name="cancellationToken"/> をキャンセルしてください。
    /// </remarks>
    public async IAsyncEnumerable<GeminiResponse?> StreamGenerateAsync(GeminiRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        // メソッド名に紐づく操作名（streamGenerateContent）を解決し、POST リクエストを構築
        using var httpRequest = BuildRequestMessage(nameof(StreamGenerateAsync), request);

        // ヘッダー受信後に制御を返す
        var completionOption = HttpCompletionOption.ResponseHeadersRead;

        using var responseMessage = await _httpClient.SendAsync(httpRequest, completionOption, cancellationToken).ConfigureAwait(false);

        if (!responseMessage.IsSuccessStatusCode)
        {
            var errorContent = await responseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            throw new GeminiApiException("API request failed", responseMessage.StatusCode, errorContent);
        }

        await using var stream = await responseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        var jsonOptions = new JsonSerializerOptions
        {
            TypeInfoResolver = GeminiResponseJsonContext.Default
        };

        // System.Text.Json の DeserializeAsyncEnumerable でチャンクを順次デシリアライズ
        await foreach (var geminiResponse in JsonSerializer.DeserializeAsyncEnumerable<GeminiResponse>(stream, jsonOptions, cancellationToken).ConfigureAwait(false))
        {
            yield return geminiResponse;
        }
    }

    /// <summary>
    /// 内部の <see cref="HttpClient"/> を破棄します。
    /// </summary>
    public void Dispose()
    {
        _httpClient?.Dispose();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// インターフェイス上のメソッドに付与された <see cref="GenerateOptionAttribute"/> から操作名を取得します。
    /// </summary>
    /// <param name="methodName">対象メソッド名。</param>
    /// <returns>操作名（例: <c>generateContent</c>）。</returns>
    /// <exception cref="InvalidOperationException">メソッドや属性が見つからない場合。</exception>
    private static string GetGenerateOption(string methodName)
    {
        var method = typeof(IGeminiClient).GetMethod(methodName) ?? throw new InvalidOperationException($"Method '{methodName}' not found on IGeminiClient interface.");
        var attribute = method.GetCustomAttribute<GenerateOptionAttribute>() ?? throw new InvalidOperationException($"GenerateOption attribute not found on method '{methodName}'.");
        return attribute.Option;
    }

    /// <summary>
    /// ベース URL と操作名から最終的なエンドポイント URL を組み立てます。
    /// </summary>
    /// <param name="methodName">呼び出しメソッド名。</param>
    /// <returns>完全なエンドポイント URL。</returns>
    private string BuildFullEndpoint(string methodName) => $"{_endpointBase}:{_generateOptions[methodName]}";

    /// <summary>
    /// JSON 本文を持つ POST リクエストを構築します。
    /// </summary>
    /// <param name="methodName">呼び出しメソッド名（操作名解決に使用）。</param>
    /// <param name="request">送信するリクエスト ボディ。</param>
    /// <returns>構築済みの <see cref="HttpRequestMessage"/>。</returns>
    private HttpRequestMessage BuildRequestMessage(string methodName, GeminiRequest request)
    {
        // ソース生成コンテキストを利用して高速/安全にシリアライズ
        var content = JsonSerializer.Serialize(request, GeminiRequestJsonContext.Default.GeminiRequest);
        return new HttpRequestMessage(HttpMethod.Post, BuildFullEndpoint(methodName))
        {
            Content = new StringContent(content, Encoding.UTF8)
            {
                Headers = { ContentType = new MediaTypeHeaderValue(_contentType) }
            }
        };
    }
    #endregion
}
