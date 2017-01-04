using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;

namespace Confoosed.MatchBot.Controllers
{
    public class MessagesController : ApiController
    {
        public async Task<Message> Post([FromBody] Message message)
        {
            //Message msg = new Message();
            //msg.Type = "Message";
            //msg.Created = DateTime.Now;
            //msg.ConversationId = message.ConversationId;
            //msg.Id = "123456";
            //msg.Text = message.Text;

            //return await Task.FromResult<Message>(msg);


            return await Response(message);
        }

        public async Task<Message> Get()
        {
            return await Response(new Message("I'm alive"));
        }

        private static async Task<Message> Response(Message message)
        {
            if (message.Text.Equals("ranking", StringComparison.CurrentCultureIgnoreCase))
            {
                var messages = GetMessagesFromThread();
            }
            await Task.Yield();
            return message.CreateReplyMessage("Hello");
        }

        private static IEnumerable<Message> GetMessagesFromThread()
        {
            yield break;
        }
    }
}