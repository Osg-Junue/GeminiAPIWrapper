using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeminiAPIWrapper.Configurations;

public sealed class Schema
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
