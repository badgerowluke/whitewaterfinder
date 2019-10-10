using System.Threading.Tasks;
using System.Threading;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace whitewaterfinder.Bot.test.Fakes
{
    public class LuisMiddlewareFake : IMiddleware
    {
        private readonly string _intent;
        public LuisMiddlewareFake(string intentName)
        {
            _intent = intentName;
        }
        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            turnContext.TurnState.Add("TopResult", _intent);
            await next(cancellationToken);
        }
    }
}