using csharp_gestore_eventi;
using System.Diagnostics.Tracing;
using System.Reflection;

Console.WriteLine("Ciao! Imposta il tuo nuovo evento");

Console.WriteLine("Dimmi il nome dell'evento:");
string inputTitle = Console.ReadLine() ?? "";
Console.WriteLine("Quando vuoi che si svolga l'evento?");
string inputDate = Console.ReadLine() ?? "";
Console.WriteLine("Dimmi la capienza dell'evento");
int inputCapienza = (int)Convert.ToInt64((Console.ReadLine()));
int inputPrenotazioni = 0; 
Event nuovoEvento = new Event(inputTitle, inputDate, inputCapienza,inputPrenotazioni);

Console.WriteLine("Ecco il riepilogo del tuo evento:");
Console.WriteLine("Nome dell'Evento:" + inputTitle);
Console.WriteLine("Data dell'Evento:" + inputDate);
Console.WriteLine("Il numero di posti:" + inputCapienza);

Console.WriteLine("Quante prenotazioni vuoi effettuare per quell'evento?");
int nuovePrenotazioni = (int)Convert.ToInt64((Console.ReadLine()));
nuovoEvento.PrenotaPosti(nuovePrenotazioni);
Console.WriteLine("Ecco il numero di posti prenotati:" + nuovoEvento.Prenotazioni);
int postiDisponibili = inputCapienza - nuovePrenotazioni;
Console.WriteLine("Ecco i posti disponibili" +  postiDisponibili);
Console.WriteLine("Hai dei posti da disdire?");
int deletePrenotazioni = (int)Convert.ToInt64((Console.ReadLine()));
nuovoEvento.DisdiciPosti(deletePrenotazioni);
int nuovipostiDisponibili = inputCapienza - nuovePrenotazioni + deletePrenotazioni; // è necessaria questa variabile? Io non credo devo fixare la funzione

Console.WriteLine("Ecco il numero di posti prenotati:" + nuovoEvento.Prenotazioni);
Console.WriteLine("Ecco i posti disponibili" + nuovipostiDisponibili);

