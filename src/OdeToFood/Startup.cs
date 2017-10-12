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
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            // ASP.NET looks to the properties of the project to see what environment you are in.
            // open teh properties form src/OdeToFood.xproj 
            // There you can set the Environment variables to whatever.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // this will be hit if the env is not Development, obviously.
                // this is an option. Set up a page to show the user a beautiful excpetion
                // while loggin what the exceptions were on the backend
                //app.UseExceptionHandler("/error");

                // another option is to use these options
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                     // this prints out "Oops!" when there is an unhandled exception
                    ExceptionHandler = context => context.Response.WriteAsync("Oops!")
                });
            }


            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/welcome"
            });

            app.Run(async (context) =>
            {
                // still this unhandled exception for demo
                throw new System.Exception("Something went wronmg");
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
