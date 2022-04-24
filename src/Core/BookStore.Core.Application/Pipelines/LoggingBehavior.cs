using BookStore.Core.Application.Contracts;
using BookStore.Core.Application.Contracts.Persistence.Write;
using BookStore.Core.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Pipelines
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IAsyncWriteRepository<RequestResponseLog> _logger;
        private readonly IUserDataService _userData;

        public LoggingBehavior(IAsyncWriteRepository<RequestResponseLog> logger, IUserDataService userData)
        {
            _logger = logger;
            this._userData = userData;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;
            try
            {
                response = await next();
            }
            finally
            {
                var dataLog = RequestResponseLog.Create(_userData.CurrentURL, JsonConvert.SerializeObject(request), JsonConvert.SerializeObject(response));
                await _logger.AddItem(dataLog);
            }
            return response;
        }
    }
}
