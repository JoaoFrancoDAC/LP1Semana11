using System.Collections.Generic;
using System.Linq;

namespace PlayerManagerMVC2
{
    public class ModelData
    {
        private List<Player> players;
        private readonly IComparer<Player> compareByName;
        private readonly IComparer<Player> compareByNameReverse;

        public ModelData()

        {
            players = new List<Player>()
            {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return players;
        }

        public IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            return players.Where(p => p.Score > minScore);
        }

        public void SortPlayers(PlayerOrder order)
        {
            switch (order)
            {
                case PlayerOrder.ByScore:
                    players.Sort();
                    break;
                case PlayerOrder.ByName:
                    players.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    players.Sort(compareByNameReverse);
                    break;
            }
        }
    }
}