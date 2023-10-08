using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;

namespace facade
{
    public partial class MainPageViewModel: ObservableObject
    {
        public bool DidWin { get; set; } = true;


        [ObservableProperty]
        /*private Color secretColor;*/
        private string secretColor;

        [ObservableProperty]
        private Color textColor;

        [ObservableProperty]
        private string currentGuess;

        public ObservableCollection<ColorGuess> Guesses { get; set; }


        public MainPageViewModel()
        {
            /*secretColor = Color.FromArgb("#beefed");*/
            // I got this random string thing from the internet btw, I did not come up with it
            // from https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
            var characters = "ABCDEF";
            var stringCharacters = new char[6];
            var random = new Random();

            for (int i = 0; i < stringCharacters.Length; i++)
            {
                stringCharacters[i] = characters[random.Next(characters.Length)];
            }


            secretColor = new string(stringCharacters);
            textColor = Color.FromArgb($"#{secretColor.ToLower()}");
            currentGuess = "";
            Guesses = new ObservableCollection<ColorGuess>();
        }

        [RelayCommand]
        void AddLetter(string letter)
        {
            if (CurrentGuess.Length < 6)
            {
               CurrentGuess += letter;
            }
        }

        [RelayCommand]
        void RemoveLetter()
        {
            if (CurrentGuess.Length > 0)
            {
                CurrentGuess = CurrentGuess.Remove(CurrentGuess.Length - 1);
            }
            
        }

        [RelayCommand]
        async Task Guess()
        {
            // if correct, did win = true
            // if this is the 6th guess and its wrong, didwin=false
            // add this guess to guesses
            Guesses.Add(new ColorGuess(CurrentGuess));

            if (CurrentGuess.Equals(SecretColor))
            {
                DidWin = true;
                await Shell.Current.Navigation.PushAsync(new GameOverPage(DidWin, Guesses, SecretColor, TextColor));
                Guesses.Clear();
            }
            if (Guesses.Count == 6 && (CurrentGuess.Equals(SecretColor) == false))
            {
                DidWin = false;
                await Shell.Current.Navigation.PushAsync(new GameOverPage(DidWin, Guesses, SecretColor, TextColor));
                Guesses.Clear();
            }
            CurrentGuess = "";

        }

    }
}
