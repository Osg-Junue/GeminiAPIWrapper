using GeminiAPIWrapper.Attributes;
using Refit;

namespace GeminiAPIWrapper;

internal interface IGeminiClient
{
    [GenerateOption("generateContent")]
    Task<GeminiResponse?> GenerateAsync(GeminiRequest request, CancellationToken cancellationToken = default);

    [GenerateOption("streamGenerateContent")]
    IAsyncEnumerable<GeminiResponse?> StreamGenerateAsync(GeminiRequest request, CancellationToken cancellationToken = default);
}
