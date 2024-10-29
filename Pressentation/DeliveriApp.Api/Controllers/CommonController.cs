using Microsoft.AspNetCore.Mvc;

namespace DeliveriApp.Api.Controllers
{
    [ApiController]
    public abstract class CommonController<T> : ControllerBase
    {
        protected readonly ILogger<T> Logger;

        protected CommonController(ILogger<T> logger)
        {
            Logger = logger;
        }

        protected void LogInformation(string message, params object[] args)
        {
            Logger.LogInformation(message, args);
        }

        protected void LogWarning(string message, params object[] args)
        {
            Logger.LogWarning(message, args);
        }

        protected void LogError(Exception ex, string message, params object[] args)
        {
            Logger.LogError(ex, message, args);
        }
    }
}
