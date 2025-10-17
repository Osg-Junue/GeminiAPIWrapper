using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiAPIWrapper.Options;

public record GenerativeLanguageOptions
{
    public required string EndpointBase { get; init; }

    public required string ApiKey { get; init; }

    public string KeyHeader { get; init; } = "X-Goog-Api-Key";

    internal string ContentType { get; } = "application/json";
}
