# Get NonPublic Value By Reflection   
總是會有些情境上  
你需要一些物件資訊的內容  
偏偏這個物件的資訊內容不是公開的  
這時候這個工具就派上用場了  
只要一行程式碼  
就能知道非公開的物件資訊內容是什麼了  
舉個例子：
假設有一個物件長相如下：
``` C#
public class NonPublicClass
{
    private string NonPublicField = "I'am Field";
    private string NonPublicProperty { get; set; } = "I'am Property";
}
```
如果我們需要裡面的 NonPublicField 與 NonPublicProperty 的內容  
可惜他們都是非公開的成員變數  
這時候就可以利用這個工具來取得資訊內容，程式碼如下：
``` C#
NonPublicClass npc_ = new NonPublicClass();

string npf_ = GetNonPublicValue.GetFieldValue(npc_, "NonPublicField") as string;
MSTestLog.WriteLine($"NonPublic Field Value: {npf_}");

string npp_ = GetNonPublicValue.GetPropertyValue(npc_, "NonPublicProperty") as string;
MSTestLog.WriteLine($"NonPublic Property Value: {npp_}");
```
簡簡單單的幾行程式，輕鬆取到非公開的內容:smile:

# git commit message
- 常用描述
```
✨ feat: 需求功能描述
🐛 fix: 修正 bug 的問題描述
💄 optimize: 最佳化程式碼或功能流程
🔧 chore: 雜事，例如: 調整設定檔案等等 
```

