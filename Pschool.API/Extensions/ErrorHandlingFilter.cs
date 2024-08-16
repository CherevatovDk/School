using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pschool.API.Extensions
{
    public class ErrorHandlingFilter : IExceptionFilter
    {
        private readonly ILogger<ErrorHandlingFilter> _logger;

        public ErrorHandlingFilter(ILogger<ErrorHandlingFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            IActionResult result;
            ProblemDetails problemDetails = new ProblemDetails
            {
                Instance = context.HttpContext.Request.Path
            };

            switch (context.Exception)
            {
                case NotFoundException ex:
                    problemDetails.Type = "https://httpstatuses.com/404";
                    problemDetails.Title = "Not Found";
                    problemDetails.Status = (int)HttpStatusCode.NotFound;
                    problemDetails.Detail = ex.Message;
                    result = new NotFoundObjectResult(problemDetails);
                    break;
                case ValidationException ex:
                    problemDetails.Type = "https://httpstatuses.com/400";
                    problemDetails.Title = "Bad Request";
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Detail = ex.Message;
                    result = new BadRequestObjectResult(problemDetails);
                    break;
                default:
                    problemDetails.Type = "https://httpstatuses.com/500";
                    problemDetails.Title = "Internal Server Error";
                    problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                    problemDetails.Detail = "An unexpected error occurred.";
                    result = new ObjectResult(problemDetails);
                    break;
            }

            _logger.LogError(context.Exception, "An unhandled exception occurred: {ErrorMessage}", context.Exception.Message);
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
