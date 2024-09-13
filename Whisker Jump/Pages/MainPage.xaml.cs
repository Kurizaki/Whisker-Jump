using System;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System.Collections.Generic;
using Whisker_Jump.Pages;
using Microsoft.Maui.Layouts;

namespace Whisker_Jump
{
    public partial class MainPage : ContentPage
    {
        private double characterY;
        private double characterX;
        private double jumpSpeed = -15;
        private double gravity = 0.5;
        private double velocity = 0;
        private double joystickSensitivity = 5;
        private bool isJumping = false;
        private bool isGameOver = false;
        private bool isGameStarted = false;
        private List<BoxView> platforms = new List<BoxView>();
        private BoxView Character;
        private Random random = new Random();
        private int platformCount = 6;
        private double platformSpacing = 150;

        public MainPage()
        {
            InitializeComponent();
            InitializeJoystick();
        }

        private void InitializeJoystick()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnJoystickPanUpdated;
            Joystick.GestureRecognizers.Add(panGesture);
        }

        private void OnJoystickPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (!isGameStarted && e.StatusType == GestureStatus.Running)
            {
                isGameStarted = true;
                StartJumping();
            }

            if (isGameStarted && e.StatusType == GestureStatus.Running)
            {
                characterX += e.TotalX * joystickSensitivity / 100;

                if (characterX < 0) characterX = this.Width;
                if (characterX > this.Width) characterX = 0;

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
        }

        private void CreateCharacter()
        {
            Character = new BoxView
            {
                Color = Colors.Red,
                WidthRequest = 80,
                HeightRequest = 100
            };

            if (platforms.Count > 0)
            {
                var firstPlatform = platforms[0];

                characterX = firstPlatform.TranslationX + firstPlatform.Width / 2 - Character.Width / 2;
                characterY = firstPlatform.TranslationY - Character.Height;

                velocity = 0;

                AbsoluteLayout.SetLayoutBounds(Character, new Rect(characterX, characterY, 80, 100));
                AbsoluteLayout.SetLayoutFlags(Character, AbsoluteLayoutFlags.None);

                PlatformsLayout.Children.Add(Character);
            }
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

            for (int i = 0; i < platformCount; i++)
            {
                double platformX = random.Next(0, (int)(this.Width - 150));
                double platformY = this.Height - (i * platformSpacing) - 100;

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
        }

        private async void StartJumping()
        {
            velocity = 0;

            while (!isGameOver)
            {
                velocity += gravity;
                characterY += velocity;

                if (characterY < this.Height / 2)
                {
                    MovePlatformsDown(characterY - this.Height / 2);
                    characterY = this.Height / 2;
                }

                Character.TranslationY = characterY;

                CheckPlatformCollision();

                if (platforms[0].TranslationY > this.Height)
                {
                    GeneratePlatformAbove();
                }

                if (characterY > this.Height + Character.Height)
                {
                    GameOver();
                    break;
                }

                await Task.Delay(16);
            }
        }

        private void CheckPlatformCollision()
        {
            foreach (var platform in platforms)
            {
                double platformTop = platform.TranslationY;
                double platformBottom = platformTop + platform.Height;
                double characterBottom = characterY + Character.Height;

                if (characterBottom >= platformTop && characterBottom <= platformBottom &&
                    characterX + Character.Width >= platform.TranslationX && characterX <= platform.TranslationX + platform.Width)
                {
                    if (velocity > 0)
                    {
                        velocity = jumpSpeed;
                    }
                }
            }
        }

        private void MovePlatformsDown(double distance)
        {
            foreach (var platform in platforms)
            {
                platform.TranslationY += distance;

                if (platform.TranslationY > this.Height)
                {
                    PlatformsLayout.Children.Remove(platform);
                    platforms.Remove(platform);
                    GeneratePlatformAbove();
                }
            }
        }

        private void GeneratePlatformAbove()
        {
            double platformX = random.Next(0, (int)(this.Width - 150));
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
            DisplayAlert("Game Over", "You fell!", "OK");
            MainMenu.IsVisible = true;
            GameScreen.IsVisible = false;
            ResetGame();
        }

        private async void SettingsButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void ShopButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ShopPage());
        }
    }
}
