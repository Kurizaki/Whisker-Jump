namespace Whisker_Jump.Pages
{
    public partial class SettingsPage : ContentPage
    {
        private readonly MainPage _mainPage;

        public SettingsPage(MainPage mainPage)
        {
            InitializeComponent();
            _mainPage = mainPage;
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnVolumeSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (_mainPage._audioPlayer != null)
            {
                _mainPage._audioPlayer.Volume = e.NewValue;
            }
        }
    }
}
