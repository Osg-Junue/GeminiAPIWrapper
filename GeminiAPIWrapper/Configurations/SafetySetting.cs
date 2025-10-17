using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 安全性設定。各カテゴリのブロックしきい値と評価方法。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#safety
    /// </summary>
    public sealed class SafetySetting
    {
        /// <summary>
        /// 安全性カテゴリ（例: HARM_CATEGORY_HARASSMENT）。
        /// 参考: Inference → HarmCategory
        /// </summary>
        [JsonPropertyName("category")]
        public HarmCategory Category { get; set; }

        /// <summary>
        /// ブロックしきい値レベル。
        /// 値: BLOCK_NONE / BLOCK_LOW_AND_ABOVE / BLOCK_MEDIUM_AND_ABOVE / BLOCK_ONLY_HIGH / OFF / UNSPECIFIED。
        /// 参考: Inference → HarmBlockThreshold
        /// </summary>
        [JsonPropertyName("threshold")]
        public HarmBlockThreshold Threshold { get; set; }

        /// <summary>
        /// しきい値適用方法。確率（PROBABILITY）または重大度（SEVERITY）。
        /// 参考: Inference → HarmBlockMethod
        /// </summary>
        [JsonPropertyName("method")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public HarmBlockMethod? Method { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter<HarmBlockThreshold>))]
    public enum HarmBlockThreshold
    {
        [JsonStringEnumMemberName("HARM_BLOCK_THRESHOLD_UNSPECIFIED")]
        Unspecified,
        [JsonStringEnumMemberName("BLOCK_NONE")]
        BlockNone,
        [JsonStringEnumMemberName("BLOCK_LOW_AND_ABOVE")]
        BlockLowAndAbove,
        [JsonStringEnumMemberName("BLOCK_MEDIUM_AND_ABOVE")]
        BlockMediumAndAbove,
        [JsonStringEnumMemberName("BLOCK_ONLY_HIGH")]
        BlockOnlyHigh,
        [JsonStringEnumMemberName("OFF")]
        Off
    }

    [JsonConverter(typeof(JsonStringEnumConverter<HarmBlockMethod>))]
    public enum HarmBlockMethod
    {
        [JsonStringEnumMemberName("HARM_BLOCK_METHOD_UNSPECIFIED")]
        Unspecified,
        [JsonStringEnumMemberName("SEVERITY")]
        Severity,
        [JsonStringEnumMemberName("PROBABILITY")]
        Probability
    }
}
