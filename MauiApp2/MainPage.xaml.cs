
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public static Utente u = null;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            try
            {
                u = await GestoreChiamate.tryLogin(UserEntry.Text, PasswordEntry.Text);
                ClearError(ErrorLbl);
                await Shell.Current.GoToAsync("//NewPage1");
            }
            catch (Exception ex)
            {
                ErrorLbl.Text = "Username e/o Password errati";
            }

        }
        
        private async void WithoutLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//NewPage1");
        }
        private void ClearError(Label l)
        {
            l.Text = "";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ClearError(ErrorLbl);
            UserEntry.Text = "";
            PasswordEntry.Text = "";
        }
    }   
}