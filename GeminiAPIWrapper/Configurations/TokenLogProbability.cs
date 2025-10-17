using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// トークンとその対数確率。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public class TokenLogProbability
    {
        /// <summary>
        /// トークン文字列。
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";

        /// <summary>
        /// 対数確率。
        /// </summary>
        [JsonPropertyName("logProbability")]
        public float LogProbability { get; set; }
    }
}