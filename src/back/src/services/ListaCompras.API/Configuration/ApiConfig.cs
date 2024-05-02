using ListaCompras.API.Configuration.IoC;
using ListaCompras.API.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ListaCompras.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("Mysql");
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySql(connection, ServerVersion.AutoDetect(connection),
                    m => m.MigrationsAssembly("TechnoEstetica.Identidade.Api")                    
                )
            );
            services.Register();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors( p => {
                p.AddPolicy("corsapp", op =>{
                    op.AllowAnyOrigin();
                    op.AllowAnyHeader();
                    op.AllowAnyMethod();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // No ambiente de produção é uma boa prática mantê-lo true
            if (app.Configuration["USE_HTTPS_REDIRECTION"] == "true")
                app.UseHttpsRedirection();

            app.UseCors("corsapp");

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}