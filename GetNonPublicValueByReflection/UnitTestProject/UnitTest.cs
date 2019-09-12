using GetNonPublicValueByReflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestTool;
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    public class NonPublicClass
    {
        private int NonPublicNumber1 = 1;
        private int NonPublicNumber2 = 2;

        private string NonPublicField1 = "I'am Field1";
        private string NonPublicField2 = "I'am Field2";
        private string NonPublicProperty1 { get; set; } = "I'am Property1";
        private string NonPublicProperty2 { get; set; } = "I'am Property2";
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

        [TestMethod]
        public void GetFields()
        {
            NonPublicClass npc_ = new NonPublicClass();
            List<NonPublic> fs_ = GetNonPublicValue.GetNonPublicFields(npc_);
            fs_.ForEach( x =>
            {
                MSTestLog.WriteLine($"Fields: name[ {x.npName} ] type[ {x.npType.Name} ] value[ {x.npObject.ToString()}]");
            });
        }

        [TestMethod]
        public void GetGetPropertys()
        {
            NonPublicClass npc_ = new NonPublicClass();
            List<NonPublic> pi_ = GetNonPublicValue.GetNonPublicPropertys(npc_);
            pi_.ForEach(x =>
            {
                MSTestLog.WriteLine($"Propertys: name[ {x.npName}] type[ {x.npType.Name}] value[ {x.npObject.ToString()}]");
            });
        }
    }
}
