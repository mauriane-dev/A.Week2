using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.OOP
{
    internal class Customer : Person
    {
        public string Company { get; set; }

        public Customer (string firstName, string lastName, string company)
            :base(firstName, lastName)
        {
            Company = company;
        }

        public override void PrintInfo()
        {

            Console.WriteLine($"{FirstName} {LastName} {Company}");
        }
    }
}
