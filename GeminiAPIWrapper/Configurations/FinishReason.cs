using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 生成停止理由。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#response-body
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<FinishReason>))]
    public enum FinishReason
    {
        /// <summary>
        /// 終了理由が指定されていないか、不明な状態です。
        /// </summary>
        [JsonStringEnumMemberName("UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// モデルが自然な終了点に達し、生成を停止しました。
        /// </summary>
        [JsonStringEnumMemberName("STOP")]
        Stop,

        /// <summary>
        /// 生成されたトークン数が <c>maxOutputTokens</c> の制限に達したため、生成が停止しました。
        /// </summary>
        [JsonStringEnumMemberName("MAX_TOKENS")]
        MaxTokens,

        /// <summary>
        /// 安全性フィルターによってコンテンツがブロックされたため、生成が停止しました。
        /// </summary>
        [JsonStringEnumMemberName("SAFETY")]
        Safety,

        /// <summary>
        /// モデルが訓練データから記憶したコンテンツを生成しようとしたため、生成が停止しました。
        /// </summary>
        [JsonStringEnumMemberName("RECITATION")]
        Recitation,

        /// <summary>
        /// コンテンツがブロックリストに登録されているため、生成が停止しました。
        /// </summary>
        [JsonStringEnumMemberName("BLOCKLIST")]
        BlockList,

        /// <summary>
        /// 禁止されているコンテンツが検出されたため、生成が停止しました。
        /// </summary>
        [JsonStringEnumMemberName("PROHIBITED_CONTENT")]
        ProhibitedContent,

        /// <summary>
        /// 機密性の高い個人識別情報 (SPII) が検出されたため、生成が停止しました。
        /// </summary>
        [JsonStringEnumMemberName("SPII")]
        Spii,

        /// <summary>
        /// 不適切な形式の関数呼び出しが検出されたため、生成が停止しました。
        /// </summary>
        [JsonStringEnumMemberName("MALFORMED_FUNCTION_CALL")]
        MalformedFunctionCall,

        /// <summary>
        /// その他の理由により生成が停止しました。
        /// </summary>
        [JsonStringEnumMemberName("OTHER")]
        Other
    }
}