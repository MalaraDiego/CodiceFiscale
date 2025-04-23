using Codice_Fiscale_Console__Testing_;

List<Comune> c = await GestoreChiamate.getComuni();
int index = 0;

foreach (Comune comune in c)
{
    if (comune.comune == "Bergamo")
    {
        index = c.IndexOf(comune);
    }
}



    Persona p = new Persona() { dataNascita = "2007-03-16",sesso = "M",nome = "Gàbriele", cognome = "Travellìni"};
    CalcolaCodiceFiscale.CalcolaCodice(ref p, c[index], null);
    Console.WriteLine("Ciao");


