using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;

namespace whitewaterfinder.Bot.Adapters
{
    public class WebsterAdapter : BotFrameworkAdapter, IBotFrameworkHttpAdapter
    {
        public WebsterAdapter(ICredentialProvider creds) :base(creds)
        {
            
        }
        public Task ProcessAsync(HttpRequest httpRequest, HttpResponse httpResponse, IBot bot, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}