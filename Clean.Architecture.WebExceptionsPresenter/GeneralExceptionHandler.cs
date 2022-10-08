using Clean.Architecture.Entities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clean.Architecture.WebExceptionsPresenter
{
    public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as GeneralException;
            return SetResult(
                context,
                StatusCodes.Status500InternalServerError,
                exception.Message,
                exception.Detail);
        }
    }
}
