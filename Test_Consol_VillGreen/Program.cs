using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Test_Consol_VillGreen
{
    class Program
    {
        static void Main(string[] args)
        {
  //++++++++++++++++++++++ Test des Class CLIENT & CLIENTDAO #############################################
            ClientDAO data = new ClientDAO();

            //++++++++++++++++++++++++++++++ Test LISTE ++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //foreach (Client c in data.List())
            //{
            //    Console.WriteLine(c.Id +" "+ c.NomClient +" "+ c.ClientPro +" "+ c.AdressFact +" "+ c.AdressLiv +" "+ c.IdComm);
            //}
            //Console.ReadLine();

            //++++++++++++++++++++++++++++++ Test FIND ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //Client c = data.Find(2);
            //Console.WriteLine(c.NomClient);
            //Console.ReadLine();

            //++++++++++++++++++++++++++++++ Test INSERT ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Client c = new Client();
            c.NomClient = "Test7";
            c.ClientPro = true;
            c.AdressFact = "LàQuiPaye";
            c.AdressLiv = "LàQuiReçoit";
            c.IdComm = 2;

            data.Insert(c);

            //++++++++++++++++++++++++++++++ Test UPDATE ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //Client c = new Client();
            //c.Id = 7;
            //c.NomClient = "Test5";
            //c.ClientPro = true;
            //c.AdressFact = "Par Ici";
            //c.AdressLiv = "Où bien par là";
            //c.IdComm = 2;

            //data.Update(c);

            //++++++++++++++++++++++++++++++ Test DELETE ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //Client c = new Client();

            //c.Id = 6;

            //data.Delete(c);


            //++++++++++++++++++++++ Test des Class COMMAND & COMMANDDAO #############################################
            CommandDAO dataCom = new CommandDAO();

            //+++++++++++++ Test LISTE des COMMANDES par CLIENT ++++++++++++++++++++++++++++++++++++++++++++
            //foreach (Command co in  dataCom.CommandCli(2))
            //{
            //    Console.WriteLine(co.IdCommand + " " + co.DateCom);
            //}
            //Console.ReadLine();

            //++++++++++++++++++




        }
    }
}
