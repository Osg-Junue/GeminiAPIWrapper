using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// コンテンツの一部（パート）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#parts
    /// </summary>
    public sealed class Part
    {
        /// <summary>
        /// テキスト。
        /// </summary>
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Text { get; set; }

        /// <summary>
        /// インラインデータ（Base64等）。
        /// </summary>
        [JsonPropertyName("inlineData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public InlineData? InlineData { get; set; }

        /// <summary>
        /// ファイルデータ（URI参照）。
        /// </summary>
        [JsonPropertyName("fileData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FileData? FileData { get; set; }

        /// <summary>
        /// 関数呼び出し（model → tool）。
        /// </summary>
        [JsonPropertyName("functionCall")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FunctionCall? FunctionCall { get; set; }

        /// <summary>
        /// 関数結果（tool → model）。
        /// </summary>
        [JsonPropertyName("functionResponse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FunctionResponse? FunctionResponse { get; set; }

        /// <summary>
        /// 動画メタデータ。
        /// </summary>
        [JsonPropertyName("videoMetadata")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VideoMetadata? VideoMetadata { get; set; }
    }
}