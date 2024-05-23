using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Diplom.Gamification.Infrastructure
{
    public static class InfrastructureServiceRegister
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, IdentityService>();
            services.AddScoped<IYandexService, YandexService>();

            return services;
        }
    }
}
