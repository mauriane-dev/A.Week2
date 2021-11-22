using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Bills
{
    internal class BillsManager
    {
        static string[] codes = new string[] { "RSSMRA58T43S234B", "VRDMRC80E45R321A" };
        const decimal FixedFee = 40; //quota fissa
        const string path = @"C:\Users\Utente\Desktop\A.Week2\Week2\Week2.Bills\bills.txt";


        internal static bool CheckCode(string code)
        {
            //if (codes.Contains(code))
            //    return true;

            ////fuori dall'if
            //    return false;

            return codes.Contains(code);

            //foreach (string c in codes)
            //{
            //    if (c == code)
            //        return true;
            //}

            //return false;
        }

        internal static decimal GetAmount(double kWh)
        {
            return FixedFee + (decimal)(kWh * 10);
        }

        internal static void SaveBill(string code, double kWh, string firstName, string lastName, decimal amount)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"Codice fiscale {code} - Nome: {firstName} Cognome: {lastName} " +
                    $"kW/h consumati {kWh} Totale: {amount} euro");
            }
        }

        internal static List<string> LoadBills(string code)
        {
            //Inizializzo una lista di stringhe vuota
            List<string> bills = new List<string>();

            //NOTA: Usando la collection List non ho bisogno di sapere dall'inizio quanti elementi deve
            //contenere perchè posso aggiungere dinamicamente elementi. 

            using (StreamReader sr = new StreamReader(path))
            {
                string allBills = sr.ReadToEnd(); //leggo tutto il contenuto del file

                //con Split sulla stringa che contiene tutto il contenuto del file
                //ottengo un array contentente le righe
                //=> ogni elemento dell'array sarà una riga del file di testo
                string[] rows = allBills.Split("\r\n");

                //ciclo sull'array di stringhe, ovvero di righe del file di testo
                for (int i = 0; i < rows.Length; i++)
                {
                   //se l'i-esimo elemento dell'array, che coincide con una riga del file, contiene il codice fiscale, 
                   //la aggiungo alla lista di stringhe inizializzata in alto 
                    if (rows[i].Contains(code))
                        bills.Add(rows[i]);
                    //altrimenti va avanti con il for
                }
            }

            return bills; //mi restituisce la lista di stringhe
        }
    }
}