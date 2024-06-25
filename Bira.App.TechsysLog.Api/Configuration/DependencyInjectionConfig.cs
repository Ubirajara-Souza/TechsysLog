using Bira.App.TechsysLog.Domain.Extensions;
using Bira.App.TechsysLog.Domain.Interfaces.Repositories;
using Bira.App.TechsysLog.Domain.Interfaces;
using Bira.App.TechsysLog.Infra.Repositories.BaseContext;
using Bira.App.TechsysLog.Infra.Repositories;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Bira.App.TechsysLog.Service.Interfaces;
using Bira.App.TechsysLog.Service.Notifications;
using Bira.App.TechsysLog.Service.Services;

namespace Bira.App.TechsysLog.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApiDbContext>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
