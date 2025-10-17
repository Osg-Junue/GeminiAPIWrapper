using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeminiAPIWrapper.Configurations
{
    /// <summary>
    /// Reasoning/Thinking 設定（対応モデルのみ）。
    /// 参考: https://ai.google.dev/gemini-api/docs/thinking?hl=ja
    /// </summary>
    public sealed class ThinkingConfig
    {
        /// <summary>
        /// 思考トークン予算。-1 で動的、0 で無効。
        /// </summary>
        [JsonPropertyName("thinkingBudget")]
        public int ThinkingBudget { get; set; }

        /// <summary>
        /// 思考の要約を応答に含めるか。
        /// </summary>
        [JsonPropertyName("include_thoughts")]
        public bool IncludeThoughts { get; set; }
    }
}
