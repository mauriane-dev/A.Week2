using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Classi
{
    internal class Person
    {
        //campi
        //default: private
        //=> private: non visibili fuori dalla classe
        //public string firstName;
        //public string lastName;

        //public: visibili fuori dalla clase, in tutta la solution

        //forma estesa
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        //forma ridotta
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; } //data di nascita

        //Sola lettura (manca parte set)
        //public int Age { get; } /*= 28;*/
        //Assegnabile solo qui o nel costruttore

        //Non posso neanche fare una cosa del genere:
        //public void GetAge()
        //{
        //    int age = DateTime.Now.Year - BirthDate.Year;
        //    Age = age;
        //}

        //Non posso assegnare la proprietà neanche nella classe stessa, ma solo inizializzarla nel costruttore oppure
        //'accanto' alla proprietà.

        public int Age { get; private set; }
        //private set -> set visibile solo nella classe
        //non posso settare altrove Age
        //posso farlo solo nella classe

        public void GetAge()
        {
            Age = DateTime.Now.Year - BirthDate.Year;
        }

        private string _code;
        public string Code
        {
            get { return _code; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _code = "nessun codice";
                    //scatenare un'eccezione di tipo ArgumentNullException 
                }
                else
                {
                    _code = value;
                }
            }
        }

        //Metodi 
        public void PrintInfo()
        {
            Console.WriteLine($"{Code} {FirstName} {LastName} {BirthDate}");
        }

        public override string ToString()
        {
            return $"{Code} {FirstName} {LastName} {BirthDate}";
        }

        public bool IsAdult()
        {
            int age = DateTime.Now.Year - BirthDate.Year; //calcolo l'età (approssimativamente)

            if (age >= 18)
            { 
                return true; 
            }

            return false;
        }

        //Costruttore con parametri
        public Person (string code, string firstName, string LastName)
        {
            Code = code;
            FirstName = firstName;
            this.LastName = LastName;
        }

        //Costruttore vuoto
        public Person()
        {

        }

        //Altro costruttore con parametri
        public Person(string code, string firstName, string lastName, DateTime birthDate)
        {
            Code = code;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        //Proprietà di un altro tipo definito dall'utente sviluppatore
        public HomeAddress Address { get; set; }
    }
}
