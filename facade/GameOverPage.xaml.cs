namespace facade;

[QueryProperty("DidWin", "DidWin")]
public partial class GameOverPage : ContentPage
{
    private bool didWin;
    public bool DidWin
    {
        get => didWin;
        set
        {
            didWin = value;
            if (didWin)
            {
                ResultLabel.Text = "You Won!";
            }
            else
            {
                ResultLabel.Text = "You Lost!";
            }
        }
    }

    public GameOverPage()
	{
		InitializeComponent();
	}
    async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
