# GeminiAPIWrapper

Gemini API を簡単に利用するための .NET ラッパーライブラリです。

## 特徴

- **Generative Language APIをサポート**
- **ストリーミング・非ストリーミング応答に対応**
- **API キーヘッダーや認証ヘッダーのカスタマイズ可能**
- **System.Text.Json のソース生成を活用した高速なシリアライゼーション**
- **.NET 9 以降に対応**

## サポート対象

- **.NET バージョン**: .NET 9 以降

## インストール

まだ対応していない。
近いうちにnugetに登録予定。

## Quick Start

```csharp
using GeminiAPIWrapper;
using GeminiAPIWrapper.Options;

// オプションを設定
var options = new GenerativeLanguageOptions
{
    EndpointBase = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash",
    ApiKey = "YOUR_API_KEY"
};

// サービスを構築
var service = GeminiServiceBuilder.Build(options);

// テキスト生成
var response = await service.GenerateAsync("こんにちは");
Console.WriteLine(response?.GetText());
```

> **重要**: `EndpointBase` には `:generateContent` や `:streamGenerateContent` などの操作名を含めないでください。
> ライブラリが自動的に適切な操作名を付加します。

### ストリーミング応答

```csharp
await foreach (var chunk in service.StreamGenerateAsync("長文を生成してください"))
{
    Console.Write(chunk?.GetText());
}
```

### 詳細な設定を行う場合

```csharp
using GeminiAPIWrapper.Configurations;

var generationConfig = new GenerationConfig
{
    Temperature = 0.7,
    MaxOutputTokens = 1024
};

var response = await service.GenerateAsync(
    userMessage: "AIについて説明してください",
    systemInstruction: "あなたは親切なアシスタントです",
    generationConfig: generationConfig
);
```

### カスタムリクエストを使用する場合

```csharp
using GeminiAPIWrapper.Configurations;

var request = new GeminiRequest
{
    Contents = 
    [
        new Content
        {
            Role = Role.User,
            Parts = [new Part { Text = "こんにちは" }]
        }
    ],
    GenerationConfig = new GenerationConfig { Temperature = 0.9 }
};

var response = await service.GenerateAsync(request);
```

## API キーヘッダーのカスタマイズ

デフォルトでは `X-Goog-Api-Key` ヘッダーが使用されますが、カスタマイズ可能です。

```csharp
var options = new GenerativeLanguageOptions
{
    EndpointBase = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash-exp",
    ApiKey = "YOUR_API_KEY",
    KeyHeader = "Custom-Api-Key-Header" // カスタムヘッダー名
};
```

## 主要なクラス

- **`GeminiServiceBuilder`**: サービスインスタンスを構築するファクトリクラス
- **`GeminiService`**: API 呼び出しを行うメインサービスクラス
- **`GeminiRequest`**: リクエストの詳細を構成するクラス
- **`GeminiResponse`**: API からの応答を表すクラス
- **`GenerativeLanguageOptions`**: Google AI Studio 用の設定

## 拡張メソッド

`GeminiResponse` には便利な拡張メソッドが用意されています。

```csharp
using GeminiAPIWrapper.Extensions;

// テキストを取得
string? text = response.GetText();

// Function Call を取得
FunctionCall? functionCall = response.GetFunctionCall();
```

## 詳細

ResponseSchemaやFunctionCallの利用については以下の記事で解説しています。

https://osg.junue.net/articles/geminiapiwrapper/

## ライセンス

このプロジェクトは MIT ライセンスの下で公開されています。

## 貢献

プルリクエストや Issue の報告を歓迎します。

## 作者

Name: Osg-Junue

Blog: https://osg.junue.net/
