// ViewModels/InfoViewModel.cs
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace UIBlackjack.ViewModels
{
    public class InfoViewModel
    {
        public ICommand NavigateToPageCommand { get; }

        public InfoViewModel()
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
