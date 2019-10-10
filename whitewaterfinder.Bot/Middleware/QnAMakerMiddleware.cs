using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using whitewaterfinder.Bot.Language;

namespace whitewaterfinder.Bot.Middleware
{
    public class QnAMakerMiddleware : IMiddleware
    {
        private readonly IWebsterQnAMaker _qna;
        private readonly float _confidence;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maker">QnA Maker interface</param>
        /// <param name="confidence">confidence score from configuration</param>
        public QnAMakerMiddleware(IWebsterQnAMaker maker, float confidence)
        {

            _qna = maker ?? throw new ArgumentNullException(nameof(IWebsterQnAMaker));

            _confidence = confidence;
        }
        /// <summary>
        /// handle QnAMaker responses
        /// </summary>
        /// <param name="turnContext"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            // only call qna on message activities if nothing has responded
            if (turnContext.Activity.Type == ActivityTypes.Message &&
                turnContext.Activity.Text != null
                && !turnContext.Responded)
            {
                var answers = await _qna.GetAnswersAsync(turnContext);
                var topAnswer = answers.OrderByDescending(r => r.Score).FirstOrDefault();

                if (answers.Length == 0 || topAnswer != null && topAnswer.Score < _confidence)
                {
                    await turnContext.SendActivityAsync("sorry.  didn't understand that");
                    return;
                }
                if (topAnswer != null && topAnswer.Score > _confidence)
                {
                    await turnContext.SendActivityAsync(topAnswer.Answer);
                    return;
                }
            }

            await next(cancellationToken);

        }
    }    
}