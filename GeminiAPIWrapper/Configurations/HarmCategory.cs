using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 有害性カテゴリ。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<HarmCategory>))]
    public enum HarmCategory
    {
        /// <summary>
        /// ハラスメント（嫌がらせ）。
        /// </summary>
        [JsonStringEnumMemberName("HARM_CATEGORY_HARASSMENT")]
        Harassment,

        /// <summary>
        /// ヘイトスピーチ（憎悪表現）。
        /// </summary>
        [JsonStringEnumMemberName("HARM_CATEGORY_HATE_SPEECH")]
        HateSpeech,

        /// <summary>
        /// 性的に露骨な内容。
        /// </summary>
        [JsonStringEnumMemberName("HARM_CATEGORY_SEXUALLY_EXPLICIT")]
        SexuallyExplicit,

        /// <summary>
        /// 危険な内容（暴力、自傷の助長など）。
        /// </summary>
        [JsonStringEnumMemberName("HARM_CATEGORY_DANGEROUS_CONTENT")]
        DangerousContent
    }
}
