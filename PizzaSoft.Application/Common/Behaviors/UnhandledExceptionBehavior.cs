using MediatR;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Common.Behaviors
{
    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _log;

        public UnhandledExceptionBehavior(ILogger logger)
        {
            logger.ForContext<TRequest>();
            _log = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _log.Error(ex, "Applicant: Unhandled Exception for Request {Name} {@Request}",
                    requestName, request);
                throw;
            }
        }
    }
}
