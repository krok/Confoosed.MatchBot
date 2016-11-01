using System;
using System.Collections.Generic;
using System.Linq;
using Confoosed.MatchBot.Common;
using Confoosed.MatchBot.Models;
using Confoosed.MatchBot.Projections;

namespace Confoosed.MatchBot.Extensions
{
    public static class GroupExtension
    {
        public static IOrderedEnumerable<Group> GetGroupsBySize(this IEnumerable<Group> groups)
        {
            return groups.OrderByDescending(g => g.Players.Count)
                .ThenBy(g => g.GetMatches().Select(m => m.Registered).Max(), Comparer<DateTime>.Default.Reverse());
        }

        internal static Group GetGroup(this IEnumerable<Group> groups, Player player)
        {
            return groups.FirstOrDefault(g => g.Players.Any(p => p.Id == player.Id));
        }

        public static IOrderedEnumerable<Player> GetPlayersByRanking(this IEnumerable<Group> groups)
        {
            var list = groups.ToList();
            if(list.Any(g=> g.Players.Any(p=>!p.Ranking.HasValue)))
                Ranking.RankPlayers(list);
            return list.GetGroupsBySize().SelectMany(p => p.Players).OrderBy(p => p.Ranking);
        }
    }
}