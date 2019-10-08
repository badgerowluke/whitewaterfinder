// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.BotFramework;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.DependencyInjection;
using whitewaterfinder.Bot;
using whitewaterfinder.Bot.Middleware;
using Microsoft.Extensions.Logging;

namespace whitewaterfinder.app.bot
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public Startup(IHostingEnvironment env)
        {
            this.Environment = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);




            IStorage datastore;
            if(Environment.IsDevelopment())
            {
                datastore = new MemoryStorage();
            } else 
            {
                const string DefaultBotContainer = "botstore";
                datastore = new Microsoft.Bot.Builder.Azure.AzureBlobStorage("", DefaultBotContainer);
            }
            services.AddSingleton<IStorage>(ds => datastore);

            services.AddSingleton<ConversationState>();
            services.AddSingleton<UserState>();
            services.AddSingleton<IRecognizer, Recognizer>();

            var set = new MiddlewareSet();
            set.Use(new MembersAddedMiddleware());
            set.Use(new LuisRecognizerMiddleware(services.BuildServiceProvider().GetService<IRecognizer>()));
            services.AddSingleton<IMiddleware>(sp => set);

            // Create the Bot Framework Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();
                      
            // Create the bot as a transient.
            services.AddTransient<IBot, Webster>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
