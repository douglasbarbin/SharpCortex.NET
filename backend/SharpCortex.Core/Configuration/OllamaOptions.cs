namespace SharpCortex.Core.Configuration;

public sealed class OllamaOptions
{
    public const string SectionName = "Ollama";

    public string BaseUrl { get; set; } = string.Empty;
}