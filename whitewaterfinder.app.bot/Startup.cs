﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using whitewaterfinder.Bot;
using whitewaterfinder.Bot.Middleware;
using whitewaterfinder.Bot.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Bot.Builder.ApplicationInsights;
using System;
using System.Reflection;
using System.Collections.Generic;
using whitewaterfinder.Bot.Dialogs;
using whitewaterfinder.Bot.DialogStates;
using whitewaterfinder.Bot.Language;
using whitewaterfinder.Bot.Adapters;

namespace whitewaterfinder.app.bot
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration  { get; }
        private ILoggerFactory _logFactory;
        public Startup(IWebHostEnvironment env, IConfiguration config, ILoggerFactory loggerFactory)
        {
            this.Environment = env;
            this.Configuration = config;
            _logFactory = loggerFactory;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddHttpClient();
            var myConfig = Configuration.Get<WebsterConfig>();
            services.AddSingleton<WebsterConfig>(sp => myConfig);
            services.AddSingleton<ILogger>(_logFactory.CreateLogger<Webster>());
            services.AddApplicationInsightsTelemetry(myConfig.AppInsightsKey);
            services.AddSingleton<IBotTelemetryClient, BotTelemetryClient>();


            IStorage datastore;
            ICredentialProvider creds;

            if(Environment.IsDevelopment())
            {
                datastore = new MemoryStorage();
                creds = new SimpleCredentialProvider("","");
            } else 
            {
                const string DefaultBotContainer = "botstore";
                datastore = new Microsoft.Bot.Builder.Azure.AzureBlobStorage(myConfig.StateStore, DefaultBotContainer);
                creds = new SimpleCredentialProvider(myConfig.MicrosoftAppId, myConfig.MicrosoftAppPassword);
            }
            services.AddSingleton<ICredentialProvider>(sp => creds);
            services.AddSingleton<IStorage>(ds => datastore);

            services.AddSingleton<ConversationState>();
            services.AddSingleton<UserState>();
            services.AddSingleton<IRecognizer, Recognizer>();
            // services.AddSingleton<IWebsterQnAMaker, WebsterQnAMaker>();
            services.AddSingleton<IStatePropertyAccessor<DialogState>>((sp) =>
            {
                var cs = sp.GetService<ConversationState>();
                return cs.CreateProperty<DialogState>(nameof(DialogState));

            });
            services.AddSingleton<IStatePropertyAccessor<WeatherState>>((sp) =>
            {
                var us = sp.GetService<UserState>();
                return us.CreateProperty<WeatherState>(nameof(WeatherState));
            });
            /* Add the dialog(s) as singleton(s) */
            services.AddSingleton<GetWeather>();
            
            /* Build up the DialogSet object */
            services.AddSingleton<DialogSet>((sp) =>
            {
                var ds = new DialogSet(sp.GetService<IStatePropertyAccessor<DialogState>>());       
                ds.Add(sp.GetService<GetWeather>());  
                return ds;
            });

            /* MiddlewareSet is an ordered list of execution objects */  
            var set = new MiddlewareSet();
            set.Use(new AutoSaveStateMiddleware(new BotState[] { services.BuildServiceProvider().GetService<UserState>(), services.BuildServiceProvider().GetService<ConversationState>()}))
                .Use(new MembersAddedMiddleware())
                .Use(new LuisRecognizerMiddleware(services.BuildServiceProvider().GetService<IRecognizer>(), myConfig.LuisConfidence))
                .Use(new InterruptMiddleware(services.BuildServiceProvider().GetService<IStatePropertyAccessor<DialogState>>()))
                .Use(new ContinueDialogMiddleware(services.BuildServiceProvider().GetService<DialogSet>()))
                .Use(new DialogDispatcher(services.BuildServiceProvider().GetService<DialogSet>()));
            
            // .Use(new QnAMakerMiddleware(services.BuildServiceProvider().GetService<IWebsterQnAMaker>(), float.Parse(myConfig.QnAConfidence)));
            services.AddSingleton<IMiddleware>(sp => set);

            // Create the Bot Framework Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();
                      
            // Create the bot as a transient.
            services.AddTransient<IBot, Webster>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
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
