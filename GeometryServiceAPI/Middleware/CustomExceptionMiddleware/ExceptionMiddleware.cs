using GeometryServiceAPI.Models.Error;
using LoggerService;
using System.Net;

namespace GeometryServiceAPI.Middleware.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        
        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

		//Handle multiple exception types and log appropriate messages based on the caught exception
		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (ArgumentException argEx)
			{
				_logger.LogError($"An ArgumentException has been thrown: {argEx}");
				await HandleExceptionAsync(httpContext, argEx);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var message = exception switch
			{
				ArgumentException => "Argument exception error from the custom middleware",
				ArithmeticException => "Arithmetic exception error from the custom middleware",
				_ => "Internal Server Error from the custom middleware."
			};

			await context.Response.WriteAsync(new ErrorDetails()
			{
				StatusCode = context.Response.StatusCode,
				Message = message
			}.ToString());
		}
	}
}
