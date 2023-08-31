using System.Net;

namespace praticeAPI.MiddleWares
{
    public class ExpectionHandler
    {
        private readonly ILogger<ExpectionHandler> logger1;
        private readonly RequestDelegate request;

        public ExpectionHandler(ILogger<ExpectionHandler> logger1,RequestDelegate request)
        {
            this.logger1 = logger1;
            this.request = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await request(httpContext);
            }
            catch (Exception ex)
            {
                var errorID = Guid.NewGuid().ToString();
                logger1.LogError(ex, $"{errorID}: {ex.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorID,
                    Message = "SomeThing went wrong",

                };
                await httpContext.Response.WriteAsJsonAsync(error);

            }
        }
    }
}
