
using System.Collections.ObjectModel;

namespace MauiApp2
{
    public partial class HomePage : ContentPage
    {
        
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnGoToNuovaPaginaClicked(object sender, EventArgs e)
        {   

            await Shell.Current.GoToAsync("//NewPage1",true);
        }
    }
}