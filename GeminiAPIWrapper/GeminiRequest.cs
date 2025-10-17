using System.Text.Json.Serialization;
using GeminiAPIWrapper.Configurations;

namespace GeminiAPIWrapper
{
    /// <summary>
    /// Gemini 生成リクエスト。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#request-body
    /// </summary>
    public class GeminiRequest
    {
        /// <summary>
        /// 【任意】キャッシュ済みコンテンツのリソース名（コンテキスト）。
        /// 形式: projects/{project}/locations/{location}/cachedContents/{cachedContent}
        /// 参考: 上記 Inference（Request body: cachedContent）
        /// </summary>
        [JsonPropertyName("cachedContent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CachedContent { get; set; }

        /// <summary>
        /// 【必須】会話内容（単発または履歴＋最新）。
        /// 各 Content は role と parts を持ちます。
        /// 参考: 同ページ contents/parts
        /// </summary>
        [JsonPropertyName("contents")]
        public required List<Content> Contents { get; init; }

        /// <summary>
        /// 【任意】システム指示（対応モデルのみ、role は無視）。
        /// 参考: 上記 Inference（Request body: systemInstruction）
        /// </summary>
        [JsonPropertyName("systemInstruction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SystemInstruction? SystemInstruction { get; set; }

        /// <summary>
        /// 【任意】生成設定。
        /// 参考: 上記 Inference（generationConfig）
        /// </summary>
        [JsonPropertyName("generationConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GenerationConfig? GenerationConfig { get; set; }

        /// <summary>
        /// 【任意】関数呼び出しツール宣言。
        /// 参考: 関数呼び出し https://cloud.google.com/vertex-ai/generative-ai/docs/multimodal/function-calling?hl=ja
        /// </summary>
        [JsonPropertyName("tools")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Tool>? Tools { get; set; }

        /// <summary>
        /// 【任意】ツール/関数呼び出しの動作設定（FunctionCallingConfig 等）。
        /// 参考: 関数呼び出し（上記リンク）
        /// </summary>
        [JsonPropertyName("toolConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ToolConfig? ToolConfig { get; set; }

        /// <summary>
        /// 【任意】安全性設定。各候補に適用。
        /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#safety
        /// </summary>
        [JsonPropertyName("safetySettings")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<SafetySetting>? SafetySettings { get; set; }

        /// <summary>
        /// 【任意】ラベル（Key-Value 形式のメタデータ）。
        /// 参考: 上記 Inference（Request body: labels）
        /// </summary>
        [JsonPropertyName("labels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string>? Labels { get; set; }
    }
}