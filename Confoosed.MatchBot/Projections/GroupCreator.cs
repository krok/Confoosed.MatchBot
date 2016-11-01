using System.Collections.Generic;
using Confoosed.MatchBot.Extensions;
using Confoosed.MatchBot.Models;

namespace Confoosed.MatchBot.Projections
{
    internal class GroupCreator
    {
        public static IEnumerable<Group> GetGroups(IEnumerable<Match> matches)
        {
            var groups = new List<Group>();
            foreach (var match in matches)
            {
                var g1 = groups.GetGroup(match.Winner);
                var g2 = groups.GetGroup(match.Looser);

                if (g1 == null && g2 == null)
                {
                    groups.Add(new Group { Players = { match.Winner, match.Looser } });
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
                    Join(groups, g1, g2);
            }
            return groups;
        }

        private static void Join(ICollection<Group> groups, Group g1, Group g2)
        {
            foreach (var player in g2.Players)
                g1.Players.Add(player);
            groups.Remove(g2);
        }
    }
}