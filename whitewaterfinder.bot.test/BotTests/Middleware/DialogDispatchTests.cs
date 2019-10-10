using whitewaterfinder.Bot.Middleware;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Testing;
using Microsoft.Bot.Builder.Adapters;
using Microsoft.Bot.Builder.Dialogs;
using Xunit;
using Moq;
using System.Threading;
using whitewaterfinder.Bot.test.Fakes;

using System.Threading.Tasks;
using System;
using whitewaterfinder.Bot.DialogStates;
using whitewaterfinder.Bot.Dialogs;

namespace whitewaterfinder.Bot.test.BotTests.Middleware
{
    public abstract class BaseDialogDispatchTests
    {
        protected Mock<IRecognizer> mockRecognizer;
        protected Mock<IStatePropertyAccessor<DialogState>> mockStateAccessor;
        public BaseDialogDispatchTests()
        {
            mockRecognizer = new Mock<IRecognizer>();
            mockStateAccessor = new Mock<IStatePropertyAccessor<DialogState>>();
            mockStateAccessor.Setup(x => x.GetAsync(It.IsAny<ITurnContext>(), It.IsAny<Func<DialogState>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new DialogState());
        }

    }
    public class DialogDispatcherShould : BaseDialogDispatchTests
    {
        [Fact]
        public async Task StartsWeatherDialog()
        {
            var dialogSet = new DialogSet(mockStateAccessor.Object);
            var weatherState = new Mock<IStatePropertyAccessor<WeatherState>>();
            dialogSet.Add(new GetWeather(weatherState.Object));



            var adapter = new TestAdapter()
            .Use(new LuisMiddlewareFake("GetWeather"))
            .Use(new DialogDispatcher(dialogSet));
            
            await new TestFlow(adapter, async (context, ct) =>
            {
                
            }).Send("what's the weather")
            .AssertReply("I'm really going to need to get back to you on this")
            .AssertReply("I'm still growing in what I'm capable of doing")
            .StartTestAsync();

        }
    }
}