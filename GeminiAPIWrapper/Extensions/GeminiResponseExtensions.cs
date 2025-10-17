using System.Collections.Generic;
using System.Linq;
using GeminiAPIWrapper.Configurations;

namespace GeminiAPIWrapper.Extensions
{
    /// <summary>
    /// GeminiResponse から共通の値を取り出すための補助メソッド集。
    /// </summary>
    public static class GeminiResponseExtensions
    {
        /// <summary>
        /// 最初の候補に含まれる最初のテキストパートを返します。存在しない場合は null を返します。
        /// </summary>
        public static string? GetText(this GeminiResponse? response)
        {
            return response is null ? null : (response?.Candidates[0]?.Content?.Parts[0].Text);
        }


        /// <summary>
        /// 候補のパーツ内で見つかった最初の functionCall を返します。存在しない場合は null を返します。
        /// </summary>
        public static FunctionCall? GetFunctionCall(this GeminiResponse? response)
        {
            var currentPart = response?.Candidates[0]?.Content?.Parts[0];
            return currentPart?.FunctionCall;

        }
    }
}
