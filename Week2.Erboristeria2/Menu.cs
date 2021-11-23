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
                        //Visualizzare i prodotti di una certa fascia di prezzo
                        FilterProductsByPrice();
                        break;
                    case '7':
                        //Eliminare un prodotto dallo store
                        DeleteProduct();
                        break;
                    case 'Q':
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }

            } while (exit);
        }

        private static void DeleteProduct()
        {
            //Utente inserisce il codice
            string code = GetInfo("codice del prodotto da eliminare");

            //Cerco nella lista di prodotti se c'è un prodotto con questo codice
            Product product = ErboristeriaManager.GetByCode(code);

            if (product != null)
            {
                //se c'è, lo posso cancellare
                bool isDeleted = ErboristeriaManager.Delete(product);

                if (isDeleted)
                {
                    Console.WriteLine("Prodotto eliminato correttamente");
                }
                else
                {
                    Console.WriteLine("Rimozione non completata");
                }
            }
            else
            {
                //se non c'è
                Console.WriteLine("Non c'è un prodotto con questo codice");
            }
        }

        private static void AddNewProduct()
        {
            //Utente inserisce il codice
            string code = GetInfo("codice");

            //verificare che non ci sia già un prodotto con questo codice 
            Product product = ErboristeriaManager.GetByCode(code);

            if (product != null)
            {
                //Se c'è -> non procedo con l'aggiunta -> "Esiste già un prodotto con questo codice"
                Console.WriteLine("Esiste già un prodotto con questo codice");
            }
            else
            {
                //Altrimenti (se non c'è già un prodotto con questo codice scritto dall'utente)
                //-> chiedo le altre informazioni sul nuovo prodotto da aggiungere:

                //Utente inserisce il nome
                string name = GetInfo("nome");

                //Utente inserisce il prezzo
                decimal price = GetPrice("");

                //Utente inserisce la categoria
                int category = GetCategory();

                //Aggiungere il prodotto alla lista di prodotti
                //Chiamo un metodo dell'ErboristeriaManager che fa solo l'aggiunta del prodotto

                //Product newProduct = new Product()
                //{
                //    Code = code,
                //    Name = name,
                //    Category = (CategoryEnum)category,
                //    Price = price
                //};

                Product newProduct = new Product(code, name, price, (CategoryEnum)category);

                bool isAdded = ErboristeriaManager.AddProduct(newProduct);

                if (isAdded)
                {
                    Console.WriteLine("Prodotto aggiunto correttamente");
                }
                else
                {
                    Console.WriteLine("Aggiunta non completata");
                }
            }
        }

        private static void FilterProductsByPrice()
        {
            Console.WriteLine("Scegli la fascia di prezzo di cui vuoi visualizzare i prodotti");

            decimal minPrice = GetPrice("minimo");

            decimal maxPrice = 0;

            while (maxPrice < minPrice)
            {
                maxPrice = GetPrice("massimo");
            }

            List<Product> filteredProducts = ErboristeriaManager.FetchProducts(minPrice, maxPrice);

            if (filteredProducts.Count > 0)
            {
                foreach (Product p in filteredProducts)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            else
            {
                Console.WriteLine("Non ci sono prodotti in questa fascia di prezzo");
            }
        }


        private static string GetInfo(string message)
        {
            string info;
            do
            {
                Console.Write($"Inserisi il {message}: ");
                info = Console.ReadLine().ToUpper();
            } while (string.IsNullOrWhiteSpace(info));

            return info; //conterrà ciò che ha scritto l'utente
        }

        private static decimal GetPrice(string message)
        {
            decimal price;
            do
            {
                Console.Write($"Inserisci il prezzo {message}: ");
            } while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0);

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
