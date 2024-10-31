using Microsoft.Maui.Layouts;
using Plugin.Maui.Audio;
using Whisker_Jump.Models; // Import für HighScore
using Whisker_Jump.Pages; // Import für SettingsPage und ShopPage
// HALLO, PUBLIC IAUDIOPLAYER? _AUDIOMANAGER; ? UND PUBLIC SIND NACHER IMPLEMENTIERT WORDE SUST GEHT NICHT FALLS NICHT PUBLIC YK YK? ZEILE 443 PLAY MUSIC AU NO ÄNDERTLOLOLOLOLOL

namespace Whisker_Jump
{
    public partial class MainPage : ContentPage
    {
        private readonly IAudioManager _audioManager;
        public IAudioPlayer? _audioPlayer;
        private double characterY;
        private double characterX;
        private const double JumpSpeed = -15;
        private const double Gravity = 0.5;
        private double velocity;
        private const double JoystickSensitivity = 5;
        private bool isJumping;
        private bool isGameOver;
        private bool isGameStarted;
        private readonly List<BoxView> platforms = new();
        private BoxView Character = null!;
        private readonly Random random = new();
        private const int PlatformCount = 6;
        private const double PlatformSpacing = 150;
        private readonly HighScore highScore;
        private int sessionHighScore; // tracking session HS
        private IDispatcherTimer? gameTimer;
        private IDispatcherTimer? highScoreTimer;
        private SettingsPage? settingsPageInstance = null;
        private ShopPage? shopPageInstance = null;
        private bool isNavigatingToSettings = false;
        private bool isNavigatingToShop = false;
        private int currentScore;

        // Parameterloser Konstruktor
        public MainPage() : this(new AudioManager())
        {
        }

        public MainPage(IAudioManager audioManager)
        {
            _audioManager = audioManager;
            InitializeComponent();
            InitializeJoystick();

            highScore = new HighScore();
            sessionHighScore = 0; // Initialize session high score to 0
            LoadHighScore();
            MainMenuHighScoreLabel.Text = $"High Score: {highScore.Value}";

            InitializeGameTimer();
            InitializeHighScoreTimer();
        }

        private void LoadHighScore()
        {
            highScore.Value = highScore.Load(); // Load the all-time high score from storage
            sessionHighScore = 0; // Reset session high score at the start of a new session
            MainMenuHighScoreLabel.Text = $"High Score: {highScore.Value}"; // Display all-time high score on main menu
            GameScreenHighScoreLabel.Text = $"High Score: {highScore.Value}"; // Display on the game screen
            HighScoreCounter.Text = sessionHighScore.ToString(); // Initialize session score display to 0
        }


        private void InitializeGameTimer()
        {
            gameTimer = Dispatcher.CreateTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameTimer.Tick += OnGameTick;
        }

        private void InitializeHighScoreTimer()
        {
            highScoreTimer = Dispatcher.CreateTimer();
            highScoreTimer.Interval = TimeSpan.FromSeconds(2);
            highScoreTimer.Tick += OnHighScoreTick;
        }

        private void OnGameTick(object? sender, EventArgs e)
        {
            if (!isGameOver)
            {
                UpdateCharacterPosition();
                CheckPlatformCollision();
                GeneratePlatformAboveIfNeeded();
            }
        }

        private void OnHighScoreTick(object? sender, EventArgs e)
        {
            if (!isGameOver && isGameStarted)
            {
                currentScore += 100; // Increase score as needed
                ScoreLabel.Text = $"Score: {currentScore}"; // Display the current score on the screen

                // Check if the current score beats the session high score
                if (currentScore > sessionHighScore)
                {
                    sessionHighScore = currentScore;
                    HighScoreCounter.Text = sessionHighScore.ToString(); // Update session high score display
                }

                // Update all-time high score if session high score exceeds it
                if (sessionHighScore > highScore.Value)
                {
                    highScore.Save(sessionHighScore); // Save the new all-time high score to persistent storage
                    GameScreenHighScoreLabel.Text = $"High Score: {highScore.Value}"; // Update high score on game screen
                }
            }
        }


        private void UpdateCharacterPosition()
        {
            velocity += Gravity;
            characterY += velocity;

            if (characterY < Height / 2)
            {
                MovePlatformsDown(Height / 2 - characterY);
                characterY = Height / 2;
            }

            Character.TranslationY = characterY;
            Character.TranslationX = characterX;

            if (characterY > Height + Character.Height)
            {
                GameOver();
            }

            if (!isJumping && velocity >= 0)
            {
                isJumping = true;
                velocity = JumpSpeed;
            }
        }

        private void InitializeJoystick()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnJoystickPanUpdated!;
            Joystick.GestureRecognizers.Add(panGesture);
        }

        private void OnJoystickPanUpdated(object? sender, PanUpdatedEventArgs e)
        {
            if (!isGameStarted && e.StatusType == GestureStatus.Running)
            {
                isGameStarted = true;
                gameTimer?.Start();
                highScoreTimer?.Start();
            }

            if (isGameStarted && e.StatusType == GestureStatus.Running)
            {
                characterX += e.TotalX * JoystickSensitivity / 100;
                Character.TranslationX = characterX;
            }
        }

        private async void PlayButtonClicked(object sender, EventArgs args)
        {
            MainMenu.IsVisible = false;
            GameScreen.IsVisible = true;
            isGameOver = false;

            ResetGame();
            GenerateInitialPlatforms();
            CreateCharacter();
            gameTimer?.Start();
            highScoreTimer?.Start();
            await PlayMusic();

            ScoreLabel.Text = "Score: 0"; // Reset the score label
        }

        private void CreateCharacter()
        {
            Character = new BoxView
            {
                Color = Colors.Red,
                WidthRequest = 80,
                HeightRequest = 80,
                CornerRadius = 40,
                BackgroundColor = Colors.Transparent
            };

            characterX = (Width - Character.WidthRequest) / 2;
            characterY = (Height - Character.HeightRequest) / 5;

            velocity = 0;

            AbsoluteLayout.SetLayoutBounds(Character, new Rect(characterX, characterY, 80, 80));
            AbsoluteLayout.SetLayoutFlags(Character, AbsoluteLayoutFlags.None);

            PlatformsLayout.Children.Add(Character);
        }

        private void ResetGame()
        {
            isGameStarted = false;
            isJumping = false;
            velocity = 0;
            characterY = 0;
            characterX = 0;
            platforms.Clear();
            PlatformsLayout.Children.Clear();
            currentScore = 0; // Reset the current score
            ScoreLabel.Text = "Score: 0"; // Reset the score label
        }

        private void GenerateInitialPlatforms()
        {
            platforms.Clear();
            PlatformsLayout.Children.Clear();

            double previousPlatformY = Height - 200;
            for (int i = 0; i < PlatformCount; i++)
            {
                double platformX = random.Next(0, (int)(Width - 150));
                double platformY = previousPlatformY - PlatformSpacing;

                var platform = new BoxView
                {
                    Color = Colors.SaddleBrown,
                    WidthRequest = 150,
                    HeightRequest = 30
                };

                AbsoluteLayout.SetLayoutBounds(platform, new Rect(platformX, platformY, 150, 30));
                AbsoluteLayout.SetLayoutFlags(platform, AbsoluteLayoutFlags.None);

                PlatformsLayout.Children.Add(platform);
                platforms.Add(platform);

                previousPlatformY = platformY;
            }
        }

        private void CheckPlatformCollision()
        {
            foreach (var platform in platforms)
            {
                double platformTop = platform.TranslationY;
                double platformBottom = platformTop + platform.Height;
                double characterBottom = characterY + Character.Height;
                double characterTop = characterY;

                if (velocity > 0 && characterBottom >= platformTop && characterTop <= platformBottom &&
                    characterX + Character.Width >= platform.TranslationX && characterX <= platform.TranslationX + platform.Width)
                {
                    velocity = 0;
                    characterY = platformTop - Character.Height;
                    isJumping = false;
                }
            }
        }

        private const int MaxPlatformCount = 10;

        private void MovePlatformsDown(double distance)
        {
            for (int i = platforms.Count - 1; i >= 0; i--)
            {
                var platform = platforms[i];
                platform.TranslationY += distance;

                if (platform.TranslationY > Height)
                {
                    PlatformsLayout.Children.Remove(platform);
                    platforms.RemoveAt(i);
                }
            }

            if (platforms.Count < MaxPlatformCount)
            {
                GeneratePlatformAboveIfNeeded();
            }
        }

        private void GeneratePlatformAboveIfNeeded()
        {
            if (platforms.Count == 0 || (platforms[^1].TranslationY > PlatformSpacing && platforms.Count < MaxPlatformCount))
            {
                GeneratePlatformAbove();
            }
        }

        private void GeneratePlatformAbove()
        {
            bool platformPlaced = false;
            int maxAttempts = 10;
            int attempts = 0;

            while (!platformPlaced && attempts < maxAttempts)
            {
                attempts++;

                double platformWidth = random.Next(100, 200);
                double platformX = random.Next(0, (int)(Width - platformWidth));
                double platformY = -30;

                bool overlaps = false;

                foreach (var existingPlatform in platforms)
                {
                    double existingPlatformTop = existingPlatform.TranslationY;
                    double existingPlatformBottom = existingPlatformTop + existingPlatform.Height;
                    double existingPlatformLeft = existingPlatform.TranslationX;
                    double existingPlatformRight = existingPlatformLeft + existingPlatform.Width;

                    double newPlatformTop = platformY;
                    double newPlatformBottom = platformY + 30;
                    double newPlatformLeft = platformX;
                    double newPlatformRight = platformX + platformWidth;

                    if (!(newPlatformRight < existingPlatformLeft || newPlatformLeft > existingPlatformRight ||
                          newPlatformBottom < existingPlatformTop || newPlatformTop > existingPlatformBottom))
                    {
                        overlaps = true;
                        break;
                    }
                }

                if (!overlaps)
                {
                    var platform = new BoxView
                    {
                        Color = Colors.SaddleBrown,
                        WidthRequest = platformWidth,
                        HeightRequest = 30
                    };

                    AbsoluteLayout.SetLayoutBounds(platform, new Rect(platformX, platformY, platformWidth, 30));
                    AbsoluteLayout.SetLayoutFlags(platform, AbsoluteLayoutFlags.None);

                    PlatformsLayout.Children.Add(platform);
                    platforms.Add(platform);
                    platformPlaced = true;
                }
            }

            RemoveOldPlatforms();
        }

        private void RemoveOldPlatforms()
        {
            for (int i = platforms.Count - 1; i >= 0; i--)
            {
                if (platforms[i].TranslationY > Height)
                {
                    PlatformsLayout.Children.Remove(platforms[i]);
                    platforms.RemoveAt(i);
                }
            }
        }

        private void GameOver()
        {
            if (!isGameOver)
            {
                isGameOver = true;
                gameTimer?.Stop();
                highScoreTimer?.Stop();
                DisplayAlert("Game Over", "You fell!", "OK");

                // Check and save if current session score exceeds all-time high score
                if (sessionHighScore > highScore.Value)
                {
                    highScore.Save(sessionHighScore);
                }

                LoadHighScore(); // Reload to update the displayed high scores

                MainMenu.IsVisible = true;
                GameScreen.IsVisible = false;
                ResetGame();
                StopMusic();
            }
        }

        private async void SettingsButtonClicked(object sender, EventArgs args)
        {
            if (isNavigatingToSettings)
                return;

            isNavigatingToSettings = true;

            try
            {
                if (settingsPageInstance == null)
                {
                    settingsPageInstance = new SettingsPage(this); // Pass the current instance of MainPage
                }

                if (!Navigation.NavigationStack.Contains(settingsPageInstance))
                {
                    await Navigation.PushAsync(settingsPageInstance);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                isNavigatingToSettings = false;
            }
        }

        private async void ShopButtonClicked(object sender, EventArgs args)
        {
            if (isNavigatingToShop)
                return;

            isNavigatingToShop = true;

            try
            {
                if (shopPageInstance == null)
                {
                    shopPageInstance = new ShopPage();
                }

                if (!Navigation.NavigationStack.Contains(shopPageInstance))
                {
                    await Navigation.PushAsync(shopPageInstance);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                isNavigatingToShop = false;
            }
        }

        public async Task PlayMusic()
        {
            try
            {
                var filePath = Path.Combine(FileSystem.AppDataDirectory, "WhiskerJump.mp3");
                if (!File.Exists(filePath))
                {
                    using var stream = await FileSystem.OpenAppPackageFileAsync("Resources/Music/WhiskerJump.mp3");
                    using var fileStream = File.Create(filePath);
                    await stream.CopyToAsync(fileStream);
                }

                _audioPlayer = _audioManager.CreatePlayer(filePath);
                _audioPlayer.Loop = true;

                // Set the volume to the current slider value or a default value
                _audioPlayer.Volume = 0.5; // Set initial volume to 50% or use a variable if needed
                _audioPlayer.Play(); // Start playback
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing music: {ex.Message}");
            }
        }

        public void StopMusic()
        {
            _audioPlayer?.Stop();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            highScore.Save(currentScore);
        }
    }
}
