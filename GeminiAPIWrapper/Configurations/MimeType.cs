using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// サポートされる MIME タイプ（主要例）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#blob
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MimeType>))]
    public enum MimeType
    {
        // Application
        /// <summary>PDFドキュメントのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("application/pdf")]
        Pdf,

        // Audio
        /// <summary>MPEGオーディオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("audio/mpeg")]
        AudioMpeg,

        /// <summary>MP3オーディオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("audio/mp3")]
        AudioMp3,

        /// <summary>WAVオーディオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("audio/wav")]
        AudioWav,

        // Image
        /// <summary>PNG画像のMIMEタイプ。</summary>
        [JsonStringEnumMemberName("image/png")]
        ImagePng,

        /// <summary>JPEG画像のMIMEタイプ。</summary>
        [JsonStringEnumMemberName("image/jpeg")]
        ImageJpeg,

        /// <summary>WebP画像のMIMEタイプ。</summary>
        [JsonStringEnumMemberName("image/webp")]
        ImageWebp,

        // Text
        /// <summary>プレーンテキストのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("text/plain")]
        TextPlain,

        // Video
        /// <summary>MOVビデオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("video/mov")]
        VideoMov,

        /// <summary>MPEGビデオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("video/mpeg")]
        VideoMpeg,

        /// <summary>MP4ビデオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("video/mp4")]
        VideoMp4,

        /// <summary>MPGビデオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("video/mpg")]
        VideoMpg,

        /// <summary>AVIビデオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("video/avi")]
        VideoAvi,

        /// <summary>WMVビデオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("video/wmv")]
        VideoWmv,

        /// <summary>MPEG Program StreamビデオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("video/mpegps")]
        VideoMpegPs,

        /// <summary>FLVビデオのMIMEタイプ。</summary>
        [JsonStringEnumMemberName("video/flv")]
        VideoFlv,
    }
}
