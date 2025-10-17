using System.Text.Json;
using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 関数呼び出し（model → tool）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/function-calling?hl=ja
    /// </summary>
    public sealed class FunctionCall
    {
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        /// <summary>
        /// 引数（JSON オブジェクト）。
        /// </summary>
        [JsonPropertyName("args")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JsonElement? Args { get; init; }
    }
}
