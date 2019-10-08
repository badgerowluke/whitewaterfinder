using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
namespace whitewaterfinder.Bot.Middleware
{
    public class MembersAddedMiddleware : IMiddleware
    {
        public async Task OnTurnAsync(ITurnContext context, NextDelegate next, CancellationToken token = default(CancellationToken))
        {
            const string WelcomeText = "I hope to be able to help you find out the water level of your favorite river.";

            if (context.Activity.Type == ActivityTypes.ConversationUpdate &&
                context.Activity.MembersAdded != null &&
                (from m in context.Activity.MembersAdded where m.Id == context.Activity.Recipient.Id select m).Any())
            {
                    await context.SendActivityAsync(MessageFactory.Text($"Hi I'm Webster! {WelcomeText}"), token);
            }
            await next(token);
        }
    }
}