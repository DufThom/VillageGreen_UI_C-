using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace Interrogation_VilGreen
{
    public partial class Form1 : Form
    {
        ClientDAO data = new ClientDAO();
        CommandDAO dataCom = new CommandDAO();
        string Action = "";

        public Form1()
        {
            InitializeComponent();
            this.Height = 344; // petit, et 506 en grand
            label6_Pro.Visible = false;
            label7_Part.Visible = false;
            button5.Enabled = false;

            listBox1.DisplayMember = "NomClient";
            listBox1.ValueMember = "Id";
            listBox1.DataSource = data.List();

        }

        private void button1_Click(object sender, EventArgs e) //Btn "Afficher Infos du Client séléctionné"
        {
            dataGridView1.DataSource = null;
            if (listBox1.SelectedIndex != -1)
            {
                int Id = (int)listBox1.SelectedValue;

                Client Cli = data.Find(Id);

                textBox1.Text = Cli.NomClient;
                textBox2.Text = Cli.AdressFact;
                textBox3.Text = Cli.AdressLiv;
                if (Cli.IdComm == 1)
                {
                    textBox4.Text = "M. VÉHERPÉ";
                }
                else
                {
                    textBox4.Text = "Mme COMMERRE";
                }
                if (Cli.ClientPro == true)
                {
                    label6_Pro.Visible = true;
                    label7_Part.Visible = false;
                }
                else
                {
                    label6_Pro.Visible = false;
                    label7_Part.Visible = true;
                }
                button5.Enabled = true;
                this.Height = 344;
            }
        }

        private void button2_Click(object sender, EventArgs e) //Btn "Ajout New Client"
        {
            Action = "Ajouter";
            groupBox1.Text = "Ajouter";
        }

        private void button3_Click(object sender, EventArgs e) // Btn "Modif Client"
        {
            Action = "Modifier";
            groupBox1.Text = "Modifier";
        }

        private void button4_Click(object sender, EventArgs e) // Btn "supprimer Client"
        {
            Action = "Supprimer";
            groupBox1.Text = "Supprimer";
        }

        private void button5_Click(object sender, EventArgs e) // Btn "Historique Commandes"
        {

            if (listBox1.SelectedIndex != -1)
            {
                this.Height = 506;
                int Id = (int)listBox1.SelectedValue;
                dataGridView1.DataSource = dataCom.CommandCli(Id); 
                dataGridView1.Columns[0].Visible = false; // Masque la 1ère colonne du DGView
                dataGridView1.RowHeadersVisible = false; //Masque la colonne contenant l'en-tête (Id_Client)
                dataGridView1.ReadOnly = true; // En lecture Seule
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Séléctionne la ligne entière  
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;// Ajuste la taille des colonnes pour remplir tout le cadre
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            }

        }

        private void button6_Click(object sender, EventArgs e) // Btn "OK" qui valide l'Ajout, Modif et Supp
        {

        }

        private void button7_Click(object sender, EventArgs e) // Btn "Annuler"
        {
            button5.Enabled = false;
            this.Height = 344; // petit, et 506 en grand
            label6_Pro.Visible = false;
            label7_Part.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            
        }
    }
}
