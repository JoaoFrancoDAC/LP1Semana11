using System;

public class View
{
    public void DisplayIntro(string hint, string display)
    {
        Console.WriteLine("Guess the full word!");
        Console.WriteLine($"Hint: It's a {hint}.");
        Console.WriteLine($"Word: {display}");
    }

    public string GetGuess()
    {
        Console.Write("Your guess: ");
        return Console.ReadLine().Trim().ToLower();
    }

    public void DisplayIncorrectGuess()
    {
        Console.WriteLine("Incorrect. Try again.");
    }

    public void DisplayCorrectGuess(string chosenWord)
    {
        Console.WriteLine("Correct! Well done!");
        Console.WriteLine($"The word was \"{chosenWord}\".");
    }
}