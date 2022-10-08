using Clean.Architecture.Entities.Interfaces;
using Clean.Architecture.Repositories.DataContext;
using Clean.Architecture.Repositories.Repositories;
using Clean.Architecture.UseCases.Common.Behavior;
using Clean.Architecture.UseCases.CreateOrder;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddCleanArchitectureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArchitectureContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CleanArchitecture"))
            );
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(typeof(CreateOrderInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
