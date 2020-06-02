using System;
using System.Net;
using System.Threading;
using System.Net.Http;

using System.Threading.Tasks;

namespace whitewaterfinder.test
{
    public class DelegatingHandlerStub : DelegatingHandler 
    {
        private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handlerFunc;
        public DelegatingHandlerStub() 
        {
            _handlerFunc = (request, cancellationToken) =>
            {
                return Task.FromResult(request.CreateResponse(HttpStatusCode.OK));
            };
        }

        public DelegatingHandlerStub(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handlerFunc) 
        {
            _handlerFunc = handlerFunc;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) 
        {
            return _handlerFunc(request, cancellationToken);
        }
    }
}