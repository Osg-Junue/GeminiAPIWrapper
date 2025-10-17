using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 引用。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    public sealed class Citation
    {
        /// <summary>
        /// 範囲開始インデックス（テキスト）。
        /// </summary>
        [JsonPropertyName("startIndex")]
        public int? StartIndex { get; set; }

        /// <summary>
        /// 範囲終了インデックス（テキスト）。
        /// </summary>
        [JsonPropertyName("endIndex")]
        public int? EndIndex { get; set; }

        /// <summary>
        /// 引用元URI。
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        /// <summary>
        /// ライセンス情報。
        /// </summary>
        [JsonPropertyName("license")]
        public string? License { get; set; }

        /// <summary>
        /// タイトル。
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// 発行日。
        /// </summary>
        [JsonPropertyName("publicationDate")]
        public PublicationDate? PublicationDate { get; set; }
    }
}