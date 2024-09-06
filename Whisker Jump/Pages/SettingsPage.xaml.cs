using Microsoft.Maui.Controls;

namespace Whisker_Jump.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Navigate back to MainMenu.xaml
            await Navigation.PushAsync(new MainPage());
        }
    }
}
