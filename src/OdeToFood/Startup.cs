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

            /*
             * Again, placement is key. This block has to be here because middleware is run from top to bottom,
             * then bottom to top on its way back out
             * |   A
             * |   |
             * V---|
             */

            if (env.IsDevelopment())
            {
                // commenting out for demo
                // with this middleware, unhandled exceptions are given a nice page the user can see.
                // it has a stack trace and shows 
                app.UseDeveloperExceptionPage();
            }

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/welcome"
            });

            app.Run(async (context) =>
            {
                // This is just an unhandled exception to help demonstrate what app.UseDeveloperExceptionPage does
                throw new System.Exception("Something went wronmg");
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
