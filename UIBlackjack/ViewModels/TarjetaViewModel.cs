using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UIBlackjack.ViewModels
{
    public class TarjetaViewModel
    {
        public ICommand NavigateToPageCommand { get; }

        public TarjetaViewModel()
        {
            NavigateToPageCommand = new Command(async () => await NavigateToPage("Menu"));
        }

        private async Task NavigateToPage(string pagename)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new Views.Menu());

        }
    }
}
