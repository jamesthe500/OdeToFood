using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using System;

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
            // added this service which came with the NuGet package for MVC. App won't run w/o services
            // not sure what services are...
            services.AddMvc();
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

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Oops!")
                });
            }
           
            app.UseFileServer();

            // Changed from app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);

            // this is added as a catch-all for if the route is not found.
            app.Run(ctx => ctx.Response.WriteAsync("Not found"));
        }

        // auto generated from above 
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // 2nd parameter is importatn
            // it's a template to tell how to handle route requests
            // if given this route /Home/Index
            // it will know to look in the controller "HomeController" ("Controller is automatically appended")
            // for a method, "Index" 
            // these are  controller and action
            // MVC knows to plug in values for that in {}.
            // could have hard coded parts to the route, like admin/{controller}/{action}
            // {id?} is optional. these could be additional parameters.
            // This didn't work
            //routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}");

            // this says, If you don't find a controller in the URL, 
            // use Home as the defualt controller, and ditto use Index as the default action
            // Could set any defualt names we wanted. 
            // can spell it out with localhost:223452/home/index or just /home. All go to same place
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");

            // This is called Convention Based Routing
            // could have any number of other routes for special needs.
        }
    }
}
