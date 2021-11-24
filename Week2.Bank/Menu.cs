using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
