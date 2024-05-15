using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SELP.Core.Behaviors;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using SELP.Core.Features.AuthenticationUser.Commands.Validators;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System.Reflection;

namespace SELP.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //configuration mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

           // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            // 

            //config of automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}