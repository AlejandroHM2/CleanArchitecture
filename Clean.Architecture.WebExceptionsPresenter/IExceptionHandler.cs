using Microsoft.AspNetCore.Mvc.Filters;

namespace Clean.Architecture.WebExceptionsPresenter
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
