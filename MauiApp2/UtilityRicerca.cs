using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public static class UtilityRicerca
    {
        // Metodo per filtrare i comuni basati sul testo immesso nell'Entry
        public static ObservableCollection<Comune> AlgoritmoComune(Entry e, ObservableCollection<Comune> list)
        {
            string nuovoTesto = e.Text;
            ObservableCollection<Comune> c = new ObservableCollection<Comune>();

            // Pulisce la collezione c
            if (c != null)
            {
                c.Clear();
                
            }
            else if(c == null)
            {
                return list;
            }

            // Controlla se nuovoTesto non è vuoto
            if (!string.IsNullOrEmpty(nuovoTesto))
            {
                // Itera attraverso i comuni nella lista
                foreach (Comune cm in list)
                {
                    // Controlla se il nome del comune contiene tutti i caratteri di nuovoTesto
                    if (ContainsAllCharacters(cm.comune.ToLower(), nuovoTesto.ToLower()))
                    {
                        c.Add(cm);
                    }
                }
            }

            // Aggiorna il Picker con i risultati
            if (c.Count > 0)
            {
                return c;
            }
            else
            {
                return null; // Se non ci sono risultati, non mostra nulla
            }
        }

        // Metodo per filtrare le nazioni basate sul testo immesso nell'Entry
        public static ObservableCollection<Nazione> AlgoritmoNazione(Entry e, ObservableCollection<Nazione> list)
        {
            string nuovoTesto = e.Text;
            ObservableCollection<Nazione> c = new ObservableCollection<Nazione>();

            // Pulisce la collezione c
            if (c != null)
            {
                c.Clear();
                
            }
            else if (c == null)
            {
                return list;
            }
            // Controlla se nuovoTesto non è vuoto
            if (!string.IsNullOrEmpty(nuovoTesto))
            {
                // Itera attraverso le nazioni nella lista
                foreach (Nazione nz in list)
                {
                    // Controlla se il nome della nazione contiene tutti i caratteri di nuovoTesto
                    if (ContainsAllCharacters(nz.denominazione.ToLower(), nuovoTesto.ToLower()))
                    {
                        c.Add(nz);
                    }
                }
            }

            // Aggiorna il Picker con i risultati
            if (c.Count > 0)
            {
                return c;
            }
            else
            {
                return null; // Se non ci sono risultati, non mostra nulla
            }
        }

        // Metodo per controllare se la stringa principale contiene tutti i caratteri della stringa da controllare
        private static bool ContainsAllCharacters(string main, string check)
        {
            // Crea un array di char dalla stringa principale
            char[] mainChars = main.ToCharArray();

            foreach (char c in check)
            {
                bool found = false;
                // Controlla se il carattere è presente nell'array
                foreach (char mainChar in mainChars)
                {
                    if (mainChar == c)
                    {
                        found = true;
                        break;  // Se il carattere è trovato, esci dal ciclo
                    }
                }
                if (!found)
                {
                    return false; // Se un carattere non è presente, restituisci false
                }
            }
            return true; // Tutti i caratteri sono presenti
        }
    }
}
