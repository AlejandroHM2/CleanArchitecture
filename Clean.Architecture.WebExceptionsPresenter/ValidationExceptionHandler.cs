﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Clean.Architecture.WebExceptionsPresenter
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            StringBuilder builder = new();
            foreach (var failure in exception.Errors)
            {
                builder.AppendLine(string.Format("Propiedad: {0}. Error: {1}",
                    failure.PropertyName, failure.ErrorMessage));
            }

            return SetResult(
                context,
                StatusCodes.Status400BadRequest,
                "Error en los datos de entrada",
                builder.ToString());
        }
    }
}
