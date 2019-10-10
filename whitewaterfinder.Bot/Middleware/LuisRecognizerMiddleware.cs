using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using whitewaterfinder.Bot.Models;

namespace whitewaterfinder.Bot.Middleware
{
    public class LuisRecognizerMiddleware : IMiddleware
    {
        private readonly IRecognizer _recognizer;
        private readonly double _confidence;
        public LuisRecognizerMiddleware(IRecognizer recognize, double confidence)
        {
            _recognizer = recognize;
            _confidence = confidence;

        }

        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            if(turnContext.Activity.Type == ActivityTypes.Message)
            {
                var results = await _recognizer.RecognizeAsync(turnContext, cancellationToken);
                var topIntent = results.GetTopScoringIntent();
                
                if(topIntent.score >= _confidence)
                {
                    turnContext.TurnState.Add(LuisResults.TopResult.ToString(), topIntent.intent);
                }
            }

            await next(cancellationToken);

        }
    }
}