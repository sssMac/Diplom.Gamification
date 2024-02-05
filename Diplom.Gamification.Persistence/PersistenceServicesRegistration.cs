using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("ReviewsDbConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<IdentityUser, IdentityRole>(
               options =>
               {
                   options.User.AllowedUserNameCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPASDFGHJKLMNBVCXZйцукенгшщзхъэждлорпавыфячсмитьбюЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮ";
                   options.Password.RequireDigit = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequiredLength = 3;
                   options.User.RequireUniqueEmail = true;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
                   options.SignIn.RequireConfirmedEmail = false;
               })
               .AddEntityFrameworkStores<ApplicationContext>()
               .AddDefaultUI()
               .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "application.Identity";
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Review";
            });

            return services;
        }
    }
}
