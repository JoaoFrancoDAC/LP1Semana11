using System;
using System.Collections.Generic;

public class Model
{
    public IDictionary<string, string> WordsWithHints { get; private set; }
    public string ChosenWord { get; private set; }
    public string Hint { get; private set; }
    public char[] Display { get; private set; }

    public Model()
    {
        WordsWithHints = new Dictionary<string, string>()
        {
            { "apple", "fruit" },
            { "banana", "fruit" },
            { "tiger", "animal" },
            { "elephant", "animal" },
            { "guitar", "instrument" },
            { "violin", "instrument" },
            { "canada", "country" },
            { "brazil", "country" },
            { "laptop", "object" },
            { "microscope", "scientific instrument" }
        };
    }

    public Model(IDictionary<string, string> wordsWithHints)
    {
        WordsWithHints = wordsWithHints;
    } 

    public void SelectRandomWord()
    {
        Random rand = new Random();
        List<string> words = new List<string>(WordsWithHints.Keys);
        ChosenWord = words[rand.Next(words.Count)];
        Hint = WordsWithHints[ChosenWord];
    }

    public void InitializeDisplay()
    {
        int length = ChosenWord.Length;
        int numToReveal = Math.Max(1, (int)Math.Floor(length * 0.4));
        Display = new string('_', length).ToCharArray();

        int seed = ChosenWord.GetHashCode();
        Random maskRand = new Random(seed);

        HashSet<int> revealedIndices = new HashSet<int>();
        while (revealedIndices.Count < numToReveal)
        {
            int index = maskRand.Next(length);
            revealedIndices.Add(index);
        }

        foreach (int i in revealedIndices)
        {
            Display[i] = ChosenWord[i];
        }
    }

    public bool IsCorrectGuess(string guess)
    {
        return guess.Trim().ToLower() == ChosenWord;
    }
}