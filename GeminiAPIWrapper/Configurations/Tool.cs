using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// ツール群（関数宣言）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/multimodal/function-calling?hl=ja
    /// </summary>
    public sealed class Tool
    {
        /// <summary>
        /// 関数宣言一覧。
        /// </summary>
        [JsonPropertyName("functionDeclarations")]
        public List<FunctionDeclaration> FunctionDeclarations { get; init; } = [];
    }
}
