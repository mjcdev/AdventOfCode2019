using System.Collections.Generic;

namespace AOC2019.Nine.Model
{
    public class Game
    {
        public Game(int playerCount, int lastMarbleWorth)
        {
            PlayerScore = new Dictionary<int, long>();

            for (var i = 0; i < playerCount; i++)
            {
                PlayerScore.Add(i, 0);
            }

            Marbles = new LinkedList<int>();            

            Marbles.AddFirst(0);

            CurrentNode = Marbles.First;
        }
                        
        public int CurrentPlayer { get; set; } = - 1;
        
        public LinkedList<int> Marbles { get; set; }

        public LinkedListNode<int> CurrentNode { get; set; }

        public Dictionary<int, long> PlayerScore { get; set; }
    }
}
