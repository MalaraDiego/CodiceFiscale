using Codice_Fiscale_Console__Testing_;

//List<Comune> c = await GestoreChiamate.getComuni();
//Console.WriteLine(c[1234]);

try
{
    Persona p = new Persona() { dataNascita = "2024-12-29",sesso = "M", } ;
    Console.WriteLine(p.dataNascita);
}catch(Exception e)
{
    Console.WriteLine(e.Message);
}
