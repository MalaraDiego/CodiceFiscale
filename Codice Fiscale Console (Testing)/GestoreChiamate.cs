using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Codice_Fiscale_Console__Testing_
{
    public static class GestoreChiamate
    {
        public static async Task<List<Comune>> getComuni()
        {
            string api = "http://codicefiscale.infy.uk/getCodiciCatastali.php";
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; //accetta tutti i tipi di server anche quelli non verificati (non sicuri)
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            client.DefaultRequestHeaders.Add("Cookie", "__test=c74fde7f4b105bdfeced94b1d7bddba5");
            
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
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            client.DefaultRequestHeaders.Add("Cookie", "__test=c74fde7f4b105bdfeced94b1d7bddba5");
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
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            client.DefaultRequestHeaders.Add("Cookie", "__test=c74fde7f4b105bdfeced94b1d7bddba5");
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
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            client.DefaultRequestHeaders.Add("Cookie", "__test=c74fde7f4b105bdfeced94b1d7bddba5");
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
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            client.DefaultRequestHeaders.Add("Cookie", "__test=c74fde7f4b105bdfeced94b1d7bddba5");
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
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            client.DefaultRequestHeaders.Add("Cookie", "__test=c74fde7f4b105bdfeced94b1d7bddba5");
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

        public static async Task<Storico> getStorico(Utente u)
        {
            string api = $"http://codicefiscale.infy.uk/getUtenteStorico.php?idUtente={u.id}";
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator; //accetta tutti i tipi di server anche quelli non verificati (non sicuri)
            using HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            client.DefaultRequestHeaders.Add("Cookie", "__test=c74fde7f4b105bdfeced94b1d7bddba5");
            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                Storico sc = JsonSerializer.Deserialize<Storico>(json);
                return sc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
