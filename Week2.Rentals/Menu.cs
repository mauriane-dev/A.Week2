using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Rentals.Models;

namespace Week2.Rentals
{
    internal class Menu
    {
        internal static void Start()
        {
            bool exit = true;
            do
            {
                Console.WriteLine("\n***** Menu ***** " +
                "\n[1] Visualizzare tutti i noleggi, con i dati del veicolo e del cliente" +
                "\n[2] Visualizzare i noleggi di un certo veicolo" +
                "\n[3] Visualizzare i dettagli di un certo noleggio" +
                "\n[4] Inserire un nuovo noleggio" +
                "\n[5] Data una targa, calcolare il totale in euro dei noleggi" +
                "\n[6] Ricavare il totale in euro dei noleggi di automobili" +
                "\n[Q] Esci");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        //Visualizzare tutti i noleggi, con i dati del veicolo e del cliente
                        FetchAllRentals();
                        break;
                    case '2':
                        FetchRentalsByVehicle();
                        break;
                    case '3':
                        FetchRentalsById();
                        break;
                    case '4':
                        AddNewRental();
                        break;
                    case '5':
                        break;
                    case '6':

                        break;
                    case 'Q':
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
            while (exit);
        }

        private static void FetchRentalsById()
        {
            int id = GetNumber("ID");

            Rental rental = RentalsManager.GetRentalById(id);

            if (rental != null)
                Console.WriteLine(rental);
            else
                Console.WriteLine("Non c'è un noleggio con questo identificativo");

        }

        private static void AddNewRental()
        {
            string plate;
            Vehicle vehicle;

            //Stampo i veicoli disponibili
            Console.WriteLine("Quale veicolo vuoi noleggiare?");
            List<Vehicle> vehicles = RentalsManager.FetchVehicles();

            foreach (var v in vehicles)
            {

                Console.WriteLine(v.ToString());
            }

            do
            {
                plate = GetData("targa del veicolo che vuoi noleggiare");
                vehicle = RentalsManager.GetVehicleByPlate(plate);

                if (vehicle == null)
                    Console.WriteLine("Non hai inserito la targa di un veicolo disponibile, riprova!");
            }
            while (vehicle == null);

            int days;
            DateTime date;

            Console.WriteLine("Inserire la data di inizio del noleggio");
            while (!DateTime.TryParse(Console.ReadLine(), out date) || date <= DateTime.Today)
            {
                Console.WriteLine("IHai inserito un formato scorretto di data o una data precedente a oggi!");
            }

            do
            {
                Console.WriteLine("Per quanti giorni vuole noleggiare il veicolo?");
            } while (!int.TryParse(Console.ReadLine(), out days) || days <= 0);

            bool avalaible = RentalsManager.IsAvailable(plate, days, date);

            if (avalaible)
            {
                string code = GetData("codice fiscale del cliente");

                var customer = RentalsManager.GetCustomerByCode(code);

                if (customer != null)
                {


                    decimal invoice = vehicle.DailyCost * days;
                    Console.WriteLine($"Il costo del noleggio è: {invoice}.");

                    Rental rental = new Rental()
                    {
                        CustomerCode = code,
                        VehiclePlate = plate,
                        Days = days,
                        Invoice = invoice,
                        StartDate = date
                    };

                    bool isAdded = RentalsManager.AddRental(rental);

                    if (isAdded)
                        Console.WriteLine($"Operazione completata. Noleggio registrato: {rental} " +
                            $"del veicolo {vehicle} \nper: {customer}");


                }
            }
            else
            {
                Console.WriteLine("Veicolo non noleggiabile");
            }
        }

        //Visualizzare tutti i noleggi, con i dati del veicolo e del cliente
        private static void FetchAllRentals()
        {
            //Recuperare tutti i noleggi 
            List<Rental> rentals = RentalsManager.FetchRentals();

            //Per ogni noleggio, recupero le informazioni sul veicolo noleggiato e sul cliente
            foreach (Rental rental in rentals)
            {
                Vehicle vehicle = RentalsManager.GetVehicleByPlate(rental.VehiclePlate);

                Customer customer = RentalsManager.GetCustomerByCode(rental.CustomerCode);

                //stampo tutto: info sul noleggio, info sul veicolo noleggiato, info sul cliente che ha noleggiato quel veicolo
                Console.WriteLine($"Noleggio: {rental}" +
                    $"\nVeicolo noleggiato: {vehicle}" +
                    $"\nCliente: {customer}\n");
            }
        }

        private static void FetchRentalsByVehicle()
        {
            string plate;
            Vehicle vehicle;

            //do
            //{
            //    plate = GetData("targa");
            //    vehicle = RentalsManager.GetVehicleByPlate(plate);

            //    if (vehicle == null)
            //        Console.WriteLine("Non hai inserito la targa di un veicolo disponibile, riprova!");
            //}
            //while (vehicle == null);

            //List<Rental> rentals = RentalsManager.FetchRentals(); //recupero la lista di noleggi

            ////TODO: Se la lista è vuota, nessun noleggio dispoibile
            //foreach (Rental rental in rentals) //per ogni noleggio nella lista di noleggi
            //{
            //    if (rental.VehiclePlate == vehicle.Plate) //Se la targa è quella scritta dall'utente
            //        Console.WriteLine($"Noleggio {rental}"); //stampo le info sul noleggio di quel veicolo
            //}

            do
            {
                plate = GetData("targa");
            }
            while (string.IsNullOrWhiteSpace(plate));

           List<Rental> rentalsByPlate = RentalsManager.FetchRentalsByPlate(plate); //recupero la lista di noleggi

            if (rentalsByPlate.Count != 0)
            foreach (Rental rental in rentalsByPlate) //per ogni noleggio nella lista di noleggi
            {
                    Console.WriteLine($"Noleggio {rental}"); //stampo le info sul noleggio di quel veicolo
            }
            else
            {
                Console.WriteLine("Questo veicolo non è stato mai noleggiato");
            }
        
        }

        private static string GetData(string info)
        {
            string plate;

            do
            {
                Console.Write($"Inserisci la {info}: ");
                plate = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(plate));

            return plate;
        }

        private static int GetNumber(string info)
        {
            int id;

            do
            {
                Console.Write($"Inserisci {info}: ");
            }
            while (!int.TryParse(Console.ReadLine(), out id));

            return id;
        }
    }
}