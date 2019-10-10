using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.Dialogs;
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
            await next(cancellationToken);
        }
    }
}