using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.Dialogs;

namespace whitewaterfinder.Bot.Middleware
{
    public class InterruptMiddleware : IMiddleware
    {
        private readonly IStatePropertyAccessor<DialogState> _dialogStateACcessor;
        public InterruptMiddleware(IStatePropertyAccessor<DialogState> dialogStateAccessor)
        {
            _dialogStateACcessor = dialogStateAccessor;
        }
        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            if(turnContext.Activity.Type == ActivityTypes.Message)
            {
                var luisResult = turnContext.TurnState.Get<string>("TopResult");
                if(luisResult.Equals("Cancel"))
                {
                    /* end the current dialog */
                    await _dialogStateACcessor.SetAsync(turnContext, new DialogState(), cancellationToken);
                }
            }
            await next(cancellationToken);
        }
    }
}