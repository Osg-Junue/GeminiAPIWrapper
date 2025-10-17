using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 引用メタデータ。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public sealed class CitationMetadata
    {
        /// <summary>
        /// 引用リスト。
        /// </summary>
        [JsonPropertyName("citations")]
        public List<Citation> Citations { get; set; } = [];
    }
}