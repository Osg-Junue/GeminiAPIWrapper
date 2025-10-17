using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 関数宣言（関数呼び出し）。OpenAPI 3.0 形式のスキーマで引数/応答を記述。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/multimodal/function-calling?hl=ja
    /// </summary>
    public sealed class FunctionDeclaration
    {
        /// <summary>
        /// 関数名（英字/アンダースコアで開始、英数/_/.-、最大64文字）。
        /// 参考: 上記 function-calling → name 制約
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        /// <summary>
        /// 関数の説明。
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; init; }

        /// <summary>
        /// 入力パラメータの OpenAPI JSON スキーマ。
        /// 参考: 上記 function-calling → parameters（Schema）
        /// </summary>
        [JsonPropertyName("parameters")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Schema? Parameters { get; init; }

        /// <summary>
        /// レスポンスの OpenAPI JSON スキーマ。
        /// 参考: 上記 function-calling（response スキーマがある場合）
        /// </summary>
        [JsonPropertyName("response")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Schema? Response { get; init; }
    }
}
