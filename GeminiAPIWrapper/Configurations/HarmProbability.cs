using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 有害性の確率レベル。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<HarmProbability>))]
    public enum HarmProbability
    {
        /// <summary>
        /// 未指定。
        /// </summary>
        [JsonStringEnumMemberName("HARM_PROBABILITY_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// ごくわずか。
        /// </summary>
        [JsonStringEnumMemberName("NEGLIGIBLE")]
        Negligible,

        /// <summary>
        /// 低い。
        /// </summary>
        [JsonStringEnumMemberName("LOW")]
        Low,

        /// <summary>
        /// 中程度。
        /// </summary>
        [JsonStringEnumMemberName("MEDIUM")]
        Medium,

        /// <summary>
        /// 高い。
        /// </summary>
        [JsonStringEnumMemberName("HIGH")]
        High
    }
}