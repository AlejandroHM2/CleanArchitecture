using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Clean.Architecture.WebExceptionsPresenter
{
    public class ExceptionHandlerBase
    {
        readonly Dictionary<int, string> RFC7231Types = new Dictionary<int, string>
        {
            {
                StatusCodes.Status500InternalServerError,
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            },
            {
                StatusCodes.Status400BadRequest,
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"
            }
        };

        public Task SetResult(
            ExceptionContext context, int? status, string title, string detail)
        {
            ProblemDetails Detail1 = new ProblemDetails
            {
                Status = status,
                Title = title,
                Type = RFC7231Types.ContainsKey(status.Value) ?
                RFC7231Types[status.Value] : string.Empty,
                Detail = detail
            };
            context.Result = new ObjectResult(Detail1)
            {
                StatusCode = status,
            };
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
