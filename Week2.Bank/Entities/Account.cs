using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Bank.Entities
{
    public class Account
    {
        public int Number { get; set; } //numero di conto -> int
        public decimal Balance { get; set; } //saldo -> decimal
        public Customer Customer { get; set; }  //cliente 
    }
}
