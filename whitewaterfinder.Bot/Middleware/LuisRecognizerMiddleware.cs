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
            
        }

        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            await next(cancellationToken);
        }
    }
}