using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Confoosed.MatchBot;
using Confoosed.MatchBot.Controllers;
using Microsoft.Bot.Connector;

namespace Confoosed.MatchBot.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod, Ignore]
        public void Post()
        {
            // Arrange
            var controller = new MessagesController();

            // Act
            var actual = controller.Post(new Message());

            // Assert
            Assert.AreEqual("", actual.Result);
        }
    }
}