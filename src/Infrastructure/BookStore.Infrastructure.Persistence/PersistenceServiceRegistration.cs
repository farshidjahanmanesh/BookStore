using BookStore.Core.Application.Contracts.Persistence.Read;
using BookStore.Core.Application.Contracts.Persistence.Write;
using BookStore.Infrastructure.Persistence.Contexts;
using BookStore.Infrastructure.Persistence.Repositories.Read;
using BookStore.Infrastructure.Persistence.Repositories.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configration)
        {
            services.AddDbContext<BookStoreContext>(config =>
            {
                config.UseSqlServer(configration.GetConnectionString("default"));
            });
            services.AddScoped(typeof(IAsyncReadRepository<>), typeof(AsyncReadRepository<>));
            services.AddScoped(typeof(IAsyncWriteRepository<>), typeof(AsyncWriteRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IAsyncAuthorReadRepository, AsyncAuthorReadRepository>();
            return services;
        }
    }
}
