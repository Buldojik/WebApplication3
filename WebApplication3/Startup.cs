using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using WebApplication3.Data;
using WebApplication3.DataBase.Connection;
using WebApplication3.Interfaces;
using WebApplication3.Mapping;
using WebApplication3.Repository;

namespace WebApplication3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper(typeof (DivisionMappingProfile),typeof(WorkerMapingProfile), typeof(QuestMappingProfile), typeof(ProjectMappingProfile), typeof(LaborCostsMappingProfile), typeof(DataMapperProfile));
            services.AddScoped<IDivisionHandler, DivisionHandler>();
            services.AddScoped<IWorkerHandler, WorkerHandler>();
            services.AddScoped<IQuestHandler, QuestHandler>();
            services.AddScoped<IProjectHandler, ProjectHandler>();
            services.AddScoped<ILaborCostsHandler, LaborCostsHandler>();
            services.AddScoped<IDataHandler, DataHandler>();
            services.AddDbContext<ConnectionContext>(options => { 
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));});
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication3", Version = "v2" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication3 v1"));
                app.UseSwagger(options =>
                {
                    options.SerializeAsV2 = true;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
