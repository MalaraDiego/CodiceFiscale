using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Buffers.Text;

namespace MauiApp2
{
    public static class CalcolaCodiceFiscale
    {
        
        private static readonly List<string> CodiciEsistenti = new List<string>();
        private static readonly List<string> CodiciEsistentiNoLogin = new List<string>();
        public static async Task<CodiceFiscale> CalcolaCodice(Persona p, Comune c, Nazione n, bool italiano, Utente u)
        {
            // Creo l'oggetto con il valore iniziale
            CodiceFiscale cfObj = new CodiceFiscale(p, c, n, italiano);
            string codice = cfObj.Valore;

            if (CodiciEsistenti.Contains(codice))
            {
                string base15 = codice.Substring(0, 15);
                string codicev2 = await CodiceFiscale.ApplicaOmocodia(base15, u);

                // **Assegno il nuovo codice omocodificato**
                cfObj.Valore = codice;
            }

            return cfObj;
        }

        public static CodiceFiscale CalcolaCodice(Persona p, Comune c, Nazione n, bool italiano)
        {
            CodiceFiscale cfObj = new CodiceFiscale(p, c, n, italiano);
            string codice = cfObj.Valore;

            if (CodiciEsistentiNoLogin.Contains(codice))
            {
                string base15 = codice.Substring(0, 15);
                codice = CodiceFiscale.ApplicaOmocodia(base15, CodiciEsistentiNoLogin);

                // **Assegno il nuovo codice omocodificato**
                cfObj.Valore = codice;
            }

            // Aggiorno la lista dei codici esistenti
            CodiciEsistentiNoLogin.Add(codice);

            return cfObj;
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

    }


}