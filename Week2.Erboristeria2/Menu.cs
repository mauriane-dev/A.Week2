using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Erboristeria2
{
    internal class Menu
    {
        internal static void Start()
        {
            bool exit = true;

            do
            {
                Console.WriteLine("[Menu] " +
                    "\n[1] Visualizza i dettagli del prodotto con prezzo massimo" +
                    "\n[2] Visualizza i dettagli del prodtto con un certo" +
                    "codice" +
                    "\n[3] Visualizza i prodotti di una categoria" +
                    "\n[4] Aumentare il prezzo di un prodotto" +
                    "\n[5] Aggiungere un nuovo prodotto" +
                    "\n[6] Visualizzare i prodotti di una certa fascia di prezzo" +
                    "\n[7] Eliminare un prodotto dallo store" +
                    "\n[Q] Esci");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        //Aggiungere un nuovo prodotto
                        AddNewProduct();
                        break;
                    case '6':
                        break;
                    case '7':
                        break;
                    case 'Q':
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }

            } while (exit);
        }

        private static void AddNewProduct()
        {
            //Utente inserisce il codice
            string code = GetInfo("codice");

            //TODO: Inserire un controllo per verificare che non ci sia già un prodotto con questo codice 
            //nella lista di prodotti 
            //Cercare nella lista di prodotti se c'è un prodotto con questo codice
            //con un metodo della clase ErboristeriaManager 
            //Il metodo lo chiamo qui.

            //Se c'è -> non procedo con l'aggiunta -> "Esiste già un prodotto con questo codice"

            //Altrimenti (se non c'è già un prodotto con questo codice scritto dall'utente)
            //-> chiedo le altre informazioni sul nuovo prodotto da aggiungere:

            //Utente inserisce il nome
            string name = GetInfo("nome");

            //Utente inserisce il prezzo
            decimal price = GetPrice();

            //Utente inserisce la categoria
            int category = GetCategory();

            //Aggiungere il prodotto alla lista di prodotti
            //Chiamo un metodo dell'ErboristeriaManager che fa solo l'aggiunta del prodotto

        }

        private static string GetInfo(string message)
        {
            string info;
            do
            {
                Console.WriteLine($"Inserisi il {message}");
                info = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(info));

            return info; //conterrà ciò che ha scritto l'utente
        }

        private static decimal GetPrice()
        {
            decimal price;
            do
            {
                Console.WriteLine("Inserisci il prezzo");
            } while (!decimal.TryParse(Console.ReadLine(), out price));
            //TODO: Aggiungere un controllo per cui il prezzo non può essere minore o uguale a 0

            return price;
        }

        private static int GetCategory()
        {
            int category;
            do
            {
                Console.WriteLine("Scegli la categoria:" +
                    "\n1 - Cosmetico" +
                    "\n2 - Infuso" +
                    "\n3 - Intragratore");
            } while (!int.TryParse(Console.ReadLine(), out category) || category < 1 || category > 3);

            return category;
        }
    }
}
