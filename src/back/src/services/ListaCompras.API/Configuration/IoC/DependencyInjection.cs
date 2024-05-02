using ListaCompras.API.Data.Repositories;
using ListaCompras.API.Domain.Interfaces.Repositories;
using ListaCompras.API.Domain.Interfaces.Services;
using ListaCompras.API.Domain.Services;

namespace ListaCompras.API.Configuration.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddScoped<IItensComprasService,ItensComprasService>();

            services.AddScoped<IITensComprasRepository, ItensComprasRepository>();
            
            return services;
        }
    }
}