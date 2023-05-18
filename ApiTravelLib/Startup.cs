using Core.Interfaces;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ApiTravelLib.Extensions;
using ApiTravelLib.Services;
using ApiTravelLib.GraphQL.SchemaGraph;
using System.Reflection;

namespace ApiTravelLib
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
            services.ConfigureCors();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QvisionLibrary", Version = "v1" });
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddDbContext<QVisionLibraryContext>(
            options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TravelLibrary;Connection timeout=30;Integrated Security=SSPI;"));

            services.AddScoped<ILibroService, LibroService>();

            services.AddScoped<ILibroRepository, LibroRepository>();

            services.AddAutoMapper(Assembly.GetEntryAssembly());

            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                    opt.JsonSerializerOptions.DictionaryKeyPolicy = null;
                });

            services.AddScoped<TravelLibSchema>();
            services.AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(TravelLibSchema), ServiceLifetime.Scoped);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QvisionLibrary v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphQL<TravelLibSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
