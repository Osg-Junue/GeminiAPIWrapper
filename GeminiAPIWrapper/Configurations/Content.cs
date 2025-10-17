using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// コンテンツブロック。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#contents
    /// </summary>
    public sealed class Content
    {
        /// <summary>
        /// 役割（ユーザー/モデル）。
        /// </summary>
        [JsonPropertyName("role")]
        public required Role Role { get; init; }

        /// <summary>
        /// パート一覧。
        /// </summary>
        [JsonPropertyName("parts")]
        public required List<Part> Parts { get; init; }
    }
}