using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2
{
    public class Comune
    {
        public int id { get; set; }
        public string comune { get; set; }
        public string codiceCatastale { get; set; }

        public override string ToString()
        {
            return $"{comune}";
        }
    }
}
