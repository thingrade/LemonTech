using LemonTech.Repository.Category;
using LemonTech.Repository.Category.Interface;
using LemonTech.Repository.Identity;
using LemonTech.Repository.Identity.Interface;
using LemonTech.Repository.Product;
using LemonTech.Repository.Product.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace LemonTech.IOC
{
    public static class CommonServices
    {
        public static IServiceCollection RegisterDInjection(this IServiceCollection services)
        {

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
