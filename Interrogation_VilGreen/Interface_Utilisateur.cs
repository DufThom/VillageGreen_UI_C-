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
using System.Text.RegularExpressions;

namespace Interrogation_VilGreen
{

    public partial class Interface_Utilisateur : Form
    {
        ClientDAO data = new ClientDAO();
        CommandDAO dataCom = new CommandDAO();
        string Action = "";

        public Interface_Utilisateur()
        {
            InitializeComponent();
            this.Height = 344; // Taille du Form en petit, et 506 en grand
            label6_Pro.Visible = false; //Cache le Label "Client Pro"
            label7_Part.Visible = false; //Cache le Label "Client Part"
            button3.Enabled = false; // Désactive le Btn "Modifier"
            button4.Enabled = false; // Désactive le Btn "Supprimer"
            button5.Enabled = false; // Désactive le Btn "Historique des Commandes"

            button6.Enabled = false; // Désactive le Btn OK, pour obliger à bien remplir le Form

            radioButton1.Visible = false; // Cache le CheckBox "Particulier"
            radioButton2.Visible = false; // Cache le CheckBox "Professionnel"
            // Affichage Gestion Commerciaux : 
            label5.Visible = true; // affiche label "Nom Commercial"
            textBox4.Visible = true; // Affiche TextBox Commercial
            groupBox2.Visible = false; // Cache le GroupBox Commercial
            radioButton3.Visible = false; //Cache le radioBtn "M. Véherpé"
            radioButton4.Visible = false; //Cache le radioBtn "Mme Commerre"

            // Chargement de la ListBox, en affichant le Nom des Clients :
            listBox1.DisplayMember = "NomClient";
            listBox1.ValueMember = "Id";
            listBox1.DataSource = data.List();

        }

        private void button1_Click(object sender, EventArgs e) //Btn "Afficher Infos du Client séléctionné"
        {
            radioButton1.Visible = false; // Cache le CheckBox "Particulier"
            radioButton2.Visible = false; // Cache le CheckBox "Professionnel"
            dataGridView1.DataSource = null; // Initialise le DGV à chaque fois qu'on séléctionne un autre client
            // Affichage Gestion Commerciaux : 
            label5.Visible = true; // affiche label "Nom Commercial"
            textBox4.Visible = true; // Affiche TextBox Commercial
            groupBox2.Visible = false; // Cache le GroupBox Commercial
            radioButton3.Visible = false; //Cache le radioBtn "M. Véherpé"
            radioButton4.Visible = false; //Cache le radioBtn "Mme Commerre"
            if (listBox1.SelectedIndex != -1)
            {
                int Id = (int)listBox1.SelectedValue;

                Client Cli = data.Find(Id); // Appel du "Find"

                // Remplit les TextBox : 
                textBox1.Text = Cli.NomClient;
                textBox2.Text = Cli.AdressFact;
                textBox3.Text = Cli.AdressLiv;
                // TextBox4 affichera le nom du Commercial:
                if (Cli.IdComm == 1)
                {
                    textBox4.Text = "M. VÉHERPÉ";
                }
                else
                {
                    textBox4.Text = "Mme COMMERRE";
                }
                // Affichera le Label 6 ou 7 si Client Pro ou Particulier:
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

                button3.Enabled = true; // Active le Btn "Modifier"
                button4.Enabled = true; // Active le Btn "Supprimer"
                button5.Enabled = true; // Active le Btn "Histo des commandes"
                this.Height = 344; // Réduit le Form à chaque nouvelle séléction de Client
            }
        }

        private void button2_Click(object sender, EventArgs e) //Btn "Ajout New Client"
        {
            Action = "Ajouter";
            groupBox1.Text = "Ajouter"; // Change le Titre du GroupBox selon l'action séléctionnée
            label6_Pro.Visible = false; //Cache le Label "Client Pro"
            label7_Part.Visible = false; //Cache le Label "Client Part"
            radioButton1.Visible = true; // Affiche le CheckBox "Particulier"
            radioButton2.Visible = true; // Affiche le CheckBox "Professionnel"
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            this.Height = 344;
            dataGridView1.DataSource = null;
            // Gestion partie Commerciaux : 
            label5.Visible = false; //Cache "Nom Commercial:"
            textBox4.Visible = false; // Cache textbox Commercial
            groupBox2.Visible = true; // Affiche GroupBox "Commercial:"
            radioButton3.Visible = true; //Affiche les radioBtn pour choisir un commercial
            radioButton4.Visible = true;
            // Initialiser les radioBtn : 
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            //Désactiver les Btn "Modif, Supp et Historiq Command"
            button3.Enabled = false; // Désactive le Btn "Modifier"
            button4.Enabled = false; // Désactive le Btn "Supprimer"
            button5.Enabled = false; // Désactive le Btn "Historique des Commandes"
            


        }

        private void button3_Click(object sender, EventArgs e) // Btn "Modif Client"
        {

            if (listBox1.SelectedIndex != -1)
            {
                Action = "Modifier";
                groupBox1.Text = "Modifier";
                label6_Pro.Visible = false; //Cache le Label "Client Pro"
                label7_Part.Visible = false; //Cache le Label "Client Part"
                radioButton1.Visible = true; // Affiche le CheckBox "Particulier"
                radioButton2.Visible = true; // Affiche le CheckBox "Professionnel"
                this.Height = 344;
                dataGridView1.DataSource = null;
                // Gestion partie Commercial : 
                label5.Visible = false; //Cache "Nom Commercial:"
                textBox4.Visible = false; // Cache textbox Commercial
                groupBox2.Visible = true; // Affiche GroupBox "Commercial:"
                radioButton3.Visible = true; //Affiche les radioBtn pour choisir un commercial
                radioButton4.Visible = true;
                // Initialser les radioBtn : 
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }

        }

        private void button4_Click(object sender, EventArgs e) // Btn "supprimer Client"
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            // Affichage Gestion Commercial : 
            label5.Visible = true; // affiche label "Nom Commercial"
            textBox4.Visible = true; // Affiche TextBox Commercial
            groupBox2.Visible = false; // Cache le GroupBox Commercial
            radioButton3.Visible = false; //Cache le radioBtn "M. Véherpé"
            radioButton4.Visible = false; //Cache le radioBtn "Mme Commerre"
            if (listBox1.SelectedIndex != -1)
            {
                Action = "Supprimer";
                groupBox1.Text = "Supprimer";
            }

        }

        private void button5_Click(object sender, EventArgs e) // Btn "Historique Commandes"
        {

            if (listBox1.SelectedIndex != -1)
            {
                this.Height = 506; // Agrandit le Form
                this.dataGridView1.EnableHeadersVisualStyles = false; // Désactive le style par défaut, permettant de modifier (ici, pour changer la couleur de la ligne d'en-tête)
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen; //change la couleur des en-têtes du dataGridView

                int Id = (int)listBox1.SelectedValue;
                dataGridView1.DataSource = dataCom.CommandCli(Id); // Charge le DGV en appelant la méthode "CommandCli" du "CommandDAO"
                dataGridView1.Columns[0].Visible = false; // Masque la 1ère colonne du DGView
                dataGridView1.RowHeadersVisible = false; //Masque la colonne contenant l'en-tête (Id_Client)
                dataGridView1.ReadOnly = true; // En lecture Seule
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Séléctionne la ligne entière  
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;// Ajuste la largeur des colonnes pour remplir tout le cadre
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells; //Ajuste la hauteur des cellules en fonction du contenu

                // ++++ Renommer les entêtes de Colonnes : 
                dataGridView1.Columns[1].HeaderText = "Date Commande";
                dataGridView1.Columns[2].HeaderText = "État Préparation";
                dataGridView1.Columns[3].HeaderText = "Total HT";
                dataGridView1.Columns[4].HeaderText = "Réglement";
                dataGridView1.Columns[5].HeaderText = "Date Réglement";
                dataGridView1.Columns[6].HeaderText = "État Réglement";
                dataGridView1.Columns[7].HeaderText = "Réduction";
                dataGridView1.Columns[8].HeaderText = "Id Client";


            }

        }

        private void button6_Click(object sender, EventArgs e) // Btn "OK" qui valide l'Ajout, Modif et Supp
        {
            Regex TxtNom = new Regex(@"^[a-zA-Z]{3,100}$");
            Regex TxtAdrFact = new Regex(@"^[a-zA-Z0-9'-_ ]{3,200}$");
            Regex TxtAdrLiv = new Regex(@"^[a-zA-Z0-9'-_ ]{3,200}$");

            if (Action == "Ajouter")
            {
                Client Cli = new Client();
                // Choisir Client Pro ou Particulier : 
                if (radioButton1.Checked == true)
                {
                    Cli.ClientPro = false;
                    //button6.Enabled = true;
                }
                else if (radioButton2.Checked == true)
                {
                    Cli.ClientPro = true;
                    //button6.Enabled = true;
                }

                
                if (TxtNom.IsMatch(textBox1.Text))
                {
                    Cli.NomClient = textBox1.Text;
                    textBox1.BackColor = SystemColors.Window;
                }
                else
                {
                    textBox1.BackColor = Color.Red;
                }

                if (TxtAdrFact.IsMatch(textBox2.Text))
                {
                    Cli.AdressFact = textBox2.Text;
                    textBox2.BackColor = SystemColors.Window;
                }
                else
                {
                    textBox2.BackColor = Color.Red;
                }

                if (TxtAdrLiv.IsMatch(textBox3.Text))
                {
                    Cli.AdressLiv = textBox3.Text;
                    textBox3.BackColor = SystemColors.Window;
                }
                else
                {
                    textBox3.BackColor = Color.Red;
                }


                // Choisir un Commercial : 
                if (radioButton3.Checked == true)
                {
                    Cli.IdComm = 1;
                    //button6.Enabled = true;
                }
                else if (radioButton4.Checked == true)
                {
                    Cli.IdComm = 2;
                    //button6.Enabled = true;
                }

                // si tous les champs text sont ok : 
                if (TxtNom.IsMatch(textBox1.Text) && TxtAdrFact.IsMatch(textBox2.Text) && TxtAdrLiv.IsMatch(textBox3.Text))
                {
                    data.Insert(Cli);
                    listBox1.DataSource = data.List();
                }
                
            }

            if (Action == "Modifier")
            {
                Client Cli = new Client();

                Cli.Id = (int)listBox1.SelectedValue;
                if (radioButton1.Checked == true)
                {
                    Cli.ClientPro = false;
                }
                else if (radioButton2.Checked == true)
                {
                    Cli.ClientPro = true;
                }

                if (TxtNom.IsMatch(textBox1.Text))
                {
                    Cli.NomClient = textBox1.Text;
                    textBox1.BackColor = SystemColors.Window;
                }
                else
                {
                    textBox1.BackColor = Color.Red;
                }

                if (TxtAdrFact.IsMatch(textBox2.Text))
                {
                    Cli.AdressFact = textBox2.Text;
                    textBox2.BackColor = SystemColors.Window;
                }
                else
                {
                    textBox2.BackColor = Color.Red;
                }

                if (TxtAdrLiv.IsMatch(textBox3.Text))
                {
                    Cli.AdressLiv = textBox3.Text;
                    textBox3.BackColor = SystemColors.Window;
                }
                else
                {
                    textBox3.BackColor = Color.Red;
                }

                if (radioButton3.Checked == true)
                {
                    Cli.IdComm = 1;
                }
                else if (radioButton4.Checked == true)
                {
                    Cli.IdComm = 2;
                }

                if (TxtNom.IsMatch(textBox1.Text) && TxtAdrFact.IsMatch(textBox2.Text) && TxtAdrLiv.IsMatch(textBox3.Text))
                {
                    data.Update(Cli);
                    listBox1.DataSource = data.List();
                }
                
            }

            if (Action == "Supprimer")
            {
                DialogResult dr = MessageBox.Show("Êtes-vous sûr ?", "Suppression du client !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    Client Cli = new Client();

                    Cli.Id = (int)listBox1.SelectedValue;

                    data.Delete(Cli);
                    listBox1.DataSource = data.List();
                }

            }

        }

        private void button7_Click(object sender, EventArgs e) // Btn "Annuler"
        {
            button5.Enabled = false; // Cache le Btn "Historique des Commandes"
            this.Height = 344; // Referme le Form
            label6_Pro.Visible = false; //Cache le Label "Client Pro"
            label7_Part.Visible = false; //Cache le Label "Client Part"
            radioButton1.Visible = false; // Cache le CheckBox "Particulier"
            radioButton2.Visible = false; // Cache le CheckBox "Professionnel"
            // Affichage Gestion Commercial : 
            label5.Visible = true; // affiche label "Nom Commercial"
            textBox4.Visible = true; // Affiche TextBox Commercial
            groupBox2.Visible = false; // Cache le GroupBox Commercial
            radioButton3.Visible = false; //Cache le radioBtn "M. Véherpé"
            radioButton4.Visible = false; //Cache le radioBtn "Mme Commerre"
            textBox1.Text = "";
            textBox1.BackColor = SystemColors.Window;
            textBox2.Text = "";
            textBox2.BackColor = SystemColors.Window;
            textBox3.Text = "";
            textBox3.BackColor = SystemColors.Window;
            textBox4.Text = "";
            textBox4.BackColor = SystemColors.Window;
            groupBox1.Text = "";


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) // Initialise le Form à vide si clic sur un autre client dans le ListBox
        {
            button3.Enabled = false; // Cache le Btn "Modifier"
            button4.Enabled = false; // Cache le Btn "Supprimer"
            button5.Enabled = false; // Cache le Btn "Historique des Commandes"
            this.Height = 344; // Referme le Form
            label6_Pro.Visible = false; //Cache le Label "Client Pro"
            label7_Part.Visible = false; //Cache le Label "Client Part"
            radioButton1.Visible = false; // Cache le CheckBox "Particulier"
            radioButton2.Visible = false; // Cache le CheckBox "Professionnel"
            // Affichage Gestion Commercial : 
            label5.Visible = true; // affiche label "Nom Commercial"
            textBox4.Visible = true; // Affiche TextBox Commercial
            groupBox2.Visible = false; // Cache le GroupBox Commercial
            radioButton3.Visible = false; //Cache le radioBtn "M. Véherpé"
            radioButton4.Visible = false; //Cache le radioBtn "Mme Commerre"
            textBox1.Text = "";
            textBox1.BackColor = SystemColors.Window;
            textBox2.Text = "";
            textBox2.BackColor = SystemColors.Window;
            textBox3.Text = "";
            textBox3.BackColor = SystemColors.Window;
            textBox4.Text = "";
            textBox4.BackColor = SystemColors.Window;
            groupBox1.Text = "";

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) // RadioBtn Particulier
        {
            if (radioButton3.Checked == true || radioButton4.Checked == true)
            {
                button6.Enabled = true; // Active le Btn OK
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // RadioBtn Professionnel
        {
            if (radioButton3.Checked == true || radioButton4.Checked == true)
            {
                button6.Enabled = true; // Active le Btn OK
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) // RadioBtn M.Véherpé
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true)
            {
                button6.Enabled = true; // Active le Btn OK
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) // RadioBtn Mme Commerre
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true)
            {
                button6.Enabled = true; // Active le Btn OK
            }
        }
        //if (radioButton3.Checked == false & radioButton4.Checked == false)
        //        {
        //            button6.Enabled = false;
        //            MessageBox.Show("Veuillez choisir un Commercial !!!");
        //        }
        //        else
        //        {
        //            button6.Enabled = true;
        //        }
        //        if (radioButton1.Checked == false & radioButton2.Checked == false)
        //        {
        //            button6.Enabled = false;
        //            MessageBox.Show("Veuillez séléctionner Particulier ou Professionnel !!!");
        //        }
        //        else
        //        {
        //            button6.Enabled = true;
        //        }


    }
}
