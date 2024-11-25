using DeliveriApp.Application.Services;
using DeliveriApp.Domein.Interfaces.Repository;

namespace DeliveriApp.Api.Moduls
{
    public static class CoreScrutor
    {
        public static IServiceCollection AddScrutor(this IServiceCollection services)
        {
            services.Scan(scan => scan
            /*.FromAssembliesOf(typeof(IRequestHendler<>))*/
            .FromApplicationDependencies()
            .AddClasses(classes => classes.AssignableTo(typeof(IResponsHendler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHendler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHendler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHendler<,,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(ISetRepository)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IGetRepository)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}
