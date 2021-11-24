using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.OOP
{
    internal class Trainee : Employee
    {
        public int Months { get; set; } //durata tirocinio in mesi

        public override void PrintInfo()
        {

            Console.WriteLine($"{FirstName} {LastName} {Role} Mesi di tirocinio: {Months}");
        }
    }
}
