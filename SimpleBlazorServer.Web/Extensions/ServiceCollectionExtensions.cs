using SimpleBlazorServer.Shared.Services;
using SimpleBlazorServer.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleBlazorServer.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingletonServices();
            services.AddScopedServices();
            services.AddTransientServices();

            return services;
        }

        private static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<ISnackbarService, SnackbarService>();
            services.AddSingleton<IUserService, UserService>();

            return services;
        }

        private static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IDocumentService, DocumentService>();

            return services;
        }

        private static IServiceCollection AddTransientServices(this IServiceCollection services)
        {

            return services;
        }
    }
}
