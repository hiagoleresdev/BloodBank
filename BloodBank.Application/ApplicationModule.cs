using BloodBank.Application.Commands.InserirDoador;
using BloodBank.Application.Commands.RealizarDoacao;
using BloodBank.Application.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();

            services.AddHttpClient<InserirDoadorHandler>();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ApplicationModule).Assembly));

            services.AddTransient<IPipelineBehavior<InsertDoadorCommand, ResultViewModel>, ValidateInserirDoadorBehavior>();
            services.AddTransient<IPipelineBehavior<RealizarDoacaoCommand, ResultViewModel>, ValidateRealizarDoacaoBehavior>();
            return services;
        }

    }
}
