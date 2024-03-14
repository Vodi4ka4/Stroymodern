using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Npgsql;
using Stroymodern;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Check_user_true()
        {
            Auto auto = new Auto();
            bool result = auto.Check_user("manager","159632zxc");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_Check_user_false()
        {
            Auto auto = new Auto();
            bool result = auto.Check_user("manager", "159632zx");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test_Check_password_true()
        {
            Auto auto = new Auto();
            bool result = auto.Check_password("admin", "159632zxc");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_Check_password_false()
        {
            Auto auto = new Auto();
            bool result = auto.Check_password("manager", "159632zx");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test_Check_capch()
        {
            Auto auto = new Auto();
            bool result = auto.Capch("25984gthde");
            Assert.IsTrue(result);
        }
    }
}
