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
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // in order to get the iGreter working, it needs to be registered here.
            // by defualt there are already 16 services running before we get to this point
            // .AddSingleton() adds the service once to be used throughout.
            // there are other adds, .AddTransient() adds a service that only lasts a little while

            // this says:
            // "whenever you see something that needs an IGreeter, 
            // this is the concrete class that you need to instatiate and pass in as the IGreeter.
            // this is the only part of the app that knows what kind of IGreeter we're using. 
            services.AddSingleton<IGreeter, Greeter>();

            // with this services, ,NET knows that when an IConfiguration is needed, it will pass in "Configuration"
            // since Configuration is an Iconfiguration.
            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IGreeter greeter) // the configure method now also takes an IGreeter
            // in order for it to work, it needs to be registered
            // where are the other parameters coming from?
            // ASP.NET knows about these services by default
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                // changing it so the greeting is coming from the IGreeter instead of hard-code.
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
