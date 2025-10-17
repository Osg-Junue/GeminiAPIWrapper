using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// トークン候補群（位置ごと）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public sealed class TokenCandidates
    {
        /// <summary>
        /// 特定のトークン位置における、モデルが考慮した候補トークンとその対数確率のリストを取得または設定します。
        /// </summary>
        [JsonPropertyName("candidates")]
        public List<TokenLogProbability> Candidates { get; set; } = [];
    }
}