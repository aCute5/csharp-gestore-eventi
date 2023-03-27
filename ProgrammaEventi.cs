using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class ProgrammaEventi
    {
        public string? Titolo { get; set; }
        public List<Event> Eventi;

        public ProgrammaEventi(string? titolo)
        {
            Titolo = titolo;
           this.Eventi = new List<Event>();
        }
        public void AddEvent(Event e)  // aggiunge l'evento alla lista
        {
            this.Eventi.Add(e);
        }
        public List<Event> PrintEventbyDate(DateTime date) // metodo di stampa per le liste by data
        {
            List<Event> eventsByData = new List<Event>();
            foreach(Event evento  in this.Eventi)
            {
                if(evento.Data == date)
                {
                    eventsByData.Add(evento);
                }
            }
            return eventsByData;
        }
        public static void PrintList(List<Event> events) // metodo per stampare le liste
        {
            string StringaLista = "";
            foreach(Event e in events)
            {
                StringaLista += "Titolo:" +  e.Title;
                StringaLista += "Data:" + e.Data;
                StringaLista += "Capienza" + Convert.ToString(e.Capienza);
                StringaLista += "Prenotazioni" + Convert.ToString(e.Prenotazioni);
            }
            Console.WriteLine(StringaLista);
        }
      public static void DeleteEvent(List<Event> events)
        {
            events.Clear();
        }  
        public void PrintProgram(ProgrammaEventi program)
        {
            Console.WriteLine(program.Titolo);
            foreach(Event e in Eventi)
            {
                Console.WriteLine("Data:" + e.Data + "-" +  e.Title);
            }
        }
      
    }
}
