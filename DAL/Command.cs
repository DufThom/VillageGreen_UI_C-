using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Command
    {
        public int IdCommand { get; set;  }

        public string DateCom { get; set; }

        public string EtatPrepCom { get; set; }

        public string TotalHT { get; set; }

        public string TypeReglmt { get; set; }

        public string DateReglmt { get; set;  }

        public string EtatReglmt { get; set; }

        public decimal Reduct { get; set; }

        public int IdClient { get; set; }

    }
}
