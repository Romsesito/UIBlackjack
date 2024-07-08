using Microsoft.Maui.Controls;
using UIBlackjack.ViewModels;

namespace UIBlackjack.Views;

public partial class Info : ContentPage
{
	public Info()
	{
		InitializeComponent();
        BindingContext = new InfoViewModel();
    }
}