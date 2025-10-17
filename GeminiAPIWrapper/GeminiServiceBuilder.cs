using GeminiAPIWrapper.Options;

namespace GeminiAPIWrapper;

/// <summary>
/// Gemini API クライアント（<see cref="GeminiService"/>）を生成するためのビルダー/ファクトリ。
/// 利用する基盤にあわせて、Google AI Studio（Generative Language）または Vertex AI の
/// オプションを受け取り、共通のサービスを返します。
/// </summary>
public static class GeminiServiceBuilder
{
    /// <summary>
    /// Google AI Studio（Generative Language API）向け設定から <see cref="GeminiService"/> を構築します。
    /// </summary>
    /// <param name="options">エンドポイントや API キーなどの接続設定。</param>
    /// <returns>Gemini API との通信を行う <see cref="GeminiService"/>。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="options"/> が <c>null</c> の場合。</exception>
    public static GeminiService Build(GenerativeLanguageOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        var client = new GeminiClient(options);
        return new GeminiService(client);
    }
}
