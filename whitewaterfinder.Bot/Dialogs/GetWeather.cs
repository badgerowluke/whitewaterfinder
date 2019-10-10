using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using whitewaterfinder.Bot.DialogStates;

namespace whitewaterfinder.Bot.Dialogs
{
    public class GetWeather : ComponentDialog
    {
        private readonly IStatePropertyAccessor<WeatherState> _stateAccessor;
        public GetWeather(IStatePropertyAccessor<WeatherState> stateAccessor) : base(nameof(GetWeather))
        {
            _stateAccessor = stateAccessor;
            AddDialog(new WaterfallDialog("tellWeather", new WaterfallStep[]
            {
                TellTheWeather
            }));
        }
        private async Task<DialogTurnResult> TellTheWeather(WaterfallStepContext step, CancellationToken token)
        {
            await step.Context.SendActivityAsync("I'm really going to need to get back to you on this");
            await step.Context.SendActivityAsync("I'm still growing in what I'm capable of doing");
            return await step.EndDialogAsync();
        }
    }
}