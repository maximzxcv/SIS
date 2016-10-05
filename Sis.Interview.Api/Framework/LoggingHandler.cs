using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sis.Interview.Api.Framework
{
    public class LoggingHandler : DelegatingHandler
    {
        private readonly ILog _logger;

        public LoggingHandler(ILog logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestUnique = Guid.NewGuid();
            _logger.Debug($"Request url: {request.RequestUri} ({requestUnique})");
            var response = await base.SendAsync(request, cancellationToken);
            _logger.Debug($"Response: {response.StatusCode} ({requestUnique})");
            return response;
        }
    }
}