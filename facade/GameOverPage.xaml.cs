using System.Collections.ObjectModel;

namespace facade;

[QueryProperty("DidWin", "DidWin")]
public partial class GameOverPage : ContentPage

{


    public GameOverPage(bool didWin, ObservableCollection<ColorGuess> guesses)
	{
		InitializeComponent();

        if (didWin)
        {
            ResultLabel.Text = "You Won!";
        }
        else
        {
            ResultLabel.Text = "You Lost!";
        }

        guess1.BackgroundColor = guesses[0].Color;
        guess2.BackgroundColor = guesses[1].Color;
        guess3.BackgroundColor = guesses[2].Color;
        guess4.BackgroundColor = guesses[3].Color;
        guess5.BackgroundColor = guesses[4].Color;
        guess6.BackgroundColor = guesses[5].Color;
    }
    async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
