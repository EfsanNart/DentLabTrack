namespace DentLabTrack.WebApi.Middlewares
{
    public static class MiddlewareExtensions
    {
        // This extension method is used to add the MaintenenceMiddleware to the ASP.NET Core pipeline.
        public static IApplicationBuilder UseMaintenenceMode(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MaintenenceMiddleware>();
        }


    }
}
