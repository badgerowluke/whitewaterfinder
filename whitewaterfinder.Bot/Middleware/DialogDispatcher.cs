using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder.Dialogs;
using whitewaterfinder.Bot.Models;
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
                await Stuff(dialogContext, result);
            }
            await next(cancellationToken);
        }
        private async Task Stuff(DialogContext dc, string dialogResult)
        {
            if(!string.IsNullOrEmpty(dialogResult))
            {
                /* assuming here that the dialog and the luis result will match */
                var newDialog = dc.FindDialog(dialogResult);
                await newDialog.BeginDialogAsync(dc);
            }

        }
    }
}