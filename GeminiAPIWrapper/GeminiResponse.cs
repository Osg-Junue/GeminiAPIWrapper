using GeminiAPIWrapper.Configurations;
using System.Text.Json.Serialization;

namespace GeminiAPIWrapper
{
    /// <summary>
    /// 生成応答。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public class GeminiResponse
    {
        /// <summary>
        /// 応答候補の一覧。単一リクエストでも複数候補が返る場合あり。
        /// 参考: 上記 Inference（Response body: candidates）
        /// </summary>
        [JsonPropertyName("candidates")]
        public List<Candidate> Candidates { get; set; } = [];

        /// <summary>
        /// トークン消費メタデータ。
        /// 参考: 上記 Inference（Response body: usageMetadata）
        /// </summary>
        [JsonPropertyName("usageMetadata")]
        public UsageMetadata? UsageMetadata { get; set; }

        /// <summary>
        /// 生成に使用されたモデルとバージョン（例: gemini-2.0-flash-lite-001）。
        /// 参考: 上記 Inference（Response body: modelVersion）
        /// </summary>
        [JsonPropertyName("modelVersion")]
        public string? ModelVersion { get; set; }
    }
}