using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Rentals.Models
{
    public class Vehicle
    {
        // Il VEICOLO è caratterizzato da:
        // - Targa
        // - Modello 
        // - Tariffa giornaliera

        public string Plate { get; set; }
        public string Model { get; set; }
        public decimal DailyCost { get; set; } //costo del veicolo per ogni giornata di noleggio

        public override string ToString()
        {
            return $"{Plate} - {Model}";
        }
    }
}
