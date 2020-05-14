using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Lemontech.DataLayer.Entities;

namespace LemonTech.Configs
{
    public static class DbConfigService
    {
        public static IServiceCollection RegisterDatabaseContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DBContext>(options =>
            options.UseSqlServer(config.GetConnectionString("ConnString")));

            services.AddDbContext<IdentityDBContext>(options =>
            options.UseSqlServer(config.GetConnectionString("ConnString")));

            services.AddIdentity<IdentityUser, IdentityRole>(SetupAction())
                .AddEntityFrameworkStores<IdentityDBContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        private static Action<IdentityOptions> SetupAction()
        {

            return option => {

                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 6;

                option.User.RequireUniqueEmail = true;
            };
        }
    }
}
