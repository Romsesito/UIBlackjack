// ViewModels/InfoViewModel.cs
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using UIBlackjack.Models;
using System.Threading.Tasks;

namespace UIBlackjack.ViewModels
{
    public class InfoViewModel : BindableObject
    {
        private UserData _userData;
        private ObservableCollection<UserData> _userList;

        public UserData UserData
        {
            get => _userData;
            set
            {
                _userData = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserData> UserList
        {
            get => _userList;
            set
            {
                _userList = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand NavigateToPageCommand { get; }

        public InfoViewModel()
        {
            UserData = new UserData();
            UserList = new ObservableCollection<UserData>();

            SaveCommand = new Command(async () => await SaveData());
            NavigateToPageCommand = new Command(async () => await NavigateToPage("Menu"));

            LoadData();
        }

        private async Task NavigateToPage(string pagename)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new Views.Menu());
        }

        private async Task SaveData()
        {
            // Verificar los datos antes de guardar
            System.Diagnostics.Debug.WriteLine($"Guardando datos: Name={UserData.Name}, LastName={UserData.LastName}, fono={UserData.fono}");

            // Guardar los datos en SQLite
            await App.Database.SaveUserDataAsync(UserData);

            // Recargar la lista de usuarios
            LoadData();

            // Limpiar los campos de entrada
            UserData = new UserData();

            // Mostrar mensaje de guardado exitoso
            await Application.Current.MainPage.DisplayAlert("Datos Guardados", "Guardado exitosamente", "OK");
        }

        private async void LoadData()
        {
            var userList = await App.Database.GetUserDataAsync();
            UserList.Clear();
            foreach (var user in userList)
            {
                UserList.Add(user);
            }

            // Asumiendo que deseas mostrar el primer usuario en la lista
            if (UserList.Count > 0)
            {
                UserData = UserList[0];
            }
        }
    }
}