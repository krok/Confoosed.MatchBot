using System.Collections.Generic;
using System.Linq;
using Confoosed.MatchBot.Models;
using Confoosed.MatchBot.Projections;

namespace Confoosed.MatchBot.Extensions
{
    public static class MatchExtension
    {
        public static IEnumerable<Group> GetGroups(this IEnumerable<Match> matches)
        {
            return GroupCreator.GetGroups(matches);
        }

        public static IOrderedEnumerable<Group> GetGroupsBySize(this IEnumerable<Match> matches)
        {
            return matches.GetGroups().GetGroupsBySize();
        }

        public static IEnumerable<Player> GetPlayers(this IEnumerable<Match> matches)
        {
            var list = matches.ToList();
            return
                list.Select(m => m.Winner)
                    .Union(list.Select(m => m.Looser))
                    .Distinct()
                    .ToList();
        }

        public static IOrderedEnumerable<Player> GetPlayersByRanking(this IEnumerable<Match> matches)
        {
            return matches.GetGroupsBySize().GetPlayersByRanking();
        }
    }
}