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
        public string nome { get { return _nome; } set { if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 30 ) { throw new Exception("Nome non accettabile"); } else { _nome = value; } } }
        public string cognome { get { return _cognome; } set { if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 30) { throw new Exception("Cognome non accettabile"); } else { _cognome = value; } } }
        public string sesso { 
            get
            { return _sesso; } 
            set 
            { if (!value.Equals("M") && !value.Equals("F")) 
                { throw new Exception("Sesso non valido"); } 
                else { _sesso = value; } 

            } 
        }
        public string dataNascita
        {
            get { return _dataNascita; }
            set
            {
                if (DateTime.TryParse(value, out DateTime dataConvertita))
                {
                    if (dataConvertita > DateTime.Now || dataConvertita.Year < 1900)
                    {
                        throw new Exception("Anno data non valido");
                    }

                    // Formatta la data nel formato AAAA-MM-GG con zeri iniziali
                    _dataNascita = dataConvertita.ToString("yyyy-MM-dd");
                }
                else
                {
                    throw new Exception("Formato data non valido");
                }
            }
        }
        public string cf { get; set; }

    }
}
