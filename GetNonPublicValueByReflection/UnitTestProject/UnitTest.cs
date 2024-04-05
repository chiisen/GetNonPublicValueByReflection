using GetNonPublicValueByReflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestTool;
using System.Collections.Generic;

namespace UnitTestProject
{
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
            var npc_ = new NonPublicClass();

            var fieldName_ = "NonPublicField1";
            string npf_ = GetNonPublicValue.GetFieldValue(npc_, fieldName_) as string;
            MSTestLog.WriteLine($"{fieldName_}: 【{npf_}】");

            var propertyName_ = "NonPublicProperty1";
            string npp_ = GetNonPublicValue.GetPropertyValue(npc_, propertyName_) as string;
            MSTestLog.WriteLine($"{propertyName_} Value: 【{npp_}】");
        }

        [TestMethod]
        public void GetFields()
        {
            var npc_ = new NonPublicClass();
            List<NonPublic> fs_ = GetNonPublicValue.GetNonPublicFields(npc_);
            fs_.ForEach( x =>
            {
                MSTestLog.WriteLine($"Fields: name【 {x.npName} 】 type【 {x.npType.Name} 】 value【 {x.npObject}】");
            });
        }

        [TestMethod]
        public void GetGetPropertys()
        {
            var npc_ = new NonPublicClass();
            List<NonPublic> pi_ = GetNonPublicValue.GetNonPublicPropertys(npc_);
            pi_.ForEach(x =>
            {
                MSTestLog.WriteLine($"Propertys: name【 {x.npName}] type【 {x.npType.Name}】 value【 {x.npObject}】");
            });
        }
    }
}
