// using System.Net;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;
//
// namespace Pschool.API.Filter;
//
// //TODO validate and refactor. add new excepting handling for not found 
//
//  public abstract class ErrorHandlingFilter(ILogger logger) : IExceptionFilter
//     {
//         public  void OnException(ExceptionContext context)
//         {
//             IActionResult result;
//             ProblemDetails problemDetails = new ProblemDetails
//             {
//                 Instance = context.HttpContext.Request.Path
//             };
//
//             switch (context.Exception)
//             {
//                 case ArgumentNullException:
//                     problemDetails.Type = "https://httpstatuses.com/400";
//                     problemDetails.Title = "Bad Request";
//                     problemDetails.Status = (int)HttpStatusCode.BadRequest;
//                     problemDetails.Detail = "A required argument was null.";
//                     result = new BadRequestObjectResult(problemDetails);
//                     break;
//                 case InvalidOperationException:
//                     problemDetails.Type = "https://httpstatuses.com/400";
//                     problemDetails.Title = "Bad Request";
//                     problemDetails.Status = (int)HttpStatusCode.BadRequest;
//                     problemDetails.Detail = "Invalid operation.";
//                     result = new BadRequestObjectResult(problemDetails);
//                     break;
//                 default:
//                     problemDetails.Type = "https://httpstatuses.com/500";
//                     problemDetails.Title = "Internal Server Error";
//                     problemDetails.Status = (int)HttpStatusCode.InternalServerError;
//                     problemDetails.Detail = "An unexpected error occurred.";
//                     result = new ObjectResult(problemDetails);
//                     break;
//             }
//
//             logger.LogError(context.Exception, "An unhandled exception occurred: {ErrorMessage}",
//                 context.Exception.Message);
//             context.Result = result;
//             context.ExceptionHandled = true;
//         }
//     }