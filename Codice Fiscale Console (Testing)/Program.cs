using Codice_Fiscale_Console__Testing_;

//List<Comune> c = await GestoreChiamate.getComuni();
//Console.WriteLine(c[1234]);

try
{
    //Persona p = new Persona() { dataNascita = "2024-12-29",sesso = "M", } ;
    //Console.WriteLine(p.dataNascita);
    Utente u = new Utente() { id = 1};
    List<Storico> s = await GestoreChiamate.getStorico(u);
    Console.WriteLine("ciao");

}catch(Exception e)
{
    Console.WriteLine(e.Message);
}
