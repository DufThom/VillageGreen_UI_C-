using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accueil_Mail
{
    public partial class Accueil_Mail : Form
    {
        public Accueil_Mail()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            Interrogation_VilGreen.Interface_Utilisateur IU = new Interrogation_VilGreen.Interface_Utilisateur();
            IU.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
