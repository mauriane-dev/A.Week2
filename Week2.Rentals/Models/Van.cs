using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Rentals.Models
{
    public class Van : Vehicle
    {
        //Il FURGONE ha anche:
        //- capacità di carico espressa in kg.
        public int Capacity { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Capacità [Kg]: {Capacity}";
        }
    }
}
