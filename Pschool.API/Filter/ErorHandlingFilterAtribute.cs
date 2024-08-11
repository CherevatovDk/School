using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pschool.API.Filter;

 public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ErrorHandlingFilterAttribute> _logger;

        public ErrorHandlingFilterAttribute(ILogger<ErrorHandlingFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            IActionResult result;
            ProblemDetails problemDetails = new ProblemDetails
            {
                Instance = context.HttpContext.Request.Path
            };

            switch (context.Exception)
            {
                case ArgumentNullException:
                    problemDetails.Type = "https://httpstatuses.com/400";
                    problemDetails.Title = "Bad Request";
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Detail = "A required argument was null.";
                    result = new BadRequestObjectResult(problemDetails);
                    break;

                case InvalidOperationException:
                    problemDetails.Type = "https://httpstatuses.com/400";
                    problemDetails.Title = "Bad Request";
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Detail = "Invalid operation.";
                    result = new BadRequestObjectResult(problemDetails);
                    break;

                case HttpRequestException:
                    problemDetails.Type = "https://httpstatuses.com/503";
                    problemDetails.Title = "Service Unavailable";
                    problemDetails.Status = StatusCodes.Status503ServiceUnavailable;
                    problemDetails.Detail = "A network error occurred.";
                    result = new ObjectResult(problemDetails);
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