using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiApp2;

public partial class NewPage1 : ContentPage
{
    bool isChecked;
    ObservableCollection<Comune> comuni = new ObservableCollection<Comune>();
    ObservableCollection<Nazione> nazioni = new ObservableCollection<Nazione>();
    ObservableCollection<Persona> persone = new ObservableCollection<Persona>();
    private Persona personaSelezionata;
    public NewPage1()
    {
        InitializeComponent();
        PopolaListe();

    }
    private async Task<ObservableCollection<Storico>> vediStorico()
    {
        try
        {
            ObservableCollection<Storico> obs = new ObservableCollection<Storico>();
            List<Storico> ls = await GestoreChiamate.getStorico(MainPage.u);
            foreach (Storico storico in ls)
            {
                obs.Add(storico);
            }
            return obs;
        }
        catch (Exception ex) { 
            ErrorLbl.Text = ex.Message;
            return null;
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ClearError(ErrorLbl);
        Clear();
        
        myListView.ItemsSource = persone;
        Picker1.IsVisible = false;
        Entry1.IsVisible = false;
        Picker2.IsVisible = false;
        Entry2.IsVisible = false;
        // Controlla lo stato dell'utente ogni volta che la pagina appare
        if (MainPage.u == null)
        {
            lblLogin.IsVisible = true;
            lblfailogin.IsVisible = true;
            salvaStorico.IsVisible = false;
            myListView2.IsVisible = false;
        }
        else
        {
            // Utente ha fatto login, nascondi i messaggi
            lblLogin.IsVisible = false;
            lblfailogin.IsVisible = false;
            salvaStorico.IsVisible = true;
            myListView2.IsVisible= true;
            if (vediStorico() != null)
            {
                myListView2.ItemsSource = await vediStorico();
            }
        }
    }
    private async void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        isChecked = e.Value;

        // Mostra o nasconde i Picker in base al valore della checkBox
        if (isChecked)
        {
            Entry2.Text = "";
            Picker1.IsVisible = true;
            Entry1.IsVisible = true;
            Picker2.IsVisible = false;
            Entry2.IsVisible = false;
        }
        else
        {
            Entry1.Text = "";
            Picker1.IsVisible = false;
            Entry1.IsVisible = false;
            Picker2.IsVisible = true;
            Entry2.IsVisible = true;
        }
    }
    private void EntryChanged(object sender, EventArgs e)
    {
        try
        {
            // Aggiorna i Picker solo se sono visibili
            if (Picker1.IsVisible)
            {
                ObservableCollection<Comune> comuniFiltrati = UtilityRicerca.AlgoritmoComune(Entry1, comuni);
                if (comuniFiltrati != null && comuniFiltrati.Any())
                {
                    Picker1.ItemsSource = comuniFiltrati;
                }
                else
                {
                    Picker1.ItemsSource = new List<string>(); // Imposta un elenco vuoto se non ci sono risultati
                }

                Picker2.ItemsSource = nazioni;
            }
            else if (Picker2.IsVisible)
            {
                ObservableCollection<Nazione> nazioniFiltrate = UtilityRicerca.AlgoritmoNazione(Entry2, nazioni);
                if (nazioniFiltrate != null && nazioniFiltrate.Any())
                {
                    Picker2.ItemsSource = nazioniFiltrate;
                }
                else
                {
                    Picker2.ItemsSource = new List<string>(); // Imposta un elenco vuoto se non ci sono risultati
                }

                Picker1.ItemsSource = comuni;
            }
        }
        catch (Exception ex)
        {

        }
    }
    private async void PopolaListe()
    {
        List<Comune> c = await GestoreChiamate.getComuni();
        List<Nazione> n = await GestoreChiamate.getNazioni();

        foreach (Comune cm in c)
        {
            comuni.Add(cm);
        }

        foreach (Nazione nz in n)
        {
            nazioni.Add(nz);
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (SessoPicker.SelectedItem == null) throw new Exception("COMPILA TUTTI I CAMPI");
            Persona p = new Persona(NomeEntry.Text, CognomeEntry.Text, SessoPicker.SelectedItem.ToString(), FormattaData(DataNascitaPicker.Date));
            if (MainPage.u == null)
            {
                p.cf = CalcolaCodiceFiscale.CalcolaCodice(p, (Comune)Picker1.SelectedItem, (Nazione)Picker2.SelectedItem, isChecked);
                ClearError(ErrorLbl);
                persone.Add(p);
            }
            else
            {
                p.cf = await CalcolaCodiceFiscale.CalcolaCodice(p, (Comune)Picker1.SelectedItem, (Nazione)Picker2.SelectedItem, isChecked, MainPage.u);
                ClearError(ErrorLbl);
                persone.Add(p);
            }

        }
        catch (Exception ex)
        {
            ErrorLbl.Text = ex.Message;
        }


    }

    private string FormattaData(DateTime data)
    {
        try
        {
            string dataFormattata = data.Year.ToString() + "/" + data.Month.ToString() + "/" + data.Day.ToString();
            return dataFormattata;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }


    }

    private async void OnLoginTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private void ClearError(Label l)
    {
        l.Text = "";
    }

    private void Clear()
    {
        NomeEntry.Text = "";
        CognomeEntry.Text = "";
        SessoPicker.SelectedItem = null;
        DataNascitaPicker.Date = DateTime.Now;
        OpzioniAvanzateCheckBox.IsChecked = false;
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            if (personaSelezionata == null)
                throw new Exception("Seleziona una persona da salvare");

            if (isChecked)
            {
                Id i = await GestoreChiamate.postStorico(
                    MainPage.u,
                    personaSelezionata,
                    personaSelezionata.cf.comune.comune.ToString(),
                    personaSelezionata.cf.comune.codiceCatastale.ToString());
            }
            else
            {
                Id i = await GestoreChiamate.postStorico(
                    MainPage.u,
                    personaSelezionata,
                    personaSelezionata.cf.nazione.denominazione.ToString(),
                    personaSelezionata.cf.nazione.codice.ToString());
            }


        }
        catch (Exception ex)
        {
            ErrorLbl.Text = ex.Message;
        }
    }

    private void OnPersonaTapped(object sender, ItemTappedEventArgs e)
    {
        // Ottieni l'oggetto selezionato
        personaSelezionata = e.Item as Persona;

        // Deseleziona (così puoi tappare di nuovo lo stesso item)
        ((ListView)sender).SelectedItem = null;

        DisplayAlert("Selezionato",
                     $"Hai selezionato: {personaSelezionata.nome} {personaSelezionata.cognome}",
                     "OK");
    }
}