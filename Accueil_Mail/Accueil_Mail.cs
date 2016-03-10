using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mail_Console;

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
            string Mail = textBox1.Text;
            string Result = Mail_Console.Program.Cont_Mail(Mail);
            if ( Result == "OK")
            {
                Interrogation_VilGreen.Interface_Utilisateur IU = new Interrogation_VilGreen.Interface_Utilisateur();
                IU.ShowDialog();
            }
            else
            {
                MessageBox.Show(Result,"Erreur", MessageBoxButtons.YesNo);
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
