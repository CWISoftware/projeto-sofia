﻿using Sofia.SharedKernel.Runtime;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sofia.WebApi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

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

            // Runtime
            Runtime.ConnectionString = Configuration.GetConnectionString("SofiaConnectionString");

            // Avalicao
            services.AddScoped<Infrastructure.Avaliacoes.AvaliacoesContext, Infrastructure.Avaliacoes.AvaliacoesContext>();
            services.AddTransient<Infrastructure.Avaliacoes.AvaliacoesUnitOfWork, Infrastructure.Avaliacoes.AvaliacoesUnitOfWork>();
            services.AddTransient<Domain.Avaliacoes.Repositories.IAvaliacaoRepository, Infrastructure.Avaliacoes.Repositories.AvaliacaoRepository>();
            services.AddTransient<Domain.Avaliacoes.Commands.Handlers.AvaliacaoCommandHandler, Domain.Avaliacoes.Commands.Handlers.AvaliacaoCommandHandler>();

            // Caegorias
            services.AddScoped<Infrastructure.Categorias.CategoriasContext, Infrastructure.Categorias.CategoriasContext>();
            services.AddTransient<Infrastructure.Categorias.CategoriasUnitOfWork, Infrastructure.Categorias.CategoriasUnitOfWork>();
            services.AddTransient<Domain.Categorias.Repositories.ICategoriaRepository, Infrastructure.Categorias.Repositories.CategoriaRepository>();
            services.AddTransient<Domain.Categorias.Commands.Handlers.CategoriaCommandHandler, Domain.Categorias.Commands.Handlers.CategoriaCommandHandler>();
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
