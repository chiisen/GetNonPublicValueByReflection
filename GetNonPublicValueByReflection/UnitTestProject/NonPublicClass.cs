namespace UnitTestProject
{
    public class NonPublicClass
    {
#pragma warning disable IDE0044, IDE0051, CS0414 // 測試用，不會使用到的欄位
        private int NonPublicNumber1 = 1;
        private int NonPublicNumber2 = 2;

        private string NonPublicField1 = "I'am Field1";
        private string NonPublicField2 = "I'am Field2";
        private string NonPublicProperty1 { get; set; } = "I'am Property1";
        private string NonPublicProperty2 { get; set; } = "I'am Property2";
#pragma warning restore IDE0044, IDE0051, CS0414 // 測試用，不會使用到的欄位
    }
}
