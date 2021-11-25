using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Rentals.Models
{
    public class Customer
    {
        //Il CLIENTE ha:
        //- Nome,
        //- Cognome, 
        //- Codice fiscale
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Code { get; set; } //codice fiscale

        public override string ToString()
        {
            return $"[{Code}] - {FirstName} {LastName}";
        }
    }
}
