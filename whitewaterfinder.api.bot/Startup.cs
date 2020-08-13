using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Bot.Builder.ApplicationInsights;

using whitewaterfinder.Bot.Dialogs;
using whitewaterfinder.Bot.DialogStates;
using whitewaterfinder.Bot.Language;
using whitewaterfinder.Bot.Adapters;

using whitewaterfinder.Bot;
using whitewaterfinder.Bot.Middleware;
using whitewaterfinder.Bot.Models;


[assembly: FunctionsStartup(typeof(whitewaterfinder.api.bot.Startup))]
namespace whitewaterfinder.api.bot
{
    public class Startup : FunctionsStartup 
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()

                .Build();

            var myConfig = config.Get<WebsterConfig>();
            builder.Services.AddSingleton<WebsterConfig>(sp => myConfig);
            // builder.Services.AddSingleton<ILogger>();
            builder.Services.AddApplicationInsightsTelemetry(myConfig.AppInsightsKey);            
            builder.Services.AddSingleton<IBotTelemetryClient, BotTelemetryClient>();
            IStorage datastore;
            ICredentialProvider creds;




            if(Convert.ToBoolean(Environment.GetEnvironmentVariable("IsDevelopment")))
            {
                datastore = new MemoryStorage();
                creds = new SimpleCredentialProvider("","");
            } else 
            {
                const string DefaultBotContainer = "botstore";
                datastore = new Microsoft.Bot.Builder.Azure.AzureBlobStorage(myConfig.StateStore, DefaultBotContainer);
                creds = new SimpleCredentialProvider(myConfig.MicrosoftAppId, myConfig.MicrosoftAppPassword);
            }
            builder.Services.AddSingleton<ICredentialProvider>(sp => creds);
            builder.Services.AddSingleton<IStorage>(ds => datastore);

            builder.Services.AddSingleton<ConversationState>();
            builder.Services.AddSingleton<UserState>();
            builder.Services.AddSingleton<IRecognizer, Recognizer>();
            // services.AddSingleton<IWebsterQnAMaker, WebsterQnAMaker>();
            builder.Services.AddSingleton<IStatePropertyAccessor<DialogState>>((sp) =>
            {
                var cs = sp.GetService<ConversationState>();
                return cs.CreateProperty<DialogState>(nameof(DialogState));

            });
            builder.Services.AddSingleton<IStatePropertyAccessor<WeatherState>>((sp) =>
            {
                var us = sp.GetService<UserState>();
                return us.CreateProperty<WeatherState>(nameof(WeatherState));
            });
            /* Add the dialog(s) as singleton(s) */
            builder.Services.AddSingleton<GetWeather>();
            
            /* Build up the DialogSet object */
            builder.Services.AddSingleton<DialogSet>((sp) =>
            {
                var ds = new DialogSet(sp.GetService<IStatePropertyAccessor<DialogState>>());       
                ds.Add(sp.GetService<GetWeather>());  
                return ds;
            });



            var set = new MiddlewareSet();
            set.Use(new AutoSaveStateMiddleware(new BotState[] { builder.Services.BuildServiceProvider().GetService<UserState>()
                                                    , builder.Services.BuildServiceProvider().GetService<ConversationState>()}))
                .Use(new MembersAddedMiddleware())
                .Use(new LuisRecognizerMiddleware(builder.Services.BuildServiceProvider().GetService<IRecognizer>(), myConfig.LuisConfidence))
                .Use(new InterruptMiddleware(builder.Services.BuildServiceProvider().GetService<IStatePropertyAccessor<DialogState>>()))
                .Use(new ContinueDialogMiddleware(builder.Services.BuildServiceProvider().GetService<DialogSet>()))
                .Use(new DialogDispatcher(builder.Services.BuildServiceProvider().GetService<DialogSet>()));



            // .Use(new QnAMakerMiddleware(services.BuildServiceProvider().GetService<IWebsterQnAMaker>(), float.Parse(myConfig.QnAConfidence)));
            builder.Services.AddSingleton<IMiddleware>(sp => set);

            // Create the Bot Framework Adapter with error handling enabled.
            builder.Services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();
                      
            // Create the bot as a transient.
            builder.Services.AddTransient<IBot, Webster>();                

        }
    }

}