using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// システム指示（対応モデルのみ、role は無視）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#systeminstruction
    /// </summary>
    public class SystemInstruction
    {
        /// <summary>
        /// 指示のパーツ（通常はテキスト）。
        /// </summary>
        [JsonPropertyName("parts")]
        public required List<Part> Parts { get; init; }
    }
}