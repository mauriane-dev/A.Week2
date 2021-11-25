using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Rentals.Models
{
    public class Rental
    {
        //Il NOLEGGIO ha:
        //- Id (identificativo)
        //- Data di inizio,
        //- Numero di giorni
        //- Costo totale,
        //- Codice fiscale del CLIENTE,
        //- Targa del VEICOLO
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int Days { get; set; } //n. di giorni per cui il veicolo viene noleggiato
        public decimal Invoice { get; set; } //fattura -> quanto deve pagare il cliente
        public string VehiclePlate { get; set; }
        public string CustomerCode { get; set; }

        public override string ToString()
        {
            return $"[{Id}] A partire da: {StartDate.ToShortDateString()} per: {Days} giorni - Totale: {Invoice} euro";
        }
    }
}
