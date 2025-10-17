using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 出力スキーマ（構造化出力）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/multimodal/structured-output?hl=ja
    /// Schema 仕様: https://cloud.google.com/vertex-ai/docs/reference/rest/v1/projects.locations.cachedContents?hl=ja#Schema
    /// </summary>
    public class ResponseSchema
    {
        /// <summary>
        /// 【必須】型。
        /// </summary>
        [JsonPropertyName("type")]
        public SchemaType Type { get; set; }

        /// <summary>
        /// 【任意】説明。
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        /// <summary>
        /// 【任意】フォーマット（例: date-time, email）。
        /// </summary>
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Format { get; set; }

        /// <summary>
        /// 【任意】null 許容。
        /// </summary>
        [JsonPropertyName("nullable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Nullable { get; set; }

        /// <summary>
        /// 【任意】列挙値。
        /// </summary>
        [JsonPropertyName("enum")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Enum { get; set; }

        /// <summary>
        /// 【Object の場合】プロパティ定義。
        /// </summary>
        [JsonPropertyName("properties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, ResponseSchema>? Properties { get; set; }

        /// <summary>
        /// 【Object の場合】必須プロパティ名。
        /// </summary>
        [JsonPropertyName("required")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Required { get; set; }

        /// <summary>
        /// 【Array の場合】要素スキーマ。
        /// </summary>
        [JsonPropertyName("items")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseSchema? Items { get; set; }
    }
}
