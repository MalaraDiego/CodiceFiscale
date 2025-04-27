using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2
{
    public class Nazione
    {
        public int id {  get; set; }
        public string continente { get; set; }
        public string denominazione { get; set; }
        public string codice {  get; set; }

        public override string ToString()
        {
            return $"{denominazione}";
        }
    }
}
