using System.Text.Json;
using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 関数結果（tool → model）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/function-calling?hl=ja
    /// </summary>
    public sealed class FunctionResponse
    {
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        /// <summary>
        /// レスポンス（JSON オブジェクト）。
        /// </summary>
        [JsonPropertyName("response")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JsonElement? Response { get; init; }
    }
}
