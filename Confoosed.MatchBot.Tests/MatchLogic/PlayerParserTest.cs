using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confoosed.MatchLogic;
using Confoosed.MatchLogic.Model;
using Confoosed.MatchLogic.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Confoosed.MatchBot.Tests.MatchLogic
{
    [TestClass]
    public class PlayerParserTest
    {
        [TestMethod]
        public void TryParse()
        {
            Player player1;
            Player player2;
            Assert.IsTrue(PlayerParser.TryParse("@playerA @playerB 1-10", out player1, out player2));
            Assert.AreEqual("@playerA", player1.Id);
            Assert.AreEqual("@playerB", player2.Id);
        }
    }
}