using System;

namespace PlayerManagerMVC
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Controller controller = new Controller();
            PlayerView view = new PlayerView();

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
    }
}