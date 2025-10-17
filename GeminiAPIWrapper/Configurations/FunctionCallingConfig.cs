using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    public sealed class FunctionCallingConfig
    {
        /// <summary>
        /// 関数呼び出しモード。
        /// </summary>
        [JsonPropertyName("mode")]
        public FunctionCallingMode Mode { get; init; } = FunctionCallingMode.AUTO;

        /// <summary>
        /// 許可する関数名（指定時のみ呼び出し可能）。
        /// </summary>
        [JsonPropertyName("allowed_function_names")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? AllowedFunctionNames { get; init; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter<FunctionCallingMode>))]
    public enum FunctionCallingMode
    {
        //AIが必要に応じて関数を呼び出す
        [JsonStringEnumMemberName("AUTO")]
        AUTO,
        //AIが関数を呼び出さない
        [JsonStringEnumMemberName("NONE")]
        NONE,
        //allowed_function_namesで指定された関数のみを呼び出す
        [JsonStringEnumMemberName("ANY")]
        ANY,
    }
}
