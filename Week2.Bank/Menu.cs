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
                        //versamento
                        PayIntoAccount();
                        break;
                    case '3':
                        WithdrawFromAccount();
                        break;
                    case '4':
                        GetAccountBalance();
                        break;
                    case '5':
                        DeleteAccount();
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
        private static void GetAccountBalance()
        {
            int number;
            do
                Console.Write("Conto di cui vedere il saldo: ");
            while (!int.TryParse(Console.ReadLine(), out number));

            Account account = AccountsManager.GetByNumber(number);

            if (account != null)
                Console.WriteLine($"Il saldo del conto {number} è" +
                    $" {account.Balance}");
            else
                Console.WriteLine($"Conto {number} non esistente");
        }
        private static void PayIntoAccount()
        {
            int number;
            bool isEdited;

            do
                Console.Write("Inserisci il numero di conto su cui versare: ");
            while (!int.TryParse(Console.ReadLine(), out number));

            Account account = AccountsManager.GetByNumber(number);

            if (account != null)
            {
                decimal amount = GetAmount("versare");

                isEdited = AccountsManager.PayInto(account, amount);

                if (isEdited)
                    Console.WriteLine($"Versamento concluso. Il nuovo saldo è:" +
                    $" {account.Balance}");
            }
            else
                Console.WriteLine($"Conto n. {number} non esistente");

            Console.WriteLine();
        }
        private static void WithdrawFromAccount()
        {
            int number;

            do
                Console.Write("Inserisci il numero di conto da cui prelevare: ");
            while (!int.TryParse(Console.ReadLine(), out number));

            Account account = AccountsManager.GetByNumber(number);

            if (account != null && account.Balance > 0)
            {
                decimal amount = 0;
                do
                {
                    amount = GetAmount("prelevare");
                }
                while (amount > account.Balance);

                bool isEdited = AccountsManager.WithDrawFrom(account, amount);

                if (isEdited)
                    Console.WriteLine($"Hai prelevato {amount}. Il nuovo saldo è:" +
                   $" {account.Balance}");
            }
            else
                Console.WriteLine($"Conto n. {number} non esistente o senza disponibilità");

            Console.WriteLine();
        }

        private static void DeleteAccount()
        {
            int number;
            do
                Console.Write("Conto da eliminare: ");
            while (!int.TryParse(Console.ReadLine(), out number));

            Account account = AccountsManager.GetByNumber(number);

            if (account != null)
            {
                bool isDeleted = AccountsManager.Delete(account);
                if (isDeleted) //Se è true
                    Console.WriteLine($"Il conto n. {number} è stato eliminato");
                else
                    Console.WriteLine($"Conto n. {number} non cancellato");
            }
            else Console.WriteLine($"Conto {number} non esistente");
        }

        #region Metodi per recuperare input utente banchiere
        private static decimal GetAmount(string message)
        {
            decimal amount;

            Console.Write($"Importo da {message}: ");
            
            while (!decimal.TryParse(Console.ReadLine(), out amount) ||
                    amount <= 0)
            {
                Console.Write("Inserisci un importo valido:");
            }

            return amount;
        }
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
