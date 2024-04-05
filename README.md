# Get NonPublic Value By Reflection   
在某些情境中，你可能需要取得某些物件的資訊，但這些資訊並非公開。
這時，我們的工具就能派上用場。
只需一行程式碼，就能取得這些非公開的物件資訊。

讓我們以一個例子來說明，假設我們有一個物件，其內容如下：
``` C#
public class NonPublicClass
{
    private string NonPublicField = "I'am Field";
    private string NonPublicProperty { get; set; } = "I'am Property";
}
```
假如我們需要取得 NonPublicField 和 NonPublicProperty 的內容，
但不幸的是，它們都是非公開的成員變數。
在這種情況下，我們可以利用這個工具來獲取這些資訊，相關的程式碼如下所示：
``` C#
NonPublicClass npc_ = new NonPublicClass();

string npf_ = GetNonPublicValue.GetFieldValue(npc_, "NonPublicField") as string;
MSTestLog.WriteLine($"NonPublic Field Value: {npf_}");

string npp_ = GetNonPublicValue.GetPropertyValue(npc_, "NonPublicProperty") as string;
MSTestLog.WriteLine($"NonPublic Property Value: {npp_}");
```
只需幾行簡單的程式碼，就能輕鬆獲取非公開的內容。:smile:

# git commit message
- 常用描述
```
✨ feat: 需求功能描述
🐛 fix: 修正 bug 的問題描述
💄 optimize: 最佳化程式碼或功能流程
🔧 chore: 雜事，例如: 調整設定檔案等等 
```

