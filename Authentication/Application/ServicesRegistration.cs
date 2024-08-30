using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Authentication.Application.Interfaces.Services;
using MediatR.Extensions.FluentValidation.AspNetCore;
using MediatR;
using FluentValidation;


namespace Authentication.Application.Helpers
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            //services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(ServicesRegistration)));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
