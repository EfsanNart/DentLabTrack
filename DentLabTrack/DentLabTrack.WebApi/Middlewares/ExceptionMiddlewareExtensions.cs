namespace DentLabTrack.WebApi.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        
        // Extension method to add the exception handling middleware to the application pipeline
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
