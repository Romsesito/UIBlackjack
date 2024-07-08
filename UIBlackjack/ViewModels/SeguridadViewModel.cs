using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UIBlackjack.ViewModels
{
    public class SeguridadViewModel
    {

        public ICommand NavigateToPageCommand { get; }

        public SeguridadViewModel()
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
