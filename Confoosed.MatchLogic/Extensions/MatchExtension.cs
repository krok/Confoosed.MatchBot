﻿using System.Collections.Generic;
using System.Linq;
using Confoosed.MatchLogic.Model;

namespace Confoosed.MatchLogic.Extensions
{
    public static class MatchExtension
    {
        public static IEnumerable<Group> GetGroups(this IEnumerable<FoosMatch> matches)
        {
            var groups = new List<Group>();
            foreach (var match in matches)
            {
                var g1 = groups.GetGroupByPlayer(match.Winner);
                var g2 = groups.GetGroupByPlayer(match.Looser);

                if (g1 == null && g2 == null)
                {
                    groups.Add(new Group {Players = {match.Winner, match.Looser}});
                    continue;
                }

                if (g1 != null && g2 == null)
                {
                    g1.Players.Add(match.Looser);
                    continue;
                }

                if (g1 == null)
                {
                    g2.Players.Add(match.Winner);
                    continue;
                }

                if (g1.Id != g2.Id)
                    groups.JoinGroups(g1, g2);
            }
            return groups;
        }

        public static IOrderedEnumerable<Group> GetGroupsBySize(this IEnumerable<FoosMatch> matches)
        {
            return matches.GetGroups().GetGroupsBySize();
        }

        public static IEnumerable<Player> GetPlayers(this IEnumerable<FoosMatch> matches)
        {
            var list = matches.ToList();
            return
                list.Select(m => m.Winner)
                    .Union(list.Select(m => m.Looser))
                    .Distinct()
                    .ToList();
        }
    }
}