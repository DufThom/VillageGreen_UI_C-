using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Mail_Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Contrôle que l'adresse Mail saisie est valide, ex. de mail valide : "x x @ x x . x x " 
            // soit 2 caractères mini avant l'@, 2 caractères mini entre l'@ et le ".", et 2 caractères mini après le "."
            // ^ : début de la ligne
            // [a - zA - Z]+ : une lettre (au moins une)
            // [a-zA-Z0-9\\._-]* : une lettre ou un chiffre ou un "." ou un "_" ou un "-" autant de fois que l'on veut (0 à n)
            // [a-zA-Z0-9]+ : une lettre ou un chiffre(au moins 1)
            // @ : le symbole @ (obligatoire)
            // [a-zA-Z]+ : une lettre(au moins une)
            // [a-zA-Z0-9\\._-]* : une lettre ou un chiffre ou un "." ou un "_" ou un "-" autant de fois que l'on veut (0 à n)
            // [a-zA-Z0-9]+ : une lettre ou un chiffre(au moins 1)
            // \\. : un "." (obligatoire)
            // [a-zA-Z]{2,4} : de 2 à 4 lettres
            // $ : fin de ligne

            Console.WriteLine("Entrez une adresse Mail : \n");
            string Mail = Convert.ToString(Console.ReadLine()); // Adresse complète
            string m = Cont_Mail(Mail);
            Console.WriteLine(m);

            Console.ReadLine();

        }

        public static string Cont_Mail(string Mail)
        {
            string[] Mail1; // mot à Gauche de l'@
            string[] Mail2; // mot après l'@ 
            char Arob = '@';
            char Point = '.';
            string Mess = "";

            if (Mail.IndexOf(Arob) == -1)
                {
                Mess = "il manque l'@";
                }
                else
                {
                    Mail1 = Mail.Split(Arob);
                    if (Mail1[1].IndexOf(Point) == -1)
                    {
                        Mess = ("Manque le Point ");
                    }
                    else
                    {
                        Mail2 = Mail1[1].Split(Point);
                        //Console.WriteLine("ok");
                        Regex testMail1 = new Regex("^[a-zA-Z0-9]{2,}(([_.-]?)[a-zA-Z0-9])*$");
                        Regex testMail2 = new Regex("^[a-zA-Z0-9]{2,}$");

                        if (!testMail1.IsMatch(Mail1[0]))
                        {
                            Mess = ("vérifiez le mail avant l'@ ");
                        }
                        else
                        {
                            if (!testMail1.IsMatch(Mail2[0]))
                            {
                                Mess = ("vérifiez entre l'@ et le Point ");
                            }
                            else
                            {
                                if (!testMail2.IsMatch(Mail2[1]))
                                {
                                    Mess = ("vérifiez après le Point");
                                }
                                else
                                {
                                    Mess = "OK";
                                    //Console.WriteLine(Mess);
                                    
                                }
                            }

                        }
                    }

                }
            return Mess;
        }

    }
    }

