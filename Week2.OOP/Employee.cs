using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.OOP
{
    internal class Employee : Person
    {
        //Employee estende Person
        //posso usare i membri public protected internale di Person 

        public RoleEnum Role { get; set; }

        public Employee (string firstName, string lastName, RoleEnum role)
            : base(firstName, lastName)
        {
            Role = role;
        }
        
        public Employee()
        {

        }

        public override void PrintInfo()
        {
            //base.PrintInfo(); //usa l'implementazione di base
            //Console.WriteLine($"{Role}");

            Console.WriteLine($"{FirstName} {LastName} {Role}");
        }
    }

    public enum RoleEnum
    {
        Manager = 1,
        Technician = 2,
        Developer = 3
    }
}
