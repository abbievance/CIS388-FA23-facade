using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace facade
{
    public partial class MainPageViewModel: ObservableObject
    {
        public bool DidWin { get; set; } = true;

        [ObservableProperty]
        /*private Color secretColor;*/
        private string secretColor;

        [ObservableProperty]
        private string currentGuess;

        public ObservableCollection<ColorGuess> Guesses { get; set; }


        public MainPageViewModel()
        {
            /*secretColor = Color.FromArgb("#beefed");*/
            secretColor = "FACADE";
            currentGuess = "";
            Guesses = new ObservableCollection<ColorGuess>();
            var color = new ColorGuess("beaded");

            Guesses.Add(color);
            Guesses.Add(color);
            Guesses.Add(color);
            Guesses.Add(color);
            Guesses.Add(color);
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
                await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
                Guesses.Clear();
            }
            if (Guesses.Count == 6 && (CurrentGuess.Equals(SecretColor) == false))
            {
                DidWin = false;
                await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={DidWin}");
                Guesses.Clear();

            }
            CurrentGuess = "";

        }




    }
}
