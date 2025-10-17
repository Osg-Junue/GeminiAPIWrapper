using System.Text.Json.Serialization;

namespace GeminiAPIWrapper;

[JsonSourceGenerationOptions(WriteIndented = false, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(GeminiRequest))]
internal partial class GeminiRequestJsonContext : JsonSerializerContext
{
}

[JsonSourceGenerationOptions(WriteIndented = false, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(GeminiResponse))]
internal partial class GeminiResponseJsonContext : JsonSerializerContext
{
}
