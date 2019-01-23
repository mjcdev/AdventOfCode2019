using AOC2019.Nine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Nine
{
    public class DayNine
    {
        public long GetMaxScore(int playerCount, int lastMarbleWorth)
        {
            var game = new Game(playerCount, lastMarbleWorth);

            game = TakeTurns(game, lastMarbleWorth);

            return game.PlayerScore.Values.Max();
        }

        public Game TakeTurns(Game game, int lastMarbleWorth)
        {
            for (var marbleValue = 1; marbleValue <= lastMarbleWorth; marbleValue++)
            {
                game = TakeTurn(game, marbleValue);
            }

            return game;
        }

        public Game TakeTurn(Game game, int marbleValue)
        {
            game.CurrentPlayer = IncrementPlayer(game.CurrentPlayer, game.PlayerScore.Count);

            if (IsScoringMarble(marbleValue))
            {
                game = Score(game, marbleValue);
            }
            else
            {
                game = NoScore(game, marbleValue);
            }
                        
            return game;
        }

        public int IncrementPlayer(int currentPlayer, int playerCount)
        {
            if (currentPlayer < playerCount - 1)
            {
                return currentPlayer + 1;
            }

            return 0;            
        }

        public bool IsScoringMarble(int currentMarble)
        {
            return currentMarble % 23 == 0;
        }

        public Game Score(Game game, int marbleValue)
        {
            game.CurrentNode = game.CurrentNode
                .MovePreviousNode()
                .MovePreviousNode()
                .MovePreviousNode()
                .MovePreviousNode()
                .MovePreviousNode()
                .MovePreviousNode();                

            var score = marbleValue + game.CurrentNode.MovePreviousNode().Value;

            game.PlayerScore[game.CurrentPlayer] += score;

            game.Marbles.Remove(game.CurrentNode.MovePreviousNode());
                        
            return game;
        }

        public Game NoScore(Game game, int marbleValue)
        {            
            game.CurrentNode = game.Marbles.AddBefore(game.CurrentNode.MoveNextNode().MoveNextNode(), marbleValue);

            return game;
        }
    }
}
