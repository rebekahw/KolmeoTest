using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Interfaces;
using Product.Infrastructure.Data;

namespace Product.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ProductContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConStr"),
                b => b.MigrationsAssembly(typeof(ProductContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IProductContext>(provider => provider.GetService<ProductContext>());
            return services;
        }
    }
}
