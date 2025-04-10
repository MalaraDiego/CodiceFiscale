using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Codice_Fiscale_Console__Testing_
{

    public static class GestoreChiamate
    {   //dati da aggiornare ogni volta che non funzionano le chiamate api
        //scadono dopo un giorno
        static readonly string cookie = "__test=15102c6ee03c76d899ab37ee02afc133";
        static readonly string user_agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36";
        public static async Task<List<Comune>> getComuni()
        {
            string api = "http://codicefiscale.infy.uk/getCodiciCatastali.php";
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; //accetta tutti i tipi di server anche quelli non verificati (non sicuri)
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", user_agent);
            client.DefaultRequestHeaders.Add("Cookie", cookie);

            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                List<Comune> lc = JsonSerializer.Deserialize<List<Comune>>(json);
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<Comune> getComune(int i)
        {
            string api = $"http://codicefiscale.infy.uk/getCodiceCatastale.php?id={i}";
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; //accetta tutti i tipi di server anche quelli non verificati (non sicuri)
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", user_agent);
            client.DefaultRequestHeaders.Add("Cookie", cookie);
            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                Comune c = JsonSerializer.Deserialize<Comune>(json);
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<List<Nazione>> getNazioni()
        {
            string api = "http://codicefiscale.infy.uk/getCodiciNazioni.php";
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; //accetta tutti i tipi di server anche quelli non verificati (non sicuri)
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", user_agent);
            client.DefaultRequestHeaders.Add("Cookie", cookie);
            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                List<Nazione> ln = JsonSerializer.Deserialize<List<Nazione>>(json);
                return ln;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<Nazione> getNazione(int i)
        {
            string api = $"http://codicefiscale.infy.uk/getCodiceNazione.php?id={i}";
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; //accetta tutti i tipi di server anche quelli non verificati (non sicuri)
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", user_agent);
            client.DefaultRequestHeaders.Add("Cookie", cookie);
            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                Nazione n = JsonSerializer.Deserialize<Nazione>(json);
                return n;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<Utente> tryLogin(string user, string pass)
        {
            string api = $"http://codicefiscale.infy.uk/login.php?utente={user}&password={pass}";
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; //accetta tutti i tipi di server anche quelli non verificati (non sicuri)
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", user_agent);
            client.DefaultRequestHeaders.Add("Cookie", cookie);
            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                Utente u = JsonSerializer.Deserialize<Utente>(json);
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<int> postStorico(Utente u, Persona p, string luogo, string codiceL)
        {
            string api = $"http://codicefiscale.infy.uk/addUtenteStorico.php?idUtente={u.id}&nome={p.nome}&cognome={p.cognome}&sesso={p.sesso}&luogo={luogo}&codiceLuogo={codiceL}&dataNascita={p.dataNascita}&cf={p.cf}";
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; //accetta tutti i tipi di server anche quelli non verificati (non sicuri)
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", user_agent);
            client.DefaultRequestHeaders.Add("Cookie", cookie);
            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                int id = JsonSerializer.Deserialize<int>(json);
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<List<Storico>> getStorico(Utente u)
        {
            string api = $"http://codicefiscale.infy.uk/getUtenteStorico.php?idUtente={u.id}";
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; //accetta tutti i tipi di server anche quelli non verificati (non sicuri)
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", user_agent);
            client.DefaultRequestHeaders.Add("Cookie", cookie);
            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                List<Storico> sc = JsonSerializer.Deserialize<List<Storico>>(json);
                return sc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
