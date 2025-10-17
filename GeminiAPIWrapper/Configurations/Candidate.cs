using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 応答候補。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public sealed class Candidate
    {
        /// <summary>
        /// 候補インデックス。
        /// </summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>
        /// 生成コンテンツ。
        /// </summary>
        [JsonPropertyName("content")]
        public Content? Content { get; set; }

        /// <summary>
        /// 生成停止理由。
        /// </summary>
        [JsonPropertyName("finishReason")]
        public FinishReason? FinishReason { get; set; }

        /// <summary>
        /// 安全性評価リスト。
        /// </summary>
        [JsonPropertyName("safetyRatings")]
        public List<SafetyRating> SafetyRatings { get; set; } = [];

        /// <summary>
        /// 使用トークン数（候補）。
        /// </summary>
        [JsonPropertyName("tokenCount")]
        public int? TokenCount { get; set; }

        /// <summary>
        /// 生成モデルのバージョン。
        /// </summary>
        [JsonPropertyName("modelVersion")]
        public string? ModelVersion { get; set; }

        /// <summary>
        /// 引用メタデータ。
        /// </summary>
        [JsonPropertyName("citationMetadata")]
        public CitationMetadata? CitationMetadata { get; set; }

        /// <summary>
        /// 平均ログ確率（logprobs）。
        /// </summary>
        [JsonPropertyName("avgLogprobs")]
        public double? AvgLogprobs { get; set; }

        /// <summary>
        /// ログ確率詳細（logprobs）。
        /// </summary>
        [JsonPropertyName("logprobsResult")]
        public LogprobsResult? LogprobsResult { get; set; }
    }
}