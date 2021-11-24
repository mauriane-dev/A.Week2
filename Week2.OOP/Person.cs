using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.OOP
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private int Age { get; set; } //visibile solo nella classe

        public Person ()
        {

        }
        public Person (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }
}
