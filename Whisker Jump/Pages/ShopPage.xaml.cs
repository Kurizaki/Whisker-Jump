namespace Whisker_Jump.Pages
{
    public partial class ShopPage : ContentPage
    {
        // Variable to store fish count
        private int fishCount = 13262; // This will later be updated

        public ShopPage()
        {
            InitializeComponent();
            UpdateFishCounter(); // Call this when the page loads to update the label
        }

        // Method to update the fish counter
        private void UpdateFishCounter()
        {
            FishCounter.Text = fishCount.ToString();
        }

        // Back button navigation
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Navigate back to the previous page
        }

        // Event handler for when a shop item is clicked
        private async void OnItemClicked(object sender, EventArgs e)
        {
            // Handle the item click logic, e.g., deduct fish or show an alert
            await DisplayAlert("Item Clicked", "You clicked a shop item!", "OK");
        }
    }
}
