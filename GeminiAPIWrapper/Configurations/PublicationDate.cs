using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 発行日。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public sealed class PublicationDate
    {
        /// <summary>
        /// 年。
        /// </summary>
        [JsonPropertyName("year")]
        public int? Year { get; set; }

        /// <summary>
        /// 月。
        /// </summary>
        [JsonPropertyName("month")]
        public int? Month { get; set; }

        /// <summary>
        /// 日。
        /// </summary>
        [JsonPropertyName("day")]
        public int? Day { get; set; }
    }
}