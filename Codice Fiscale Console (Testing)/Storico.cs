using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codice_Fiscale_Console__Testing_
{
    public class Storico
    {
        public int id { get; set; }
        public int idUtente { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string sesso { get; set; }
        public string dataNascita { get; set; }
        public string luogo { get; set; }
        public string codiceLuogo { get; set; }
        public string cf { get; set; }

        public override string ToString()
        {
            return $"{nome}";
        }
    }


}
