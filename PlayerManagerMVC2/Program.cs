using System;
using System.IO;

namespace PlayerManagerMVC2
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No file provided");
                return;
            }

            string filename = args[0];
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File '{filename}' not found");
                return;
            }

            Controller controller = new Controller();
            PlayerView view = new PlayerView();

            ReadPlayersFromFile(filename, controller);

            bool exit = false;
            while (!exit)
            {
                view.ShowMenu();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        string name = view.GetPlayerName();
                        int score = view.GetPlayerScore();
                        controller.AddPlayer(name, score);
                        break;
                    case "2":
                        view.ListPlayers(controller.GetAllPlayers());
                        break;
                    case "3":
                        int minScore = view.GetMinimumScore();
                        view.ListPlayers(controller.GetPlayersWithScoreGreaterThan(minScore));
                        break;
                    case "4":
                        PlayerOrder order = view.GetSortOrder();
                        controller.SortPlayers(order);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
        private static void ReadPlayersFromFile(string filename, Controller controller)
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    int score;
                    if (int.TryParse(parts[1].Trim(), out score))
                    {
                        controller.AddPlayer(name, score);
                    }
                }
            }
    
        }
    }
}