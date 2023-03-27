using csharp_gestore_eventi;
using System.Diagnostics.Tracing;
using System.Reflection;




Console.WriteLine("Benvenuto nel Progammatore di eventi");
Console.WriteLine("Dimmi il titolo del Programma Eventi:");
string TitoloProgramma = Console.ReadLine() ?? "";
Console.WriteLine("Dimmi quanti eventi vuoi aggiungere:");
int EventQuantity = Convert.ToInt32(Console.ReadLine());
ProgrammaEventi NuovoProgramma = new ProgrammaEventi(TitoloProgramma);

for(int i = 0; i < EventQuantity; i++)
{
    try
    {
        Console.WriteLine("Dimmi le informazioni del" + " " + Convert.ToString(i + 1) + "°" + " " + "evento:");
        Event nuovoEvento = AskEvent();
        NuovoProgramma.AddEvent(nuovoEvento);
        i++;
    }
    catch { Console.WriteLine("Errore durante la creazione dell'evento;Assicurati di aver generato il numero giusto"); }
}

// Stampo i dati dell'Evento

NuovoProgramma.PrintProgram(NuovoProgramma);


static Event AskEvent() // function per chiedere tutte le informazioni dell'evento
{

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
    return nuovoEvento;
}

