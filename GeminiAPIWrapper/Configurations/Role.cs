using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 役割（コンテンツの発言者）。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#contents
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<Role>))]
    public enum Role
    {
        /// <summary>
        /// ユーザー。
        /// </summary>
        [JsonStringEnumMemberName("user")]
        User,

        /// <summary>
        /// モデル。
        /// </summary>
        [JsonStringEnumMemberName("model")]
        Model,
    }
}