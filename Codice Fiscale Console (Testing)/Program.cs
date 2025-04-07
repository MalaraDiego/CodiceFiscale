using Codice_Fiscale_Console__Testing_;

List<Comune> c = await GestoreChiamate.getListaComuni();
Console.WriteLine(c[0]+ " "+ c[1]);