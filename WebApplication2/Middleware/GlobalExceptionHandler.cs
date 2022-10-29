namespace WebApplication2.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            
            try
            {
                await _next(context);
            }
            catch (FileLoadException ex)
            {
                context.Response.Redirect("http://localhost:5110/Home/Error");
                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
