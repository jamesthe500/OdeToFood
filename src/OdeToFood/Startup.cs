using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace OdeToFood
{
    public class Startup
    {
        //ctor to add a constructor for this class
        // bringing in IHositnEnvironment to help with root path
        public Startup(IHostingEnvironment env)
        {
            // the ConfigurationBuilder allows you to define the configuration sources for the application.
            // we're using AddJsonFile so it can extend its configurations.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath) // inorder to get this needed 2 add a dependency ...FileExtensions
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            // this says "Build up the configuration that we're using"

            Configuration = builder.Build();
        }
        // this will store all the configurations
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var greeting = Configuration["greeting"];
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
