using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0 || !File.Exists(args[0]))
        {
            Model model = new Model();
            View view = new View();
            Controller controller = new Controller(model, view);
            Console.WriteLine("Rodando sem File");
            controller.RunGame();
        }
        else
        {
            string filename = args[0];
            Dictionary<string, string> dictionaryFromFile = new Dictionary<string, string>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string word = parts[0].Trim().ToLower();
                        string hint = parts[1].Trim();
                        dictionaryFromFile.Add(word, hint);
                    }
                }
            }
            Model model = new Model(dictionaryFromFile);
            View view = new View();
            Controller controller = new Controller(model, view);
            Console.WriteLine("Rodando com File");
            controller.RunGame();
        }
    }
}