using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 安全性評価。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public sealed class SafetyRating
    {
        /// <summary>
        /// カテゴリ。
        /// </summary>
        [JsonPropertyName("category")]
        public HarmCategory Category { get; set; }

        /// <summary>
        /// 確率評価。
        /// </summary>
        [JsonPropertyName("probability")]
        public HarmProbability Probability { get; set; }

        /// <summary>
        /// このカテゴリが原因でブロックされたか。
        /// </summary>
        [JsonPropertyName("blocked")]
        public bool? Blocked { get; set; }
    }
}