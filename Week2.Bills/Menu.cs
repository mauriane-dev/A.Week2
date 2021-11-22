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
                        //...
                        break;

                    case '3':
                        exit = false;
                        Console.WriteLine("Arrivederci!");
                        break;

                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (exit);
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

                //stampare a video la bolletta con le informazioni

                //salvare la bolletta su file .txt
                //in coda
            }
            else
            {
                //se non c'è: cliente non trovato
            }

        }

        //Metodi per recuperare l'input utente
        private static string GetInfo(string message)
        {
            string info;
            do
            {
                Console.WriteLine($"Inserisci il tuo {message}:");
                info = Console.ReadLine().ToUpper();

            } while (string.IsNullOrEmpty(info));

            return info;
        }
    }
}
