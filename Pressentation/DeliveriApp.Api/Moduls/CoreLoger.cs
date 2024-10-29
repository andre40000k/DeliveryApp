using Serilog;

namespace DeliveriApp.Api.Moduls
{
    public static class CoreLoger
    {
        public static IHostBuilder AddLog(this IHostBuilder host)
        {
            host.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration));

            return host;
        }
    }
}
