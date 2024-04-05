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
            MSTestLog.WriteLine($"{fieldName_}: ¡i{npf_}¡j");

            var propertyName_ = "NonPublicProperty1";
            string npp_ = GetNonPublicValue.GetPropertyValue(npc_, propertyName_) as string;
            MSTestLog.WriteLine($"{propertyName_} Value: ¡i{npp_}¡j");
        }

        [TestMethod]
        public void GetFields()
        {
            var npc_ = new NonPublicClass();
            List<NonPublic> fs_ = GetNonPublicValue.GetNonPublicFields(npc_);
            fs_.ForEach( x =>
            {
                MSTestLog.WriteLine($"Fields: name¡i {x.npName} ¡j type¡i {x.npType.Name} ¡j value¡i {x.npObject.ToString()}¡j");
            });
        }

        [TestMethod]
        public void GetGetPropertys()
        {
            var npc_ = new NonPublicClass();
            List<NonPublic> pi_ = GetNonPublicValue.GetNonPublicPropertys(npc_);
            pi_.ForEach(x =>
            {
                MSTestLog.WriteLine($"Propertys: name¡i {x.npName}] type¡i {x.npType.Name}¡j value¡i {x.npObject.ToString()}¡j");
            });
        }
    }
}
