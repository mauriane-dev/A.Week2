using Week2.Classi;

//Creo un'istanza di Person -> parola chiave new
Person p1 = new Person();

//Person p2; //riferimento a persona

//Campi private di default:
//p1.firstName = "Mario";

//p1.firstName = "Mario";
//p1.lastName = "Rossi";

p1.FirstName = "Mario"; //Assegno il valore alla proprietà Firstname dell'istanza p1 di tipo Person

Console.WriteLine(p1.FirstName); //Leggere il valore della proprietà Firstname dell'istanza p1 di tipo Person

Person p3 = new Person();
Console.WriteLine(p3.Age);
//p3.Age = 40; 

p1.LastName = "Rossi";
p1.BirthDate = new DateTime(1995, 4, 7);
p1.GetAge(); //calcolava in maniera approssimativa l'età
Console.WriteLine(p1.Age);

Console.WriteLine(p1.ToString());

Person p4 = new Person();
//uso il costruttore vuoto
//=> viene creato un oggetto di tipo Person con i valori delle proprietà impostati sui valori di default
//es. se proprietà è di tipo int -> 0
//se proprietà è di tipo string -> null 
//...

p4.Code = "RSSMRA456";

Person p5 = new Person()
{
    FirstName = "Marco",
    LastName = "Verdi",
    BirthDate = new DateTime(1985, 2, 9),
    Code = "VRDMRC234"
};

Person p6 = new Person("BNCSRA345", "Sara", "Bianchi");

//Proprietà di altro tipo
p1.Address = new HomeAddress()
{
    Street = "Via Roma",
    City = "Milano",
    Number = 10,
    Country = "Italia",
    PostalCode = 54322
};


char c = Console.ReadKey().KeyChar;