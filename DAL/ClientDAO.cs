using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ClientDAO
    {

        // +++++++++++++++++++++ Partie 2 : Gestion d'une Table ( Affichage, Ajout, Modification, Suppression) ++++++++++        

        // +++++++++++++++++++++ Affichage Liste des Clients +++++++++++++++++++++++++++++++++++++++++++++++++++++++++

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
                Cli.ClientPro = Convert.ToBoolean(Result["ClientProfessionel"]);
                Cli.AdressFact = Convert.ToString(Result["AdressFacturClient"]);
                Cli.AdressLiv = Convert.ToString(Result["AdressLivraisonClient"]);
                Cli.IdComm = Convert.ToInt32(Result["IdCommercial"]);

                Liste.Add(Cli);
            }
            Connex.Close();
            return Liste;
        }

        // +++++++++++++++++++++ Affichage d'un seul Client +++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public Client Find(int Id)
        {
            Client Enreg = new Client();
            SqlConnection Connex = new SqlConnection("server=.; database=Village_Green; integrated security= true");
            Connex.Open();

            SqlCommand Reqt = new SqlCommand("select * from stg07.Client where IdClient = @p1", Connex);
            Reqt.Parameters.AddWithValue("@p1", Id);

            SqlDataReader Result = Reqt.ExecuteReader();

            if (Result.Read())
            {
                Enreg.Id = Convert.ToInt32(Result["IdClient"]);
                Enreg.NomClient = Convert.ToString(Result["NomClient"]);
                Enreg.ClientPro = Convert.ToBoolean(Result["ClientProfessionel"]);
                Enreg.AdressFact = Convert.ToString(Result["AdressFacturClient"]);
                Enreg.AdressLiv = Convert.ToString(Result["AdressLivraisonClient"]);
                Enreg.IdComm = Convert.ToInt32(Result["IdCommercial"]);
            }

            return Enreg;
        }


        // +++++++++++++++++++++ Ajout d'un Client +++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void Insert(Client Cli)
        {
            SqlConnection Connex = new SqlConnection("server=.; database=Village_Green; integrated security= true");
            Connex.Open();

            SqlCommand Reqt = new SqlCommand("insert into stg07.Client (NomClient, ClientProfessionel, AdressFacturClient, AdressLivraisonClient, IdCommercial) values(@p1, @p2, @p3, @p4, @p5)", Connex);
            Reqt.Parameters.AddWithValue("@p1", Cli.NomClient);
            Reqt.Parameters.AddWithValue("@p2", Cli.ClientPro);
            Reqt.Parameters.AddWithValue("@p3", Cli.AdressFact);
            Reqt.Parameters.AddWithValue("@p4", Cli.AdressLiv);
            Reqt.Parameters.AddWithValue("@p5", Cli.IdComm);

            Reqt.ExecuteNonQuery();
            Connex.Close();
        }

        // +++++++++++++++++++++ Modification d'un Client ++++++++++++++++++++++++++++++++++++++++++++++++++
        public void Update(Client Cli)
        {
            SqlConnection Connex = new SqlConnection("server=.; database=Village_Green; integrated security= true");
            Connex.Open();

            SqlCommand Reqt = new SqlCommand("update stg07.Client set NomClient=@p2, ClientProfessionel=@p3, AdressFacturClient=@p4, AdressLivraisonClient=@p5, IdCommercial=@p6 where IdClient=@p1", Connex);
            Reqt.Parameters.AddWithValue("@p1", Cli.Id);
            Reqt.Parameters.AddWithValue("@p2", Cli.NomClient);
            Reqt.Parameters.AddWithValue("@p3", Cli.ClientPro);
            Reqt.Parameters.AddWithValue("@p4", Cli.AdressFact);
            Reqt.Parameters.AddWithValue("@p5", Cli.AdressLiv);
            Reqt.Parameters.AddWithValue("@p6", Cli.IdComm);

            Reqt.ExecuteNonQuery();
            Connex.Close();

        }

        // +++++++++++++++++++++ Suppression d'un Client +++++++++++++++++++++++++++++++++++++++++++++++++++
        public void Delete(Client Cli)
        {
            SqlConnection Connex = new SqlConnection("server=.; database=Village_Green; integrated security= true");
            Connex.Open();

            SqlCommand Reqt = new SqlCommand("delete from stg07.Client where IdClient = @p1", Connex);
            Reqt.Parameters.AddWithValue("@p1", Cli.Id);

            Reqt.ExecuteNonQuery();
            Connex.Close();

        }

    }
}
