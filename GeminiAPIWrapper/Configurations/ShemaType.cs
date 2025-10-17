using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// JSON スキーマの基本型。
    /// 参考: https://cloud.google.com/vertex-ai/docs/reference/rest/v1/projects.locations.cachedContents?hl=ja#Schema
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<SchemaType>))]
    public enum SchemaType
    {
        /// <summary>
        /// 文字列。
        /// </summary>
        [JsonStringEnumMemberName("STRING")]
        String,

        /// <summary>
        /// 数値（浮動小数を含む）。
        /// </summary>
        [JsonStringEnumMemberName("NUMBER")]
        Number,

        /// <summary>
        /// 整数。
        /// </summary>
        [JsonStringEnumMemberName("INTEGER")]
        Integer,

        /// <summary>
        /// 真偽値。
        /// </summary>
        [JsonStringEnumMemberName("BOOLEAN")]
        Boolean,

        /// <summary>
        /// 配列。
        /// </summary>
        [JsonStringEnumMemberName("ARRAY")]
        Array,

        /// <summary>
        /// オブジェクト。
        /// </summary>
        [JsonStringEnumMemberName("OBJECT")]
        Object
    }
}
