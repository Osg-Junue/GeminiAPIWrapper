using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// 応答生成の設定。モデルの出力動作を制御します。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#generationconfig
    /// </summary>
    public sealed class GenerationConfig
    {
        /// <summary>
        /// 【任意】温度。トークン選択のランダム性を制御（Top-P/Top-K と併用）。
        /// 一般に 0〜2 程度（明示的上限は非公開）。
        /// 参考: Inference → GenerationConfig.temperature
        /// </summary>
        [JsonPropertyName("temperature")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Temperature { get; set; }

        /// <summary>
        /// 【任意】Top-P（Nucleus サンプリング）。確率累積が Top-P となる範囲から選択。
        /// 範囲: 0.0〜1.0。
        /// 参考: Inference → GenerationConfig.topP
        /// </summary>
        [JsonPropertyName("topP")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TopP { get; set; }

        /// <summary>
        /// 【任意】出力最大トークン数。到達時に生成停止。
        /// 範囲: モデル依存（Count Tokens とモデル仕様を参照）。
        /// 参考: Inference → GenerationConfig.maxOutputTokens
        /// </summary>
        [JsonPropertyName("maxOutputTokens")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxOutputTokens { get; set; }

        /// <summary>
        /// 【任意】Top-K。確率上位 K 個からサンプリング。
        /// 範囲: モデル依存（明示的範囲は非公開）。
        /// 参考: Inference → GenerationConfig.topK
        /// </summary>
        [JsonPropertyName("topK")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TopK { get; set; }

        /// <summary>
        /// 【任意】候補数（バリエーション）。generateContent のみ有効（stream 未対応）。
        /// 範囲: モデル依存（例: gemini-2.0-flash-lite: 1–8、gemini-2.0-flash: 1–2）。
        /// 参考: Inference → GenerationConfig.candidateCount
        /// </summary>
        [JsonPropertyName("candidateCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CandidateCount { get; set; }

        /// <summary>
        /// 【任意】停止シーケンス。出力に一致したら生成停止（大文字小文字は区別）。
        /// 参考: Inference → GenerationConfig.stopSequences
        /// </summary>
        [JsonPropertyName("stopSequences")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? StopSequences { get; set; }

        /// <summary>
        /// 【任意】presencePenalty。既出トークンにペナルティを与え多様性を促す。
        /// 範囲: -2.0〜（2.0の手前）。
        /// 参考: Inference → GenerationConfig.presencePenalty
        /// </summary>
        [JsonPropertyName("presencePenalty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PresencePenalty { get; set; }

        /// <summary>
        /// 【任意】frequencyPenalty。繰り返し出現にペナルティを与え反復を抑制。
        /// 範囲: -2.0〜（2.0の手前）。
        /// 参考: Inference → GenerationConfig.frequencyPenalty
        /// </summary>
        [JsonPropertyName("frequencyPenalty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? FrequencyPenalty { get; set; }

        /// <summary>
        /// 【任意】出力 MIME タイプ。text/plain（既定）/application/json/text/x.enum。
        /// 参考: Inference → GenerationConfig.responseMimeType
        /// </summary>
        [JsonPropertyName("responseMimeType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseMimeType? ResponseMimeType { get; set; }

        /// <summary>
        /// 【任意】出力スキーマ。responseMimeType が text/plain 以外のときに使用。
        /// 参考: 構造化出力 https://cloud.google.com/vertex-ai/generative-ai/docs/multimodal/structured-output?hl=ja
        /// および Schema 型 https://cloud.google.com/vertex-ai/docs/reference/rest/v1/projects.locations.cachedContents?hl=ja#Schema
        /// </summary>
        [JsonPropertyName("responseSchema")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Schema? ResponseSchema { get; set; }

        /// <summary>
        /// 【任意】思考（reasoning）設定（対応モデルのみ）。
        /// 参考: モデル固有ドキュメント
        /// </summary>
        [JsonPropertyName("thinkingConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ThinkingConfig? ThinkingConfig { get; set; }

        /// <summary>
        /// 【任意】シード。再現性を高めるベストエフォート。
        /// 範囲: 32bit 整数相当（厳密範囲は非公開）。
        /// 参考: Inference → GenerationConfig.seed
        /// </summary>
        [JsonPropertyName("seed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Seed { get; set; }

        /// <summary>
        /// 【任意】各生成ステップの選択トークンのログ確率を返すか。
        /// 参考: Inference → GenerationConfig.responseLogprobs
        /// </summary>
        [JsonPropertyName("responseLogprobs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ResponseLogprobs { get; set; }

        /// <summary>
        /// 【任意】各ステップで返す上位候補トークン数。
        /// 範囲: 1〜20（responseLogprobs=true が必要）。
        /// 参考: Inference → GenerationConfig.logprobs
        /// </summary>
        [JsonPropertyName("logprobs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Logprobs { get; set; }

        /// <summary>
        /// 【任意】音声タイムスタンプ認識（対応モデルのみ、プレビュー）。
        /// 参考: Inference → GenerationConfig.audioTimestamp
        /// </summary>
        [JsonPropertyName("audioTimestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AudioTimestamp { get; set; }

    }

    /// <summary>
    /// 出力 MIME タイプ。
    /// 参考: https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/inference?hl=ja#generationconfig
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<ResponseMimeType>))]
    public enum ResponseMimeType
    {
        /// <summary>
        /// プレーンテキスト出力（既定）。
        /// </summary>
        [JsonStringEnumMemberName("text/plain")]
        TextPlain,

        /// <summary>
        /// JSON 出力。構造化出力時は responseSchema と併用。
        /// </summary>
        [JsonStringEnumMemberName("application/json")]
        ApplicationJson,

        /// <summary>
        /// 列挙出力。responseSchema の enum と併用。
        /// </summary>
        [JsonStringEnumMemberName("text/x.enum")]
        TextXEnum
    }
}