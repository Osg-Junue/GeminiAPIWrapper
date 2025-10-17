using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// トークン使用メタデータ。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public sealed class UsageMetadata
    {
        /// <summary>
        /// 入力トークン数。
        /// </summary>
        [JsonPropertyName("promptTokenCount")]
        public int PromptTokenCount { get; set; }

        /// <summary>
        /// 出力トークン数（候補合計）。
        /// </summary>
        [JsonPropertyName("candidatesTokenCount")]
        public int CandidatesTokenCount { get; set; }

        /// <summary>
        /// 総トークン数（入力+出力）。
        /// </summary>
        [JsonPropertyName("totalTokenCount")]
        public int TotalTokenCount { get; set; }
    }
}