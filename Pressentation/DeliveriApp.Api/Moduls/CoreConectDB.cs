using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveriApp.Api.Moduls
{
    public static class CoreConectDB
    {
        public static IServiceCollection AddConectDb(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddDbContext<DeliveryContext>(options =>
            {
                var conectionString = configuration
                .GetConnectionString("EfCoreShopDataBase");

                options.UseSqlite(conectionString);
            });

            return services;
        }
    }
}
