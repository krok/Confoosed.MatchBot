using System;

namespace Confoosed.MatchBot.Models
{
    public class Match
    {
        private static int _idCounter = 1;

        public Match(Player winner, Player looser)
            : this(winner, looser, null, null, DateTime.UtcNow)
        {
        }

        public Match(Player winner, Player looser, int? goalsWinner, int? looserWinner)
            : this(winner, looser, goalsWinner, looserWinner, DateTime.UtcNow)
        {
        }

        public Match(Player winner, Player looser, int? goalsWinner, int? looserWinner, DateTime registered)
        {
            Winner = winner;
            Looser = looser;
            GoalsWinner = goalsWinner;
            LooserWinner = looserWinner;
            Registered = registered;
            Id = _idCounter++;
            winner.AddMatch(this);
            looser.AddMatch(this);
        }

        public int Id { get; set; }

        public DateTime Registered { get; }
        public Player Winner { get; }
        public Player Looser { get; }

        public int? GoalsWinner { get; }
        public int? LooserWinner { get; }
    }
}