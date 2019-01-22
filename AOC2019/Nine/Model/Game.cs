using System.Collections.Generic;

namespace AOC2019.Nine.Model
{
    public class Game
    {
        public Game(int playerCount, int lastMarbleWorth)
        {
            PlayerCount = playerCount;
            LastMarbleWorth = lastMarbleWorth;

            PlayerScore = new Dictionary<int, int>();

            for (var i = 0; i < PlayerCount; i++)
            {
                PlayerScore.Add(i, 0);
            }
        }

        public bool Finished { get; set; }

        public int PlayerCount { get; set; }

        public int CurrentMarble { get; set; }

        public int CurrentMarbleIndex { get; set; } = 0;

        public int CurrentPlayer { get; set; } = - 1;

        public int LastMarbleWorth { get; set; }

        public List<int> Marbles { get; set; } = new List<int>() { 0 };

        public Dictionary<int, int> PlayerScore { get; set; }
    }
}
