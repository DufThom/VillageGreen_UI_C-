using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    class ClientDAO
    {
        // +++++++++++++++++++++ Partie 1 : Interrogation (Saisie & Affichage) ++++++++++++++++++++++++++++++++++++++++ 



        // +++++++++++++++++++++ Partie 2 : Gestion d'une Table (Ajout, Affichage, Modification, Suppression) ++++++++++


        // +++++++++++++++++++++ Affichage complet ou Unitaire +++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public List<Client> List()
        {
            List<Client> Liste = new List<Client>();

            SqlConnection Connex = new SqlConnection("server=.; database=Village_Green; integrated security= true");
            Connex.Open();

            SqlCommand Reqt = new SqlCommand("select * from stg07.Client", Connex);

            SqlDataReader Result = Reqt.ExecuteReader();

            while (Result.Read())
            {
                Client Cli = new Client();
                Cli.Id = Convert.ToInt32(Result["IdClient"]);
                Cli.NomClient = Convert.ToString(Result["NomClient"]);
                Cli.ClientPro = Convert.ToBoolean(Result["ClientProfessionnel"]);
                Cli.AdressFact = Convert.ToString(Result["AdressFacturClient"]);
                Cli.AdressLiv = Convert.ToString(Result["AdressLivraisonClient"]);
                Cli.IdComm = Convert.ToInt32(Result["IdCommercial"]);

                Liste.Add(Cli);
            }
            Connex.Close();
            return Liste;
        }

        //##### ici, faire le Find #############################

    }
}
