using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Extensions.Configuration;


namespace whitewaterfinder.Bot
{
    public class Recognizer : IRecognizer
    {
        private readonly LuisRecognizer _recognizer;
        
        public Recognizer(IConfiguration config)
        {
            var luisIsConfigured = !string.IsNullOrEmpty(config["LuisAppId"]) 
            && !string.IsNullOrEmpty(config["LuisAPIKey"]) 
            && !string.IsNullOrEmpty(config["LuisAPIHostName"]);
            if (luisIsConfigured)
            {


                _recognizer = new LuisRecognizer(new LuisApplication(
                    config["LuisAppId"],
                    config["LuisAPIKey"],
                    $"https://{config["LuisAPIHostName"]}.cognitiveservices.azure.com"), 
                    new LuisPredictionOptions{IncludeAllIntents = true, IncludeInstanceData = true},
                    true);
            }              
        }
        public async Task<RecognizerResult> RecognizeAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        => await _recognizer.RecognizeAsync(turnContext, cancellationToken);
        public async Task<T> RecognizeAsync<T>(ITurnContext turnContext, CancellationToken cancellationToken) where T : IRecognizerConvert, new()
        {
            return await _recognizer.RecognizeAsync<T>(turnContext, cancellationToken);
        }        
    }
}