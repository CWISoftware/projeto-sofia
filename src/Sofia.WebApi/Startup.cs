using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sofia.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                });

            services.AddCors();

            // Avalicao
            services.AddScoped<Infrastructure.Avaliacoes.AvaliacoesContext, Infrastructure.Avaliacoes.AvaliacoesContext>();
            services.AddTransient<Infrastructure.Avaliacoes.AvaliacoesUnitOfWork, Infrastructure.Avaliacoes.AvaliacoesUnitOfWork>();
            services.AddTransient<Domain.Avaliacoes.Repositories.IAvaliacaoRepository, Infrastructure.Avaliacoes.Repositories.AvaliacaoRepository>();
            services.AddTransient<Domain.Avaliacoes.Commands.AvaliacaoCommandHandler, Domain.Avaliacoes.Commands.AvaliacaoCommandHandler>();

            // Caegorias
            services.AddScoped<Infrastructure.Categorias.CategoriasContext, Infrastructure.Categorias.CategoriasContext>();
            services.AddTransient<Infrastructure.Categorias.CategoriasUnitOfWork, Infrastructure.Categorias.CategoriasUnitOfWork>();
            services.AddTransient<Domain.Categorias.Repositories.ICategoriaRepository, Infrastructure.Categorias.Repositories.CategoriaRepository>();
            services.AddTransient<Domain.Categorias.Commands.CategoriaCommandHandler, Domain.Categorias.Commands.CategoriaCommandHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();
        }
    }
}
