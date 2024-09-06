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

    }

}
