using System;
using System.Collections.Generic;

namespace PlayerManagerMVC2
{
    public class PlayerView
    {
        public void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("----");
            Console.WriteLine("1. Insert player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List players with score greater than");
            Console.WriteLine("4. Sort players");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice > ");
        }

        public void ListPlayers(IEnumerable<Player> players)
        {
            Console.WriteLine("\nList of players");
            Console.WriteLine("-------------\n");
            foreach (Player p in players)
            {
                Console.WriteLine($" -> {p.Name} with a score of {p.Score}");
            }
            Console.WriteLine();
        }

        public string GetPlayerName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }

        public int GetPlayerScore()
        {
            Console.Write("Score: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetMinimumScore()
        {
            Console.Write("\nMinimum score player should have? ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public PlayerOrder GetSortOrder()
        {
            Console.WriteLine("\nSort order:");
            Console.WriteLine("0. By score");
            Console.WriteLine("1. By name");
            Console.WriteLine("2. By name (reverse)");
            Console.Write("Your choice > ");
            int choice = Convert.ToInt32(Console.ReadLine());
            return (PlayerOrder)choice;
        }
    }
}