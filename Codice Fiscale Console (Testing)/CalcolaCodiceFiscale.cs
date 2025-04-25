using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Buffers.Text;

namespace Codice_Fiscale_Console__Testing_
{
    public static class CalcolaCodiceFiscale
    {
        
        private static readonly List<string> CodiciEsistenti = new List<string>();

        public static async Task<string> CalcolaCodice(Persona p, Comune c, Nazione n, bool italiano,Utente u)
        {
            
            CodiceFiscale cfObj = new CodiceFiscale(p, c, n, italiano);
            string codice = cfObj.Valore;

            
            if (CodiciEsistenti.Contains(codice))
            {

                string base15 = codice.Substring(0, 15);
                codice = await CodiceFiscale.ApplicaOmocodia(base15, u);
            }
            CodiciEsistenti.Add(codice);
            return codice;
        }

        public static async Task<List<string>> GetCodiciFiscali(Utente u)
        {
            List<Storico> storico = await GestoreChiamate.getStorico(u);
            List<string> codici = new List<string>();

            foreach (Storico s in storico)
            {
                if (!CodiciEsistenti.Contains(s.cf))
                {
                    CodiciEsistenti.Add(s.cf);
                    
                }
            }
            codici = CodiciEsistenti;
            return codici;
        }

        //QUANDO SI FARA' SU MAUI RIMUOVERE QUESTO ADD, PERCHE' TANTO SI AGGIORNANO CON LO STORICO
    }


}