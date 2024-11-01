namespace Whisker_Jump.Pages
{
    public partial class ShopPage : ContentPage
    {
        private int _fishCount = 13262;

        public ShopPage()
        {
            InitializeComponent();
            UpdateFishCounter();
        }

        private void UpdateFishCounter()
        {
            FishCounter.Text = _fishCount.ToString();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnItemClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Item Clicked", "You clicked a shop item!", "OK");
        }
    }
}
