using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Client
    {
        public int Id { get; set;  } //PK, int, Not Null

        public string NomClient { get; set;  } //varchar100, Not Null

        public bool ClientPro { get; set;  } //Bit, Not Null

        public string AdressFact { get; set; } //varchar200, Not Null

        public string AdressLiv { get; set; } //varchar200,   Null

        public int IdComm { get; set; } //FK, int, Not Null


    }
}
