using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Rentals.Models
{
    public class Car : Vehicle
    {
        //L'AUTOMOBILE ha anche:
        //- numero di posti
        public int Seats { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" n. posti: {Seats}";
        }
    }
}
