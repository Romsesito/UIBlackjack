// ViewModels/MenuViewModel.cs
using System.Windows.Input;
using Microsoft.Maui.Controls;
using UIBlackjack.Views;

namespace UIBlackjack.ViewModels
{
    public class MenuViewModel
    {
        public ICommand NavigateToInfoCommand { get; }
        public ICommand NavigateToSeguridadCommand { get; }
        public ICommand NavigateToTarjetaCommand { get; }
        public ICommand NavigateToUbicacionCommand { get; }
        public ICommand NavigateToAyudaCommand { get; }
        public ICommand NavigateToMenuCommand { get; }
        public ICommand NavigateToMisDatosCommand { get; }
        public ICommand NavigateToInfoCCommand { get; }

        public MenuViewModel()
        {
            NavigateToInfoCommand = new Command(async () => await NavigateToPage("InfoPage"));
            NavigateToSeguridadCommand = new Command(async () => await NavigateToPage("SeguridadPage"));
            NavigateToTarjetaCommand = new Command(async () => await NavigateToPage("TarjetaPage"));
            NavigateToUbicacionCommand = new Command(async () => await NavigateToPage("UbicacionPage"));
            NavigateToAyudaCommand = new Command(async () => await NavigateToPage("AyudaPage"));
            NavigateToMisDatosCommand = new Command(async () => await NavigateToPage("MisDatosInfo"));
            NavigateToMenuCommand = new Command(async () => await NavigateToPage("Menu"));
            NavigateToInfoCCommand = new Command(async () => await NavigateToPage("Info"));
        }

        private async Task NavigateToPage(string pageName)
        {
            var navigation = Application.Current.MainPage.Navigation;
            switch (pageName)
            {
                case "InfoPage":
                    await navigation.PushAsync(new Views.InfoMenu());
                    break;
                case "SeguridadPage":
                    await navigation.PushAsync(new Views.Seguridad());
                    break;
                case "AyudaPage":
                    await navigation.PushAsync(new Views.Ayuda());
                    break;
                case "TarjetaPage":
                    await navigation.PushAsync(new Views.TarjetaCRUD());
                    break;
                case "UbicacionPage":
                    await navigation.PushAsync(new Views.Ubi());
                    break;
                case "MisDatosInfo":
                    await navigation.PushAsync(new Views.MisDatosInfo());
                    break;
                case "Menu":
                    await navigation.PushAsync(new Views.Menu());
                    break;
                case "Info":
                    await navigation.PushAsync(new Views.Info());
                    break;
            }
        }
    }
}
