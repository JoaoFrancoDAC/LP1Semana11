public class Controller
{
    private Model model;
    private View view;

    public Controller(Model model, View view)
    {
        this.model = model;
        this.view = view;
    }

    public void RunGame()
    {
        model.SelectRandomWord();
        model.InitializeDisplay();

        view.DisplayIntro(model.Hint, new string(model.Display));

        string guess;
        do
        {
            guess = view.GetGuess();

            if (!model.IsCorrectGuess(guess))
                view.DisplayIncorrectGuess();
        } while (!model.IsCorrectGuess(guess));

        view.DisplayCorrectGuess(model.ChosenWord);
    }
}