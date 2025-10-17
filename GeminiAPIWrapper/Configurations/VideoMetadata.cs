using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 動画メタデータ（開始/終了オフセット、fps）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#video
    /// </summary>
    public sealed class VideoMetadata
    {
        [JsonPropertyName("startOffset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VideoOffset? StartOffset { get; init; }

        [JsonPropertyName("endOffset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VideoOffset? EndOffset { get; init; }

        [JsonPropertyName("fps")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Fps { get; init; }
    }

    public sealed class VideoOffset
    {
        [JsonPropertyName("seconds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Seconds { get; init; }

        [JsonPropertyName("nanos")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Nanos { get; init; }
    }

}
