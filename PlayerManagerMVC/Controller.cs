using System.Collections.Generic;

namespace PlayerManagerMVC
{
    public class Controller
    {
        private ModelData model;

        public Controller()
        {
            model = new ModelData();
        }

        public void AddPlayer(string name, int score)
        {
            model.AddPlayer(new Player(name, score));
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return model.GetAllPlayers();
        }

        public IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            return model.GetPlayersWithScoreGreaterThan(minScore);
        }

        public void SortPlayers(PlayerOrder order)
        {
            model.SortPlayers(order);
        }
    }
}