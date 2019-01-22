using AOC2019.Nine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Nine
{
    public class DayNine
    {
        public int PartOne(int playerCount, int lastMarbleWorth)
        {
            var game = new Game(playerCount, lastMarbleWorth);

            game = TakeTurns(game);

            return game.PlayerScore.Values.Max();
        }

        public Game TakeTurns(Game game)
        {
            while (!game.Finished)
            {
                game = TakeTurn(game);
            }

            return game;
        }

        public Game TakeTurn(Game game)
        {
            game.CurrentPlayer = IncrementPlayer(game.CurrentPlayer, game.PlayerCount);
            game.CurrentMarble++;

            // do current turn;
            if (IsScoringMarble(game.CurrentMarble))
            {
                game = Score(game);
            }
            else
            {
                game = NoScore(game);
            }

            if (game.CurrentMarble == game.LastMarbleWorth)
            {
                game.Finished = true;
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

        public Game Score(Game game)
        {
            game.CurrentMarbleIndex = game.CurrentMarbleIndex - 7 >= 0 ? game.CurrentMarbleIndex - 7 : game.CurrentMarbleIndex - 7 + game.Marbles.Count;

            var score = game.CurrentMarble + game.Marbles[game.CurrentMarbleIndex];

            game.PlayerScore[game.CurrentPlayer] += score;

            game.Marbles.RemoveAt(game.CurrentMarbleIndex);            

            if (score == game.LastMarbleWorth)
            {
                game.Finished = true;                
            }

            return game;
        }

        public Game NoScore(Game game)
        {
            game.CurrentMarbleIndex = game.CurrentMarbleIndex + 2 <= game.Marbles.Count ? game.CurrentMarbleIndex + 2 : game.CurrentMarbleIndex + 2 - game.Marbles.Count;

            game.Marbles.Insert(game.CurrentMarbleIndex, game.CurrentMarble);

            return game;
        }

        
    }
}
