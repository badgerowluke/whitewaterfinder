using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.Dialogs;
namespace whitewaterfinder.Bot.Middleware
{
    public class ContinueDialogMiddleware : IMiddleware
    {
        private readonly DialogSet _dialogs;
        public ContinueDialogMiddleware(DialogSet set)
        {
            _dialogs = set;
        }
        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            // only proccess messages if nothing has responded yet
            if (!turnContext.Responded && turnContext.Activity.Type == ActivityTypes.Message)
            {
                // create context
                var dialogContext = await _dialogs.CreateContextAsync(turnContext);

                // try to continue 
                var dialogResult = await dialogContext.ContinueDialogAsync();

                // if no dialog responded check the status
                if (!dialogContext.Context.Responded)
                {
                    switch (dialogResult.Status)
                    {
                        case DialogTurnStatus.Empty:
                            // let following middleware decide what to do
                            break;
                        case DialogTurnStatus.Waiting:
                            // The active dialog is waiting for a response from the user, so do nothing.
                            break;
                        case DialogTurnStatus.Complete:
                            await dialogContext.EndDialogAsync();
                            break;
                        case DialogTurnStatus.Cancelled:
                            await dialogContext.CancelAllDialogsAsync();
                            break;
                        default:
                            // let next middleware have it.
                            break;
                    }
                }
            }            
            await next(cancellationToken);
        }
    }
}