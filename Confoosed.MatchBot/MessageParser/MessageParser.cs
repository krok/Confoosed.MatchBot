using System.Collections.Generic;
using System.Linq;
using Confoosed.MatchLogic.Model;
using Confoosed.MatchLogic.Parsing;
using Microsoft.Bot.Connector;

namespace Confoosed.MatchBot.MessageParser
{
    public class MessageParser
    {
        public static IEnumerable<FoosMatch> GetMatches(IEnumerable<Message> messages)
        {
            FoosMatch match = null;
            return messages.Where(m => MatchParser.TryParse(m.Text, out match)).Select(m => match);
        }
    }
}