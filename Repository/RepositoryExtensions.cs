using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            return services
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IPublisherRepository, PublisherRepository>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>));


        }
    }
}
