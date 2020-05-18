using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Esgcore.Logic.Configuration
{
    public static class LogicServiceCollectionExtensions
    {
        public static IServiceCollection AddLogic(this IServiceCollection container, IConfiguration config)
        {
            var settings = new EsgcoreSettings();
            config.Bind(settings);

            container
                //Domain Level Validation
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

            return container;
        }
    }
}
