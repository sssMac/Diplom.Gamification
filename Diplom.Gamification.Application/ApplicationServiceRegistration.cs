using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Diplom.Gamification.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddScoped<IEducationService, EducationService>();
			services.AddScoped<IAssignmentResultService, AssignmentResultService>();

			return services;
        }
    }
}
