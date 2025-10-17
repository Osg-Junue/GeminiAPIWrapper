using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// ツール/関数呼び出しの挙動設定。
    /// </summary>
    public sealed class ToolConfig
    {
        [JsonPropertyName("functionCallingConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FunctionCallingConfig? FunctionCallingConfig { get; init; }
    }
}
