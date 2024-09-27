using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using System.Collections.Generic;
using Whisker_Jump.Models;
using Microsoft.Maui.Layouts;
using Whisker_Jump.Pages;

namespace Whisker_Jump
{
    public partial class MainPage : ContentPage
    {
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
        private IDispatcherTimer? gameTimer;
        private SettingsPage? settingsPageInstance = null;
        private ShopPage? shopPageInstance = null;
        private bool isNavigatingToSettings = false;
        private bool isNavigatingToShop = false;

        public MainPage()
        {
            InitializeComponent();
            InitializeJoystick();
            highScore = new HighScore();
            HighScoreLabel.Text = highScore.Value.ToString();
            InitializeGameTimer();
        }

        private void InitializeGameTimer()
        {
            gameTimer = Dispatcher.CreateTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(16); 
            gameTimer.Tick += OnGameTick;
        }

        private void OnGameTick(object? sender, EventArgs e)
        {
            if (!isGameOver)
            {
                UpdateCharacterPosition();
                CheckPlatformCollision();
                UpdateScore();
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
            }

            if (isGameStarted && e.StatusType == GestureStatus.Running)
            {
                characterX += e.TotalX * JoystickSensitivity / 100;

                if (characterX < 0) characterX = 0;
                if (characterX > Width - Character.Width) characterX = Width - Character.Width;

                Character.TranslationX = characterX;
            }

            if (isGameStarted && e.StatusType == GestureStatus.Completed && !isJumping)
            {
                isJumping = true;
                velocity = JumpSpeed; 
            }
        }


        private void PlayButtonClicked(object sender, EventArgs args)
        {
            MainMenu.IsVisible = false;
            GameScreen.IsVisible = true;
            isGameOver = false;

            ResetGame();
            GenerateInitialPlatforms();
            CreateCharacter();
            gameTimer?.Start();
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
        }

        private void GenerateInitialPlatforms()
        {
            platforms.Clear();
            PlatformsLayout.Children.Clear();

            for (int i = 0; i < PlatformCount; i++)
            {
                double platformX = random.Next(0, (int)(Width - 150));
                double platformY = Height - (i * PlatformSpacing) - 200;

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
            }

            if (platforms.Count > 0)
            {
                var firstPlatform = platforms[0];
                firstPlatform.TranslationX = (Width - firstPlatform.Width) / 2;
                firstPlatform.TranslationY = Height - 300;  
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

                if (characterBottom >= platformTop && characterTop <= platformBottom &&
                    characterX + Character.Width >= platform.TranslationX && characterX <= platform.TranslationX + platform.Width)
                {
                    if (velocity > 0)
                    {
                        velocity = 0;
                        characterY = platformTop - Character.Height;
                        isJumping = false;
                    }
                }
            }
        }

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
                    GeneratePlatformAbove();
                }
            }
        }

        private void GeneratePlatformAbove()
        {
            double platformX = random.Next(0, (int)(Width - 150));
            double platformY = -30;

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
        }

        private void GameOver()
        {
            isGameOver = true;
            gameTimer?.Stop();
            DisplayAlert("Game Over", "You fell!", "OK");
            MainMenu.IsVisible = true;
            GameScreen.IsVisible = false;
            highScore.Save((int)characterY);
            HighScoreLabel.Text = highScore.Value.ToString();
            ResetGame();
        }

        private void UpdateScore()
        {
            if (characterY > highScore.Value)
            {
                highScore.Value = (int)characterY; 
                HighScoreLabel.Text = highScore.Value.ToString();
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
                    settingsPageInstance = new SettingsPage();
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
    }
}
