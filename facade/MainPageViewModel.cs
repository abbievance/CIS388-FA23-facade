using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace facade
{
    public partial class MainPageViewModel: ObservableObject
    {
        [ObservableProperty]
        private string secretColor;

        [ObservableProperty]
        private string currentGuess;

        public ObservableCollection<string> Guesses { get; set; }

        public MainPageViewModel()
        {
            secretColor = "FACADE";
            currentGuess = "";
        }

        [RelayCommand]
        void AddLetter(string letter)
        {
            if (CurrentGuess.Length < 6)
            {
               CurrentGuess += letter;
            }
        }

        void Guess()
        {
            // if correct, did win = true
            // if this is the 6th guess and its wrong, didwin=false
            // add this guess to guesses
            Guesses.Add(CurrentGuess);
        }


    }
}
