using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Extensions.Configuration;
using whitewaterfinder.Bot.Models;

namespace whitewaterfinder.Bot.Language
{
    public interface IWebsterQnAMaker
    {
        Task<QueryResult[]> GetAnswersAsync(ITurnContext context, QnAMakerOptions options = null);
    }
    public class WebsterQnAMaker : IWebsterQnAMaker
    {
        private readonly QnAMaker _maker;

        public WebsterQnAMaker(WebsterConfig config, IHttpClientFactory client)
        {
            _maker = new QnAMaker(new QnAMakerEndpoint
            {
                KnowledgeBaseId = config.QnAKnowledgebaseId,
                EndpointKey = config.QnAEndpointKey,
                Host = config.QnAEndpointHostName
                
            },
            null,
            client.CreateClient());
        }

        public async Task<QueryResult[]> GetAnswersAsync(ITurnContext turnContext, QnAMakerOptions options = null)
        {
            return await _maker.GetAnswersAsync(turnContext);
        }        
    }
}