using System.Collections.ObjectModel;

namespace facade;

[QueryProperty("DidWin", "DidWin")]
public partial class GameOverPage : ContentPage

{

    public GameOverPage(bool didWin, ObservableCollection<ColorGuess> guesses, string colorName, Color colorBackground)
	{
		InitializeComponent();

        gridColor.BackgroundColor = colorBackground;
        labelText.Text = colorName;

        if (didWin)
        {
            ResultLabel.Text = "You Won!";
        }
        else
        {
            ResultLabel.Text = "You Lost!";
        }

        switch (guesses.Count)
        {
            case 1:
                guess1.BackgroundColor = guesses[0].Color;
                break;
            case 2:
                guess1.BackgroundColor = guesses[0].Color;
                guess2.BackgroundColor = guesses[1].Color;
                break;
            case 3:
                guess1.BackgroundColor = guesses[0].Color;
                guess2.BackgroundColor = guesses[1].Color;
                guess3.BackgroundColor = guesses[2].Color;
                break;
            case 4:
                guess1.BackgroundColor = guesses[0].Color;
                guess2.BackgroundColor = guesses[1].Color;
                guess3.BackgroundColor = guesses[2].Color;
                guess4.BackgroundColor = guesses[3].Color;
                break;
            case 5:
                guess1.BackgroundColor = guesses[0].Color;
                guess2.BackgroundColor = guesses[1].Color;
                guess3.BackgroundColor = guesses[2].Color;
                guess4.BackgroundColor = guesses[3].Color;
                guess5.BackgroundColor = guesses[4].Color;
                break;
            case 6:
                guess1.BackgroundColor = guesses[0].Color;
                guess2.BackgroundColor = guesses[1].Color;
                guess3.BackgroundColor = guesses[2].Color;
                guess4.BackgroundColor = guesses[3].Color;
                guess5.BackgroundColor = guesses[4].Color;
                guess6.BackgroundColor = guesses[5].Color;
                break;



        }



    }
    async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new MainPage());
    }
}
