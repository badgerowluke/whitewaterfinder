using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace whitewaterfinder.Bot
{
    public class Webster : ActivityHandler
    {
        private ILogger<Webster> _logger;


        public Webster(ILogger<Webster> logger)
        {
            _logger = logger;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await base.OnMessageActivityAsync(turnContext, cancellationToken);
        }     
    }
}
