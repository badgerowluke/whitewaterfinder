using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace whitewaterfinder.Bot.Middleware
{
    public class LuisRecognizerMiddleware : IMiddleware
    {
        private readonly IRecognizer _recognizer;
        public LuisRecognizerMiddleware(IRecognizer recognize)
        {
            _recognizer = recognize;
        }

        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            if(turnContext.Activity.Type == ActivityTypes.Message)
            {
                var results = await _recognizer.RecognizeAsync(turnContext, cancellationToken);
                var topIntent = results.GetTopScoringIntent();
                turnContext.TurnState.Add("TopResult", topIntent.intent);
            }

            await next(cancellationToken);

        }
    }
}