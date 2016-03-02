using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;


namespace UnitTest_VillGreen
{
    [TestClass]
    public class UnitTest1
    {
        ClientDAO data = new ClientDAO();

        [TestMethod]
        public void TestMethod1()
        {
            Client c = new Client();
            c.NomClient = "Test8";
            c.ClientPro = true;
            c.AdressFact = "LàQuiPaye3";
            c.AdressLiv = "LàQuiReçoit3";
            c.IdComm = 1;

            data.Insert(c);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Client c = new Client();
            c.NomClient = "Test9";
            c.ClientPro = false;
            c.AdressFact = "LàOùPaye";
            c.AdressLiv = "LàOùReçoit";
            c.IdComm = 2;

            data.Insert(c);
        }

    }
}
