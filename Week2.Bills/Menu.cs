using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Bills
{
    internal class Menu
    {
        //Menu 
        //L'utente sceglie cosa fare
        //Intercetto la scelta dell'utente e in base
        //alla scelta, verrà eseguito del codice.

        static internal void Start()
        {
            bool exit = true;

            do
            {
                Console.WriteLine("**** Menu ****" +
                    "\n[1] Calcola e stampa la tua bolletta" +
                    "\n[2] Visualizza le tue bollette" +
                    "\n[3] Esci");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        //Metodo che calcola e stampa la bolletta
                        GetBill();
                        break;

                    case '2':
                        //Metodo per recuperare le bollette di un utente
                        FetchBills();
                        break;

                    case '3':
                        exit = false;
                        Console.WriteLine("\nArrivederci!");
                        break;

                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (exit);
        }

        private static void FetchBills()
        {
            //chiedo codice fiscale
            string code = GetInfo("codice fiscale");

            //controllo se è presente tra i miei codici
            bool exists = BillsManager.CheckCode(code);

            //se c'è
            if (exists)
            {
                //recupero le bollette
                List<string> bills = BillsManager.LoadBills(code);

                //e le stampo
                PrintBills(bills);
            }
            else
            {
                Console.WriteLine("Non c'è un utente con questo codice fiscale\n");
            }
        }

        private static void PrintBills(List<string> bills)
        {
            //se ci sono elementi nella lista (ovvero strighe contenenti i dati delle bollette)
            if (bills.Count > 0)
            {
                //stampo le stringhe
                foreach (string bill in bills)
                    Console.WriteLine(bill);
            }
            else //altrimenti, se non ci sono bollette di quell'utente
            {
                Console.WriteLine("Non ci sono elementi da visualizzare");
            }
        }

        private static void GetBill()
        {
            //chiedo codice fiscale all'utente
            //utente lo digita 

            //string info;
            //do
            //{
            //    Console.WriteLine("Inserisci il tuo codice fiscale");
            //    info = Console.ReadLine();

            //} while (string.IsNullOrEmpty(info));

            string code = GetInfo("codice fiscale");

            //verifico che codice fiscale è nell'array
            bool exists = BillsManager.CheckCode(code);

            //se c'è...
            if (exists) //se è true
            {
                //chiedere dati all'utente
                double kWh = GetkWh();

                string firstName = GetInfo("nome");

                string lastName = GetInfo("cognome");

                //calcolo la bolletta
                decimal amount = BillsManager.GetAmount(kWh);

                //stampare a video la bolletta con le informazioni che ha inserito l'utente (sopra)
                Console.WriteLine($"\nBolletta di {firstName} {lastName} " +
                    $"[{code}] - {kWh} kW/h consumati - {amount} euro\n");

                //salvare la bolletta su file .txt
                //in coda
                BillsManager.SaveBill(code, kWh, firstName, lastName, amount);
            }
            else
            {
                Console.WriteLine("Cliente non trovato.\n");

            }

        }

        //Metodi per recuperare l'input utente
        private static string GetInfo(string message)
        {
            string info;
            do
            {
                Console.Write($"\nInserisci il tuo {message}:");
                info = Console.ReadLine().ToUpper();

            } while (string.IsNullOrWhiteSpace(info));

            return info;
        }

        private static double GetkWh()
        {
            double kWh;

            do
            { 
                Console.Write($"\nInserisci i kWh consumati: ");
            }
            while (!double.TryParse(Console.ReadLine(), out kWh));

            return kWh;
        }
    }
}
