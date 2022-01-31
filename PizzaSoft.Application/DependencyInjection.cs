using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PizzaSoft.Application.Common.Behaviors;
using Serilog;
using System.Globalization;
using System.Reflection;

namespace PizzaSoft.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es");
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddSingleton(Log.Logger);
            return services;
        }
    }
}
