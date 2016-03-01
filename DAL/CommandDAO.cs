using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class CommandDAO
    {
        // +++++++++++++++++++++ Partie 1 : Interrogation (Saisie & Affichage) ++++++++++++++++++++++++++++++++++++++++ 
        // ----> Liste des commandes pour un client (date, ref client, montant) :
       
        public List<Command> CommandCli(int IdCli)
        {
            List<Command> Liste = new List<Command>();
            SqlConnection Connex = new SqlConnection("server=.; database=Village_Green; integrated security= true");
            Connex.Open();

            SqlCommand Reqt = new SqlCommand("Select * from stg07.COMMANDE where IdClient = @p1", Connex);
            Reqt.Parameters.AddWithValue("@p1", IdCli);

            SqlDataReader Result = Reqt.ExecuteReader();

            while (Result.Read())
            {
                Command Com = new Command();
                Com.IdCommand = Convert.ToInt32(Result["IdCommand"]);
                Com.DateCom = Convert.ToString(Result["DateCommande"]);
                Com.EtatPrepCom = Convert.ToString(Result["EtatPreparationCommand"]);
                Com.TotalHT = Convert.ToString(Result["TotalHT"]);
                Com.TypeReglmt = Convert.ToString(Result["TypeReglement"]);
                Com.DateReglmt = Convert.ToString(Result["DateReglement"]);
                Com.EtatReglmt = Convert.ToString(Result["EtatReglement"]);
                Com.Reduct = Convert.ToDecimal(Result["Reduction"]);
                Com.IdClient = Convert.ToInt32(Result["IdClient"]);

                Liste.Add(Com);
            }
            Connex.Close();
            return Liste;
        }

        





    }



}
