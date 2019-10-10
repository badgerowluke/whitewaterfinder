namespace whitewaterfinder.Bot.Models
{
    public class WebsterConfig
    {
        public string MicrosoftAppId { get; set; }
        public string MicrosoftAppPassword { get; set; }
        public string LuisAppId { get; set; }
        public string LuisAPIKey { get; set; }
        public string LuisAPIHostName { get; set; }
        public double LuisConfidence { get; set; }
        public string QnAKnowledgebaseId { get; set; }
        public string QnAEndpointKey { get; set; }
        public string QnAEndpointHostName { get; set; }  
        public string QnAConfidence { get; set; }
        public string StateStore { get; set; }    
        public string AppInsightsKey { get; set; }  
        public string[] LoadedDialogs { get; set; }

    }
}