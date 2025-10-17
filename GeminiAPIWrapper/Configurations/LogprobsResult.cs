using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// トークンごとのログ確率詳細。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public sealed class LogprobsResult
    {
        /// <summary>
        /// 各トークン位置の上位候補トークンとその対数確率のリスト。
        /// </summary>
        [JsonPropertyName("topCandidates")]
        public List<TokenCandidates> TopCandidates { get; set; } = [];

        /// <summary>
        /// 実際に選択されたトークンと、そのときの対数確率のリスト。
        /// </summary>
        [JsonPropertyName("chosenCandidates")]
        public List<TokenLogProbability> ChosenCandidates { get; set; } = [];
    }
}