using Whisker_Jump.Pages;

namespace Whisker_Jump
{
    public partial class MainPage : ContentPage
    {
        private int coinCount;
        public MainPage()
        {
            InitializeComponent();
            coinCount = 13262;
            UpdateCoinDisplay();
        }
        private void UpdateCoinDisplay()
        {
            CoinCountLabel.Text = coinCount.ToString();
        }

        private async void SettingsButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
        private async void PlayButtonClicked(object sender, EventArgs args)
        {
            //hide menu items and start gameloop
            await Navigation.PushAsync(new SettingsPage());
        }
        private async void ShopButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ShopPage());
        }
    }

}
