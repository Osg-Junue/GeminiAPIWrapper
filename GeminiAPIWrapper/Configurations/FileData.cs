using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// FileData（URI/URL の参照）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#filedata
    /// </summary>
    public sealed class FileData
    {
        /// <summary>
        /// IANA MIME タイプ。
        /// 参考: 同ページ mimeType
        /// </summary>
        [JsonPropertyName("mimeType")]
        public MimeType MimeType { get; set; }

        /// <summary>
        /// ファイルの URI または URL。
        /// 例: GCS: gs://bucket/obj（公開または同一プロジェクト）、HTTP: 公開URL。
        /// モデル依存で上限（例: gemini-2.0-flash系は〜2GB）。
        /// 参考: 同ページ fileUri
        /// </summary>
        [JsonPropertyName("fileUri")]
        public string FileUri { get; set; } = "";
    }
}
