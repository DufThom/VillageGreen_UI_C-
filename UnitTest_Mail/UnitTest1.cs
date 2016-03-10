using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mail_Console; 

namespace UnitTest_Mail
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string Mail = "test@test.fr"; // mail bon
            string Result = Program.Cont_Mail(Mail);
            Assert.AreEqual(Result, "OK");
        }

        [TestMethod]
        public void TestMethod2()
        {
            string Mail = "test.test.fr"; //Manque @
            string Result = Program.Cont_Mail(Mail);
            Assert.AreNotEqual(Result, "OK");
        }

        [TestMethod]
        public void TestMethod3()
        {
            string Mail = "test.@test.fr"; // Point devant @
            string Result = Program.Cont_Mail(Mail);
            Assert.AreNotEqual(Result, "OK");
        }

        [TestMethod]
        public void TestMethod4()
        {
            string Mail = "t@test.fr"; // 1 seul caractères devant @
            string Result = Program.Cont_Mail(Mail);
            Assert.AreNotEqual(Result, "OK");
        }

        [TestMethod]
        public void TestMethod5()
        {
            string Mail = "test@testfr"; // Manque Point après @
            string Result = Program.Cont_Mail(Mail);
            Assert.AreNotEqual(Result, "OK");
        }

        [TestMethod]
        public void TestMethod6()
        {
            string Mail = "test.fr"; // manque @
            string Result = Program.Cont_Mail(Mail);
            Assert.AreEqual(Result, "il manque l'@");
        }

        [TestMethod]
        public void TestMethod7()
        {
            string Mail = "test@testfr"; // manque Point
            string Result = Program.Cont_Mail(Mail);
            Assert.AreEqual(Result, "Manque le Point ");
        }

        [TestMethod]
        public void TestMethod8()
        {
            string Mail = "t@test.fr"; // 1 seul caract, avant @
            string Result = Program.Cont_Mail(Mail);
            Assert.AreEqual(Result, "vérifiez le mail avant l'@ ");
        }

        [TestMethod]
        public void TestMethod9()
        {
            string Mail = "test@t.fr"; // 1 seul caract, entre @ et Point
            string Result = Program.Cont_Mail(Mail);
            Assert.AreEqual(Result, "vérifiez entre l'@ et le Point ");
        }

        [TestMethod]
        public void TestMethod10()
        {
            string Mail = "test@test.f"; // 1 seul caract, après Point
            string Result = Program.Cont_Mail(Mail);
            Assert.AreEqual(Result, "vérifiez après le Point");
        }
    }
}
