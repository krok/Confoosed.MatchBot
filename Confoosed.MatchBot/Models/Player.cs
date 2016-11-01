using System.Collections.Generic;

namespace Confoosed.MatchBot.Models
{
    public class Player
    {
        private readonly IList<Match> _matches;

        public Player(string id)
        {
            Id = id;
            _matches = new List<Match>();
        }

        public string Id { get; }

        public int? Ranking { get; set; }

        public IEnumerable<Match> GetMatches()
        {
            return _matches;
        }

        public void AddMatch(Match match)
        {
            _matches.Add(match);
        }
    }
}