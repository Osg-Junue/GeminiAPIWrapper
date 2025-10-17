using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// インラインデータ（base64エンコードした元バイト）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#blob
    /// </summary>
    public sealed class InlineData
    {
        /// <summary>
        /// MIME タイプ。IANA MIME タイプ。
        /// 参考: 同ページ mimeType
        /// </summary>
        [JsonPropertyName("mimeType")]
        public MimeType MimeType { get; set; }

        /// <summary>
        /// base64 エンコードデータ。
        /// 上限サイズ: 20MB（モデル・形式により制約あり）。
        /// 参考: 同ページ data（blob）
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; } = "";
    }
}
