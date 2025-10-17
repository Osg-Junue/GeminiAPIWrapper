namespace GeminiAPIWrapper.Attributes;

/// <summary>
/// メソッドに対する生成オプションを指定するための属性。
/// GeminiAPIWrapper 内部でメタデータとして利用されます。
/// </summary>
/// <param name="option">生成時のオプション名やフラグを表す文字列。</param>
[AttributeUsage(AttributeTargets.Method)]
internal class GenerateOptionAttribute(string option) : Attribute
{
    /// <summary>
    /// 属性に渡されたオプション値。
    /// </summary>
    public string Option { get; } = option;
}
