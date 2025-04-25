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
Utente u = new Utente { id = 13 };


Persona p = new Persona() { dataNascita = "2007-3-16",sesso = "M",nome = "Gioco", cognome = "Poker"};
p.cf =  await CalcolaCodiceFiscale.CalcolaCodice(p, c[index], null,true,u);
Persona p2 = new Persona() { dataNascita = "2007-3-16", sesso = "M", nome = "Gioco", cognome = "Poker" };
p2.cf = await CalcolaCodiceFiscale.CalcolaCodice(p, c[index], null, true,u);
Persona p3 = new Persona() { dataNascita = "2007-3-16", sesso = "M", nome = "Gioco", cognome = "Poker" };
p3.cf = await CalcolaCodiceFiscale.CalcolaCodice(p, c[index], null, true,u);
Persona p4 = new Persona() { dataNascita = "2007-3-16", sesso = "M", nome = "Gioco", cognome = "Poker" };
p4.cf = await CalcolaCodiceFiscale.CalcolaCodice(p, c[index], null, true, u);
Persona p5 = new Persona() { dataNascita = "2007-3-16", sesso = "M", nome = "Gioco", cognome = "Poker" };
p5.cf = await CalcolaCodiceFiscale.CalcolaCodice(p, c[index], null, true, u);
Persona p6 = new Persona() { dataNascita = "2007-3-16", sesso = "M", nome = "Gioco", cognome = "Poker" };
p6.cf = await CalcolaCodiceFiscale.CalcolaCodice(p, c[index], null, true, u);
Persona p7 = new Persona() { dataNascita = "2007-3-16", sesso = "M", nome = "Gioco", cognome = "Poker" };
p7.cf = await CalcolaCodiceFiscale.CalcolaCodice(p, c[index], null, true, u);
Persona p8 = new Persona() { dataNascita = "2007-3-16", sesso = "M", nome = "Gioco", cognome = "Poker" };
p8.cf = await CalcolaCodiceFiscale.CalcolaCodice(p, c[index], null, true, u);
Persona p9 = new Persona() { dataNascita = "2007-3-16", sesso = "M", nome = "Gioco", cognome = "Poker" };
p9.cf = await CalcolaCodiceFiscale.CalcolaCodice(p, c[index], null, true, u);
Console.WriteLine(p.cf);
Console.WriteLine(p2.cf);
Console.WriteLine(p3.cf);
Console.WriteLine(p4.cf);
Console.WriteLine(p5.cf);
Console.WriteLine(p6.cf);
Console.WriteLine(p7.cf);
Console.WriteLine(p8.cf);
Console.WriteLine(p9.cf);


