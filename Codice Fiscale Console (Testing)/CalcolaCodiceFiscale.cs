using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Codice_Fiscale_Console__Testing_
{
    public static class CalcolaCodiceFiscale
    {
        public static bool italiano = true;
        public static void CalcolaCodice(ref Persona p, Comune c, Nazione n)
        {
            string codice = "";
            // Normalizza cognome e nome rimuovendo gli accenti
            string cognome = NormalizzaCaratteri(p.cognome.ToLower());
            string nome = NormalizzaCaratteri(p.nome.ToLower());
            string codiceLuogo = "";

            string primeTreLettere = PresaLettere(cognome, "cognome");
            codice += primeTreLettere;

            string treLettereNome = PresaLettere(nome, "nome");
            codice += treLettereNome;

            string cifreData = CalcoloCifreData(p.dataNascita, p.sesso);
            codice += cifreData;
            if (italiano)
            {
                codiceLuogo = getCodiceComune(c);
            }
            else
            {
                codiceLuogo = getCodiceNazione(n);
            }

            codice += codiceLuogo;

            // Calcolo del carattere di controllo
            string carattereControllo = CarattereDiControllo(codice);
            codice += carattereControllo;

            p.cf = codice;
        }

        // Nuovo metodo per normalizzare i caratteri accentati
        private static string NormalizzaCaratteri(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Definisci una mappa di sostituzione per i caratteri accentati più comuni in italiano
            Dictionary<char, char> mappaAccenti = new Dictionary<char, char>
        {
            {'à', 'a'}, {'è', 'e'}, {'é', 'e'}, {'ì', 'i'}, {'ò', 'o'}, {'ù', 'u'},
            {'â', 'a'}, {'ê', 'e'}, {'î', 'i'}, {'ô', 'o'}, {'û', 'u'},
            {'ä', 'a'}, {'ë', 'e'}, {'ï', 'i'}, {'ö', 'o'}, {'ü', 'u'},
            {'À', 'a'}, {'È', 'e'}, {'É', 'e'}, {'Ì', 'i'}, {'Ò', 'o'}, {'Ù', 'u'},
            {'Â', 'a'}, {'Ê', 'e'}, {'Î', 'i'}, {'Ô', 'o'}, {'Û', 'u'},
            {'Ä', 'a'}, {'Ë', 'e'}, {'Ï', 'i'}, {'Ö', 'o'}, {'Ü', 'u'}
        };

            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                if (mappaAccenti.ContainsKey(c))
                    result.Append(mappaAccenti[c]);
                else
                    result.Append(c);
            }
            return result.ToString();
        }

        private static string getCodiceComune(Comune c)
        {
            return c.codiceCatastale;
        }

        private static string getCodiceNazione(Nazione n)
        {
            return n.codice;
        }

        private static string CarattereDiControllo(string codice15Cifre)
        {
            Dictionary<string, string> dizionarioConversioneDispari = new Dictionary<string, string>
        {
            {"0", "1"}, {"1", "0"}, {"2", "5"}, {"3", "7"}, {"4", "9"}, {"5", "13"}, {"6", "15"}, {"7", "17"}, {"8", "19"}, {"9", "21"},
            {"A", "1"}, {"B", "0"}, {"C", "5"}, {"D", "7"}, {"E", "9"}, {"F", "13"}, {"G", "15"}, {"H", "17"}, {"I", "19"}, {"J", "21"},
            {"K", "2"}, {"L", "4"}, {"M", "18"}, {"N", "20"}, {"O", "11"}, {"P", "3"}, {"Q", "6"}, {"R", "8"}, {"S", "12"}, {"T", "14"},
            {"U", "16"}, {"V", "10"}, {"W", "22"}, {"X", "25"}, {"Y", "24"}, {"Z", "23"}
        };

            Dictionary<string, string> dizionarioConversioneResti = new Dictionary<string, string>
        {
            {"0", "A"}, {"1", "B"}, {"2", "C"}, {"3", "D"}, {"4", "E"}, {"5", "F"}, {"6", "G"}, {"7", "H"}, {"8", "I"}, {"9", "J"},
            {"10", "K"}, {"11", "L"}, {"12", "M"}, {"13", "N"}, {"14", "O"}, {"15", "P"}, {"16", "Q"}, {"17", "R"}, {"18", "S"},
            {"19", "T"}, {"20", "U"}, {"21", "V"}, {"22", "W"}, {"23", "X"}, {"24", "Y"}, {"25", "Z"}
        };

            Dictionary<string, string> dizionarioConversioneNumericiPari = new Dictionary<string, string>
        {
            {"0", "0"}, {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"}, {"5", "5"}, {"6", "6"}, {"7", "7"}, {"8", "8"}, {"9", "9"},
            {"A", "0"}, {"B", "1"}, {"C", "2"}, {"D", "3"}, {"E", "4"}, {"F", "5"}, {"G", "6"}, {"H", "7"}, {"I", "8"}, {"J", "9"},
            {"K", "10"}, {"L", "11"}, {"M", "12"}, {"N", "13"}, {"O", "14"}, {"P", "15"}, {"Q", "16"}, {"R", "17"}, {"S", "18"},
            {"T", "19"}, {"U", "20"}, {"V", "21"}, {"W", "22"}, {"X", "23"}, {"Y", "24"}, {"Z", "25"}
        };

            int caratteriPari = 0;
            int caratteriDispari = 0;

            for (int i = 0; i < codice15Cifre.Length; i++)
            {
                string carattere = codice15Cifre[i].ToString();
                if (i % 2 != 0)
                {
                    caratteriPari += int.Parse(dizionarioConversioneNumericiPari[carattere]);
                }
                else
                {
                    caratteriDispari += int.Parse(dizionarioConversioneDispari[carattere]);
                }
            }

            int valoreConversione = (caratteriPari + caratteriDispari) % 26;
            return dizionarioConversioneResti[valoreConversione.ToString()];
        }

        private static string CalcoloCifreData(string dataStringa, string sesso)
        {
            DateTime data = DateTime.ParseExact(dataStringa, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Dictionary<string, string> mesi = new Dictionary<string, string>
        {
            {"1", "A"}, {"2", "B"}, {"3", "C"}, {"4", "D"}, {"5", "E"}, {"6", "H"},
            {"7", "L"}, {"8", "M"}, {"9", "P"}, {"10", "R"}, {"11", "S"}, {"12", "T"}
        };

            string cifreAnno = data.Year.ToString().Substring(2); // ultime due cifre dell'anno
            string cifreMese = mesi[data.Month.ToString()]; // conversione col dizionario
            string cifreGiorno = data.Day.ToString();

            if (cifreGiorno.Length != 2)
                cifreGiorno = "0" + cifreGiorno;

            if (sesso == "F")
                cifreGiorno = (int.Parse(cifreGiorno) + 40).ToString();

            return cifreAnno + cifreMese + cifreGiorno;
        }

        private static int NumeroLettere(char[] lettere, string parametro)
        {
            int conteggio = 0;
            foreach (char c in parametro)
            {
                if (lettere.Contains(c))
                    conteggio++;
            }
            return conteggio;
        }

        private static string CicloParametro(char[] lettere, string parametro)
        {
            StringBuilder risultato = new StringBuilder();
            foreach (char c in parametro)
            {
                if (lettere.Contains(c))
                    risultato.Append(c);
            }
            return risultato.ToString();
        }

        private static string PresaLettere(string parametro, string codifica)
        {
            char[] consonanti = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
            char[] vocali = { 'a', 'e', 'i', 'o', 'u' };
            string lettereRaccolte = "";
            int nConsonanti = NumeroLettere(consonanti, parametro);
            int nVocali = NumeroLettere(vocali, parametro);

            if (nConsonanti > 3)
            {
                if (codifica == "nome") 
                {
                    lettereRaccolte = CicloParametro(consonanti, parametro);
                    return (lettereRaccolte[0].ToString() + lettereRaccolte[2].ToString() + lettereRaccolte[3].ToString()).ToUpper();
                }
                else if (codifica == "cognome")
                {
                    lettereRaccolte = CicloParametro(consonanti, parametro);
                }
            }
            else if (nConsonanti == 3)
            {
                lettereRaccolte = CicloParametro(consonanti, parametro);
            }
            else if (nConsonanti + nVocali >= 3)
            {
                lettereRaccolte = CicloParametro(consonanti, parametro);
                lettereRaccolte += CicloParametro(vocali, parametro);
            }
            else
            {
                lettereRaccolte = CicloParametro(consonanti, parametro);
                lettereRaccolte += CicloParametro(vocali, parametro);
                for (int i = 0; i < 3 - lettereRaccolte.Length; i++)
                {
                    lettereRaccolte += "x";
                }
            }

            return lettereRaccolte.Substring(0, 3).ToUpper();
        }
    }

}