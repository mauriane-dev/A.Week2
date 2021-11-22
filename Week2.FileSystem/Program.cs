//Lettura/scrittura da/su file

//StreamWriter
//StreamReader

//Scrivere su file
string path = @"C:\Users\Utente\Desktop\A.Week2\Week2\Week2.FileSystem\prova.txt";

StreamWriter sw = new StreamWriter(path);

sw.WriteLine("Prova di scrittura");

sw.Close();

//se non specifico un path completo, il file viene creato in bin -> Debug -> .net6 -> qui trovo il file
StreamWriter sw3 = new StreamWriter(@"prova2.txt");

sw3.WriteLine("Prova di scrittura");

sw3.Close();

using (StreamWriter sw2 = new StreamWriter(path, true))
{
    sw2.WriteLine("Scrittura su file");
}

using (StreamReader sr = new StreamReader(path))
{
    string text = sr.ReadToEnd(); //legge tutto il contenuto del file
}

using (StreamReader sr2 = new StreamReader(path))
{
    string line = sr2.ReadLine(); //leggere una riga 
}

using (StreamReader sr3 = new StreamReader(path))
{
    string text = sr3.ReadToEnd();
    string[] lines = text.Split("\r\n");
}




