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
        static List<Account> accounts = new List<Account>();


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
            //Prendiamo l'ultimo conto della lista e il suo numero
            //di conto e sommiamo 1.
            int num = accounts.Count; //numero di conti
            
            int newAccountNumber;

            if (num > 0)
            {
                //per esempio, ci sono 3 conti => num = 3
                //recupero il conto con l'ultimo indice => 2
                Account account = accounts[num - 1];

                //recupero il numero di conto dell'ultimo conto in lista
                int accountNumber = account.Number;

                newAccountNumber = accountNumber + 1;
            }
            else
            {
                newAccountNumber = 1;
            }
            return newAccountNumber;

            //TODO: Provare a compattar il tutto
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
    }
}
