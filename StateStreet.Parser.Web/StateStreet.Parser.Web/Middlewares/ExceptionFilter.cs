using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using InvalidDataToMapException = StateStreet.Parser.Web.Exceptions.InvalidDataToMapException;

namespace StateStreet.Parser.Web.Middlewares
{
    public class ExceptionFilter : IAsyncExceptionFilter // TODO: global exception handler
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<ExceptionFilter>>();

            string message;

            switch (context.Exception)
            {
                case InvalidDataToMapException ex:
                    message = ex.Message;
                    break;

                default:
                    message = "Unknown error occurred.";
                    break;
            }

            logger.LogError(context.Exception, message);

            return Task.CompletedTask;
        }
    }
}
