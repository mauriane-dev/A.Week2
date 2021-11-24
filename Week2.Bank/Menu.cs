using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Bank.Entities;

namespace Week2.Bank
{
    internal class Menu
    {
        internal static void Start()
        {
            char choice;

            do
            {
                Console.WriteLine("Scegli un'opzione:" +
                    "\n[1] Creare un nuovo conto" +
                    "\n[2] Versare su un conto" +
                    "\n[3] Prelevare da un conto" +
                    "\n[4] Visualizzare il saldo" +
                    "\n[5] Chiudere un conto" +
                    "\n[Q] Esci");

                //recupero scelta utente -> choice
                choice = Console.ReadKey().KeyChar;

                //choice viene valutata nello switch
                switch (choice)
                {
                    case '1':
                        AddAccount();
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case 'Q':
                        Console.WriteLine("Operazioni concluse. Arrivederci!");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (choice != 'Q');
        }

        private static void AddAccount()
        {
            //Recuperiamo i dati del cliente (nome e cognome)
            string firstName = GetData("nome");

            string lastName = GetData("cognome");

            //Generiamo un codice cliente random 
            string customerCode = AccountsManager.GenerateCustomerCode();

            //Generiamo un numero di conto 
            int number = AccountsManager.GenerateAccountNumber();

            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Code = customerCode
            };

            //Associamo i dati al nuovo conto
            Account newAccount = new Account()
            {
                Number = number,
                Customer = customer
            };

            //Aggiungiamo alla lista di conti 
            bool isAdded = AccountsManager.AddNewAccount(newAccount);

            if (isAdded)
                Console.WriteLine($"Conto n. {newAccount.Number} aggiunto per il cliente " +
                    $"{newAccount.Customer.Code} {newAccount.Customer.FirstName} " +
                    $"{newAccount.Customer.LastName}");
            else
                Console.WriteLine("Ops... qualcosa è andato storto");

        }

        #region Metodi per recuperare input utente banchiere
        private static string GetData(string message)
        {
            string info;
            do
            {
                Console.WriteLine($"Inserisci il {message} del cliente");
                info = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(info));

            return info;
        }
        #endregion
    }
}
