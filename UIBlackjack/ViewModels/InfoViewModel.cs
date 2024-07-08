// ViewModels/InfoViewModel.cs
using System.Windows.Input;
using Microsoft.Maui.Controls;
using UIBlackjack.Models;

namespace UIBlackjack.ViewModels
{
    public class InfoViewModel : BindableObject

    {
        private UserData _userData;
        public UserData UserData
        {
            get => _userData;
            set
            {
                _userData = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand NavigateToPageCommand { get; }

        public InfoViewModel()
        {
            NavigateToPageCommand = new Command(async () => await NavigateToPage("Menu"));
            SaveCommand = new Command(async () => await SaveData());
        }

        private async Task NavigateToPage(string pagename)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new Views.Menu());

        }


  

        private async Task SaveData()
        {
            // Aquí puedes agregar la lógica para guardar los datos

            // Mostrar mensaje de guardado exitoso
            await Application.Current.MainPage.DisplayAlert("Datos Guardados", "Guardado exitosamente", "OK");
        }
    }
}
