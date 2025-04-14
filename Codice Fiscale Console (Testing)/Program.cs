using Codice_Fiscale_Console__Testing_;


//List<Comune> c = await GestoreChiamate.getComuni();
//Console.WriteLine(c[1234]);

try
{
    //Persona p = new Persona() { dataNascita = "2024-12-29",sesso = "M", } ;
    //Console.WriteLine(p.dataNascita);
    Utente u = new Utente() { id = 13};
    List<Storico> s = await GestoreChiamate.getStorico(u);
    foreach (Storico s1 in s)
    {
        Console.WriteLine(s1);
    }
    

}catch(Exception e)
{
    Console.WriteLine(e.Message);
}
 