using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Event
    {
        public string? Title { get; set; }
        DateTime  data;
        private int _capienza;
        private  int Prenotazioni;

        public Event(string Title, string data, int _capienza) // la data la passo come stringa perchè al momento dell'immissione è una stringa; poi nel blocco tras
            // trasformo  il tipo data in DateTime. Quindi come argomento del construttore posso passare qualsiasi tipo basta che poi nel blocco esso diventi il tipo
            //richiesto nella struttura del codice
        {
           Data = DateTime.ParseExact(data, "dd/MM/yyyy", null);
           this.Title = Title;
           Capienza = _capienza;
           Prenotazioni = 0; 
        }

        public DateTime Data
        {
            get {  return data ; }
            set
            {
                if(value < DateTime.Today) // controllo per verificare che la data immessa sia successiva alla data odierna (il metodo .today di DateTime fa questo)
                {
                    throw new ArgumentException("La data non può essere precedente a oggi");
                }
                Data = value ;  
            }
        }
       public int Capienza //eccezione nel caso in cui capienza sia negativo
        {
            get { return _capienza; }

            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("La capzienza massima è negativo o 0; settare un numero positivo; ");
                }
                _capienza = value;
            }
        }
        public void PrenotaPosti (int nuovePrenotazioni) 
        {
            if(Prenotazioni + nuovePrenotazioni > _capienza ) // se il numero di posti prenotati supera la capienza massima dell'evento scatta il controllo
            { 
                throw new ArgumentException("L'evento è pieno quindi i posti prenotati sono di piu di quelli possibili");
            
            
            }
            Prenotazioni += nuovePrenotazioni;
        }
        public void DisdiciPosti(int disdetta)
        {
            if(Prenotazioni <= 0 )
            {
                throw new ArgumentException("Non ci sono prenotazioni per questo evento");
            }
            Prenotazioni -= disdetta;
        }
        public override string ToString()
        {
            return $"{Data:d}";     
        }
    }
}
