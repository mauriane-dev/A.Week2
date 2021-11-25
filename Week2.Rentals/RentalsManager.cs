using Week2.Rentals.Models;

namespace Week2.Rentals
{
    public static class RentalsManager
    {
        #region Dati di prova
        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer()
            {
                FirstName = "Mario",
                LastName = "Rossi",
                Code= "RSSMRA76A01L219J"
            },
            new Customer()
            {
                FirstName = "Marco",
                LastName = "Rossi",
                Code= "RSSMRC80A01L219M"
            }
        };

        public static List<Vehicle> Vehicles = new List<Vehicle>()
        {
            new Car
            {
                Plate = "AX743HJ",
                Model = "Fiat Panda",
                DailyCost = 55,
                Seats = 4
            },
            new Car
            {
                Plate = "GJ924LR",
                Model = "Fiat Punto",
                DailyCost = 60,
                Seats = 5
            },
            new Car
            {
                Plate = "UY248QW",
                Model = "Fiat Tipo",
                DailyCost = 65,
                Seats = 5
            },
            new Car
            {
                Plate = "GK823NB",
                Model = "Smart fortwo coupè",
                DailyCost = 70,
                Seats = 2
            },
            new Van
            {
                Plate = "TY467WE",
                Model = "Fiat Ducato",
                DailyCost = 125,
                Capacity = 750
            },
            new Van
            {
                Plate = "GH567KU",
                Model = "Fiat Fiorino",
                DailyCost = 100,
                Capacity = 450
            }
        };

        public static List<Rental> Rentals = new List<Rental>()
        {
            new Rental()
            {
                Id = 1,
                StartDate = new DateTime(2021,11,22),
                Days = 5,
                Invoice = 275,
                VehiclePlate = "AX743HJ",
                CustomerCode = "RSSMRA76A01L219J"
            },
            new Rental()
            {
                Id = 2,
                StartDate = new DateTime(2021,11,27),
                Days = 2,
                Invoice = 120,
                VehiclePlate = "GJ924LR",
                CustomerCode = "RSSMRA76A01L219J"
            },
            new Rental()
            {
                Id = 3,
                StartDate = new DateTime(2020,6,7),
                Days = 1,
                Invoice = 65,
                VehiclePlate = "UY248QW",
                CustomerCode = "RSSMRA76A01L219J"
            },
            new Rental()
            {
                Id = 4,
                StartDate = new DateTime(2021,10,10),
                Days = 1,
                Invoice = 70,
                VehiclePlate = "AX743HJ",
                CustomerCode = "RSSMRC80A01L219M"
            },
            new Rental()
            {
                Id = 5,
                StartDate = new DateTime(2021,11,22),
                Days = 5,
                Invoice = 625,
                VehiclePlate = "TY467WE",
                CustomerCode = "RSSMRC80A01L219M"
            },
            new Rental()
            {
                Id = 6,
                StartDate = new DateTime(2020,4,19),
                Days = 3,
                Invoice = 600,
                VehiclePlate = "GH567KU",
                CustomerCode = "RSSMRC80A01L219M"
            },
        };

        internal static Rental GetRentalById(int id)
        {
            foreach (var r in Rentals)
                if (r.Id == id)
                    return r;

            return null;
        }


        #endregion

        //Metodo che verifica se il veicolo che vorrebbe noleggiare il cliente è disponibile
        //andando a verificare se c'è già un noleggio programmato per quel veicolo nei giorni
        //in cui lo vorrebbe il cliente.
        internal static bool IsAvailable(string plate, int days, DateTime startDate) 
        {
            //startDate è la data da cui il mio cliente vuole noleggiare il veicolo
            //days = giorni per cui il cliente vuole tenersi il veicolo in noleggio
            //plate = targa del veicolo che il mio cliente vuole noleggiare

            //calcolo la data in cui il mio cliente mi restiuirebbe il veicolo 
            DateTime endDate = startDate.AddDays(days);

            foreach (Rental r in Rentals)
            {
                DateTime storedEndDate = r.StartDate.AddDays(r.Days);
                if (r.VehiclePlate == plate && storedEndDate > startDate && endDate < r.StartDate )
                {
                    //esempio: 
                    //data di fine noleggio = 29/11 e data di inizio in cui lo vuole il mio cliente = 27/11
                    //=> condizione 2 = false 
                    //=> non entra nell'if
                    //data di fine del noleggio del mio cliente = 30/11 e data di inizio del noleggio in lista = 27/11
                    //=> condizione 3 = false
                    //=> non entra nell'if

                    //se sono verificate contemporanemtente queste condizioni:

                    //- la targa scritta dall'utente coincide con quella di un veicolo che è in lista di noleggi
                    //- la data di fine di un noleggio in lista è successiva alla data di inizio del noleggio
                    //che si vuole registrare
                    //- la data di fine del noleggio che si vuole registrare è precedente alla data di inizio
                    //del noleggio già in lista
                    
                    //il veicolo non è disponibile

                    return false; 
                }
            }

            //se non entra mai nell'if => vuol dire che una delle 3 è falsa 
            //anche se la targa coincide, ma una delle altre due condizioni è falsa => non entra

            //se non entra vuol dire che non c'è un noleggio nella lista di noleggi che ostacola la registrazione
            //di un nuovo noleggio su quel veicolo
            //=> veicolo disponibile:

            return true; 
        }

        internal static List<Vehicle> FetchVehicles()
        {
            return Vehicles;
        }
        internal static Customer GetCustomerByCode(string customerCode)
        {
            foreach (var c in Customers)
                if (c.Code == customerCode)
                    return c;

            return null;
        }

        internal static Vehicle GetVehicleByPlate(string vehiclePlate)
        {
            foreach (var v in Vehicles)
                if (v.Plate == vehiclePlate)
                    return v;

            return null;
        }

        internal static List<Rental> FetchRentals()
        {
            return Rentals;
        }

        internal static List<Rental> FetchRentalsByPlate(string plate)
        {
            List<Rental> rentalsByPlate = new List<Rental>();

            foreach (var r in Rentals)
                if (r.VehiclePlate == plate)
                    rentalsByPlate.Add(r);

            return rentalsByPlate;
        }

        internal static bool AddRental(Rental rental)
        {
            if (rental != null)
            {
                int newId;
                if (Rentals.Count > 0)
                    newId = Rentals[Rentals.Count - 1].Id + 1;
                else newId = 1;

                rental.Id = newId;

                Rentals.Add(rental);
                return true;
            }

            return false;
        }
    }
}