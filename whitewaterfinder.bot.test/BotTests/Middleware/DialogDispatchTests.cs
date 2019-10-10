using whitewaterfinder.Bot.Middleware;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Testing;
using Microsoft.Bot.Builder.Adapters;
using Microsoft.Bot.Builder.Dialogs;
using Xunit;
using Moq;
using whitewaterfinder.Bot.Language;
using System.Threading.Tasks;

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
        }

    }
    public class DialogDispatcherShould : BaseDialogDispatchTests
    {
        [Fact]
        public async Task StartsWeatherDialog()
        {
            var dialogSet = new DialogSet(mockStateAccessor.Object);

            var adapter = new TestAdapter()
            .Use(new LuisRecognizerMiddleware(mockRecognizer.Object, 0.9))
            .Use(new DialogDispatcher(dialogSet));
            
            await new TestFlow(adapter, async(context, ct) =>
            {
                
            }).Send("what's the weather")
            .AssertReply("")
            .StartTestAsync();

        }
    }
}