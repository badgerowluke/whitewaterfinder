using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.Dialogs;
using whitewaterfinder.Bot.Models;
using whitewaterfinder.Bot.Dialogs;

namespace whitewaterfinder.Bot.Middleware
{
    public class DialogDispatcher : IMiddleware
    {
        private readonly DialogSet _dialogs;
        public DialogDispatcher(DialogSet set)
        {
            _dialogs = set; 
        }
        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            if(!turnContext.Responded && turnContext.Activity.Type == ActivityTypes.Message)
            {
                var dialogContext = await _dialogs.CreateContextAsync(turnContext);
                var result = turnContext.TurnState.Get<string>(LuisResults.TopResult.ToString());
                if(!string.IsNullOrEmpty(result))
                {
                    switch(result)
                    {
                        case "GetWeather":
                            await dialogContext.BeginDialogAsync(nameof(GetWeather));
                            break;
                        default:
                            break;
                    }
                }
            }
            await next(cancellationToken);
        }
    }
}