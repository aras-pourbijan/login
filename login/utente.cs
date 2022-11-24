using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    internal class utente
    {

        public static string userName;

        public static string password;
        public static string conferma;
        public static bool loggedIn = false;
        public static DateTime oraAccesso;
        public static List<DateTime> listaAccessi = new List<DateTime>();

        public void menuStart()
        {

            try
            {
                Console.WriteLine("===============OPERAZIONI==============");
                Console.WriteLine("Scegli l’operazione da effettuare:");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Logout");
                Console.WriteLine("3: Verifica ora e data di login");
                Console.WriteLine("4: Lista degli accessi");
                Console.WriteLine("5: Esci");
                Console.WriteLine("=======================================");
                string scelta = Console.ReadLine();

                if (scelta == "1") { Console.WriteLine("login:");
                    login();}
                else if (scelta == "2") { Console.WriteLine("logout:"); logout(); }
                else if (scelta == "3") { Console.WriteLine("verifica:"); verificadata(); }
                else if (scelta == "4") { Console.WriteLine("Lista degli accecci:"); mostraLista(); }
                else if (scelta == "5") { Console.WriteLine("sei uscita !"); esci(); }
                else { Console.WriteLine("scelta sbagliata! riprova"); menuStart(); }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore:{ex}");
                menuStart();

            }
          
        }

        private static void esci()
        {
            Environment.Exit(0);    
        }

        private void mostraLista()
        {
            Console.WriteLine("--------------lista Accessi --------------");
            foreach (DateTime acesso in listaAccessi)
            {
                Console.WriteLine("**********");
                Console.WriteLine($"acesso:{oraAccesso}");

            }
            Console.WriteLine("------------------------------------------");
            menuStart();
        }

        private void verificadata()
        {
            try
            {
                if (loggedIn)
                {
                    Console.WriteLine($"sei entrato alle {oraAccesso}");
                }

            }
            catch
            {
                Console.WriteLine("non hai fatto login ancora!");
            }
            finally
            {
                menuStart();
            }

            
            
        }

        private void logout()
        {
            if (utente.loggedIn == true)
            {
                userName = "";
                password = "";
                loggedIn = false;


                Console.WriteLine("Ha effettuato il logout.");
                menuStart();
            }
            else
            {
                Console.WriteLine("Non puoi eseguire logout prima di fare login!");
                menuStart();
            }
        }

        private void login()
        {
            if (loggedIn == false) { 
            Console.WriteLine("inserichi username:");
            utente.userName= Console.ReadLine();
            Console.WriteLine("inserichi password:");
            utente.password = Console.ReadLine();
            Console.WriteLine("inserichi di nuovo password:");
            utente.conferma = Console.ReadLine();
            if ((utente.userName != "") && (password == conferma)) {
               loggedIn= true;
                utente.oraAccesso =  DateTime.Now;
                    utente.listaAccessi.Add(oraAccesso);
                Console.WriteLine($"Ciao {userName} ");     

                menuStart();
            }
            else
            {
                Console.WriteLine("riprova! dati non sono corretti!");
                login();
            }
            }
            else
            {
                Console.WriteLine("gia sei dentro !");
                menuStart();
            }
        }
    }
}

