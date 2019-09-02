using GetNonPublicValueByReflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestTool;

namespace UnitTestProject
{
    public class NonPublicClass
    {
        private string NonPublicField = "I'am Field";
        private string NonPublicProperty { get; set; } = "I'am Property";
    }

    [TestClass]
    public class UnitTest
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            MSTestLog.Initialize();
        }

        [TestMethod]
        public void TestMethod()
        {
            NonPublicClass npc_ = new NonPublicClass();

            string npf_ = GetNonPublicValue.GetFieldValue(npc_, "NonPublicField") as string;
            MSTestLog.WriteLine($"NonPublic Field Value: {npf_}");

            string npp_ = GetNonPublicValue.GetPropertyValue(npc_, "NonPublicProperty") as string;
            MSTestLog.WriteLine($"NonPublic Property Value: {npp_}");
        }
    }
}
