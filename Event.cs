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
        public DateTime Data { get; set; }
        private int _capienza;
        private  int Prenotazioni;

        public Event(string Title, DateTime Data, int _capienza)
        {
            this.Title = Title;
            this.Data = Data;
            Capienza = _capienza;
            Prenotazioni = 0; 
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
