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
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        // all HTtP requests go through this middleware
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            // this middleware displays an error pages that is more useful for developers.
            // it only activates when you're in developer mode.
            if (env.IsDevelopment())
            {
                // for demo, commented out ASP.NET core diagnostics dependency
                // w/o it, the next line errored, not many pieces of middleware available
                app.UseDeveloperExceptionPage();
            }

            // added this middleware from Diagnostics 
            // note: before app.Run
            // serves a basic welcome page, useful for debugging, does this app serve anything?
            // Terminal piece of middleware when invoked without parameters. No other middleware can be reached
            //app.UseWelcomePage();

            // This overload says, "handle all requests to the root url/welcome
            //app.UseWelcomePage("/welcome");

            // there is this property that you can run on a WelcomePage that allows one to add options.
            // most middleware will have an object like this. It will usually follow the convetion of 
            // MiddlwareNameOptions
            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/welcomer"
            });

            // dont' normally do much with .Run. More for demo purposes, it's low-level.
            app.Run(async (context) =>
            {
               // All HTTP req go through this w/ current setup.
               // .NET gives the context object, which has all kinds of information about the req
               // e.g. context.Request.body
               
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
