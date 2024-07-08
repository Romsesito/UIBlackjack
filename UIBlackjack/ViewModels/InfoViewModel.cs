
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
        private Tarjeta _tarjetaData;
        private ObservableCollection<Tarjeta> _tarjetaList;

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

        public Tarjeta TarjetaData
        {
            get => _tarjetaData;
            set
            {
                _tarjetaData = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Tarjeta> TarjetaList
        {
            get => _tarjetaList;
            set
            {
                _tarjetaList = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand NavigateToPageCommand { get; }

        public InfoViewModel()
        {
            UserData = new UserData();
            UserList = new ObservableCollection<UserData>();
            TarjetaData = new Tarjeta();
            TarjetaList = new ObservableCollection<Tarjeta>();

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
    
            System.Diagnostics.Debug.WriteLine($"Guardando datos: Name={UserData.Name}, LastName={UserData.LastName}, fono={UserData.fono}");
            System.Diagnostics.Debug.WriteLine($"Guardando tarjeta: Numero={TarjetaData.NumTarjeta}, Expiracion={TarjetaData.FechaEXP}, CVV={TarjetaData.CVV}");

   
            await App.Database.SaveUserDataAsync(UserData);
            await App.Database.SaveTarjetaDataAsync(TarjetaData);

       
            LoadData();

            UserData = new UserData();
            TarjetaData = new Tarjeta();

 
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

            var tarjetaList = await App.Database.GetTarjetaDataAsync();
            TarjetaList.Clear();
            foreach (var tarjeta in tarjetaList)
            {
                TarjetaList.Add(tarjeta);
            }

            // Asumiendo que deseas mostrar el primer usuario y tarjeta en la lista
            if (UserList.Count > 0)
            {
                UserData = UserList[0];
            }

            if (TarjetaList.Count > 0)
            {
                TarjetaData = TarjetaList[0];
            }
        }
    }
}
