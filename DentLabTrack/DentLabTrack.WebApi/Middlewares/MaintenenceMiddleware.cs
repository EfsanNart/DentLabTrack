using DentLabTrack.Business.Operations.Setting;

namespace DentLabTrack.WebApi.Middlewares
{
    public class MaintenenceMiddleware
    {
        
        // This middleware checks if the application is in maintenance mode.

        private readonly RequestDelegate _next;
        private readonly ISettingService _settingService;

        public MaintenenceMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext context)
        {
            var settingService = context.RequestServices.GetRequiredService<ISettingService>();
            bool maintenenceMode = settingService.GetMaintenenceState();

            if (context.Request.Path.StartsWithSegments("/api/auth/login") ||
                context.Request.Path.StartsWithSegments("/api/settings"))
            {
                await _next(context);
                return;
            }
            if (maintenenceMode)
            {
                await context.Response.WriteAsync("Şu anda hizmet verememekteyiz");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
