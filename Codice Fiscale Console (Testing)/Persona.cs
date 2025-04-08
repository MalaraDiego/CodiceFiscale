using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codice_Fiscale_Console__Testing_
{
    public class Persona
    {
        private string _nome;
        private string _cognome;
        private string _sesso;
        private string _dataNascita;

        public string nome { get { return _nome; } set { if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 30) { throw new Exception("Nome non accettabile"); } else { _nome = value; } } }
        public string cognome { get { return _cognome; } set { if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 30) { throw new Exception("Cognome non accettabile"); } else { _cognome = value; } } }
        public string sesso { get { return _sesso; } set { if (value.ToUpper() != "M" || value.ToUpper() != "F") { throw new Exception("Sesso non valido"); } else { _sesso = value; } } }
        public string dataNascita
        {
            get { return _dataNascita; } set 
            {
                //formato AAAA-MM-GG
                string anno = new string(new char[] { value[0], value[1], value[2], value[3] });
                string mese = new string(new char[] { value[5], value[6] });
                string giorno = new string(new char[] { value[8], value[9] });
                string trattini = new string(new char[] { value[4], value[7] });
                if (int.Parse(anno) > DateTime.Now.Year || int.Parse(anno) < 1900)
                {
                    throw new Exception("Anno non valido");
                }
                else if ( int.Parse(mese) > 12 || int.Parse(mese) < 0)
                {
                    throw new Exception("Mese non valido");
                }
                else if (int.Parse(giorno) > DateTime.DaysInMonth(int.Parse(anno), int.Parse(mese)) || int.Parse(giorno) < 0)
                {
                    throw new Exception("Giorno non valido");
                }
                else if (trattini != "--")
                {
                    throw new Exception("Formato data non valido prova a inserirla in questo formato: (AAAA-MM-GG)");
                }
                else
                {
                    _dataNascita = value;
                }
            }
        }
        public string cf { get; set; }

    }
}
