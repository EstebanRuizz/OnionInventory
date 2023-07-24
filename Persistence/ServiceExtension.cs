using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataBaseContext;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceExtension
    {
        public static void AddIOCPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductsContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("ProductsDB"), 
                dataBase => dataBase.MigrationsAssembly(typeof(ProductsContext ).Assembly.FullName)));

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(GenericRepository<>));
        }
    }
}
