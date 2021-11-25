using Week2.OOP;

//Person p1 = new Person();
//p1.FirstName = "Mario";
//p1.LastName = "Rossi";
//p1.Age = 30; //non è accessibile fuori dalla classe Person

Person p2 = new Person("Mario", "Rossi");

Employee e1 = new Employee("Marco", "Bianchi", RoleEnum.Manager);

Employee e2 = new Employee();
e2.FirstName = "Sara";
e2.LastName = "Verdi";
e2.Role = RoleEnum.Developer;

//Polimorfismo
//Impiegato è una persona
Person p3 = new Employee("Rosa", "Rosini", RoleEnum.Manager);

List<Person> people = new List<Person>()
{
    p2, e1, e2, p3
};

Customer c1 = new Customer("Tonio", "Cartonio", "Rai");

people.Add(c1);

Trainee t1 = new Trainee()
{
    FirstName = "Roberto",
    LastName = "Neri",
    Role = RoleEnum.Developer,
    Months = 6
};

people.Add(t1);

p2.PrintInfo();
e1.PrintInfo();
c1.PrintInfo();
t1.PrintInfo();

//is
if (c1 is Customer)
{
    //...
}
