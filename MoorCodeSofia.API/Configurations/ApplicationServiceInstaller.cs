using FluentValidation;
using MediatR;
using MoorCodeSofia.Application.Behaviors;
using System.Reflection;

namespace MoorCodeSofia.API.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
           // services.AddMediatR(Application.AssemblyReference.Assembly);
            services.AddMediatR(typeof(Application.AssemblyReference).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPiepelineBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));



            services.AddAutoMapper(Application.AssemblyReference.Assembly);

            services.AddValidatorsFromAssembly(
                Application.AssemblyReference.Assembly,
                includeInternalTypes: true);
        }
    }
}

