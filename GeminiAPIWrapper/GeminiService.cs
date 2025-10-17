using GeminiAPIWrapper.Configurations;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace GeminiAPIWrapper;

/// <summary>
/// Gemini API との通信を管理するサービスクラス。
/// </summary>
public class GeminiService
{
    /// <summary>
    /// Gemini クライアント。
    /// </summary>
    private readonly IGeminiClient _client;

    /// <summary>
    /// コンストラクタ
    /// 
    /// GeminiServiceBuilder 経由での利用を想定しています。
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="ArgumentNullException"></exception>
    internal GeminiService(IGeminiClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    #region Public Methods

    /// <summary>
    /// Gemini API にリクエストを送信し、単一のレスポンスを取得します。
    /// </summary>
    /// <param name="userMessage">ユーザーからのメッセージ</param>
    /// <param name="systemInstruction">システム指示（オプション）</param>
    /// <param name="generationConfig">生成設定（オプション）</param>
    /// <param name="ct">キャンセレーショントークン</param>
    /// <returns>Gemini API からのレスポンス</returns>
    public async Task<GeminiResponse?> GenerateAsync(string userMessage, string systemInstruction = "", GenerationConfig? generationConfig = default, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(userMessage);

        var request = BuildRequest(userMessage, systemInstruction, generationConfig);
        return await _client.GenerateAsync(request, ct);
    }

    /// <summary>
    /// カスタム GeminiRequest を使用してレスポンスを取得します。
    /// </summary>
    /// <param name="request">Gemini リクエスト</param>
    /// <param name="ct">キャンセレーショントークン</param>
    /// <returns>Gemini API からのレスポンス</returns>
    public async Task<GeminiResponse?> GenerateAsync(GeminiRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        return await _client.GenerateAsync(request, ct);
    }

    /// <summary>
    /// Gemini API からストリーミングレスポンスを取得します。
    /// </summary>
    /// <param name="userMessage">ユーザーからのメッセージ</param>
    /// <param name="systemInstruction">システム指示（オプション）</param>
    /// <param name="generationConfig">生成設定（オプション）</param>
    /// <param name="ct">キャンセレーショントークン</param>
    /// <returns>Gemini API からのストリーミングレスポンス</returns>
    public async IAsyncEnumerable<GeminiResponse?> StreamGenerateAsync(string userMessage, string systemInstruction = "", GenerationConfig? generationConfig = default, [EnumeratorCancellation] CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(userMessage);

        var request = BuildRequest(userMessage, systemInstruction, generationConfig);
        await foreach (var response in _client.StreamGenerateAsync(request, ct))
        {
            yield return response;
        }
    }

    /// <summary>
    /// カスタム GeminiRequest を使用してストリーミングレスポンスを取得します。
    /// </summary>
    /// <param name="request">Gemini リクエスト</param>
    /// <param name="ct">キャンセレーショントークン</param>
    /// <returns>Gemini API からのストリーミングレスポンス</returns>
    public async IAsyncEnumerable<GeminiResponse?> StreamGenerateAsync(GeminiRequest request, [EnumeratorCancellation] CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        await foreach (var response in _client.StreamGenerateAsync(request, ct))
        {
            yield return response;
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// GeminiRequest を構築します。
    /// </summary>
    private static GeminiRequest BuildRequest(string userMessage, string systemInstruction, GenerationConfig? generationConfig)
    {
        var request = new GeminiRequest
        {
            Contents =
            [
                new Content
                {
                    Role = Role.User,
                    Parts = [new Part { Text = userMessage }]
                }
            ]
        };

        if (!string.IsNullOrEmpty(systemInstruction))
        {
            request.SystemInstruction = new SystemInstruction
            {
                Parts = [new Part { Text = systemInstruction }]
            };
        }

        if (generationConfig is not null)
        {
            request.GenerationConfig = generationConfig;
        }

        return request;
    }
    #endregion
}
