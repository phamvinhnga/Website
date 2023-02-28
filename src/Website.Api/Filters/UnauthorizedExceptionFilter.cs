using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Website.Shared.Exceptions;

namespace Website.Api.Filters
{
    public class UnauthorizedExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is UnauthorizedException)
            {
                var exception = context.Exception as UnauthorizedException;

                if (exception.Code == 0)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                }
                else
                {
                    context.HttpContext.Response.StatusCode = exception.Code;
                }

                context.Result = new JsonResult(new
                {
                    message = context.Exception.GetBaseException().Message
                });

                base.OnException(context);
            }
        }
    }

}
