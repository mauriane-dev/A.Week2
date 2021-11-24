using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Bank.Entities;

namespace Week2.Bank
{
    internal class AccountsManager
    {
        private static List<Account> accounts = LoadData();

        private static List<Account> LoadData()
        {
            Customer c1 = new Customer()
            {
                Code = "T1234",
                FirstName = "Mario",
                LastName = "Rossi"
            };

            Customer c2 = new Customer()
            {
                Code = "A12345",
                FirstName = "Marco",
                LastName = "Rossini"
            };

            Account account1 = new Account()
            {
                Number = 1,
                Customer = c1,
                Balance = 1000
            };

            Account account2 = new Account()
            {
                Number = 2,
                Customer = c2,
                Balance = 1400
            };

            List<Account> bankAccounts = new List<Account>()
            {
                account1, account2
            };

            return bankAccounts;

        }

        internal static string GenerateCustomerCode()
        {
            Random random = new Random();

            //Sorteggio un intero tra 65 e 90 che corrispondo alle lettere maiuscole tra A e Z
            int index = random.Next(65, 91); //65-90 -> A-Z

            //converto l'intero in un char
            char letter = Convert.ToChar(index);

            //sorteggio un numero intero sul range degli interi
            int num = random.Next();

            //compongo il codice cliente
            string customerCode = $"{letter}{num}"; //Esempio: otterrò B3456789

            return customerCode;
        }

        internal static int GenerateAccountNumber()
        {
            int newAccountNumber;

            //Prendiamo il numero di conto dell'ultimo elemento conto nella lista 
            //di conti e sommiamo 1 per ottenere il nuovo numero di conti.

            //int num = accounts.Count; //numero di conti, ovvero di elemeneti della lista di conti

            //if (num > 0)
            //{
            //    //per esempio, ci sono 3 conti => num = 3
            //    //recupero il conto con l'ultimo indice => 2
            //    Account account = accounts[num - 1];

            //    //recupero il numero di conto dell'ultimo conto in lista
            //    int accountNumber = account.Number;

            //    newAccountNumber = accountNumber + 1;
            //}
            //else
            //{
            //    newAccountNumber = 1;
            //}

            //Più compatto:
            if (accounts.Count > 0)
                newAccountNumber = accounts[accounts.Count - 1].Number + 1;
            else
                newAccountNumber = 1;

            return newAccountNumber;
        }

        internal static bool AddNewAccount(Account newAccount)
        {
            if (newAccount != null)
            {
                accounts.Add(newAccount);
                return true;
            }

            return false;
        }

        internal static bool PayInto(Account account, decimal amount)
        {
            if (account != null && amount > 0)
            {
                account.Balance += amount;
                return true;
            }
            else
                Console.WriteLine("Non si può procedere con il versamento");

            return false;
        }
        internal static bool WithDrawFrom(Account account, decimal amount)
        {
            if (account != null && amount > 0)
            {
                account.Balance -= amount;
                return true;
            }
            else
                Console.WriteLine("Non si può procedere con il prelievo");

            return false;
        }

        internal static Account GetByNumber(int number)
        {
            foreach (Account account in accounts)
                if (account.Number == number)
                {
                    return account;
                }

            return null;
        }

        internal static bool Delete(Account accountToDelete)
        {
            bool isDeleted = false;

            if (accountToDelete != null)
                isDeleted = accounts.Remove(accountToDelete);

            return isDeleted;
        }
    }
}
