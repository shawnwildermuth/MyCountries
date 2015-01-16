using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using MyCountries.Web.Data;
using MyCountries.Web.Models;
using Newtonsoft.Json.Serialization;
using System;

namespace MyCountries.Web
{
  public class Startup
  {
    public IConfiguration Configuration { get; set; }

    public Startup(IHostingEnvironment env)
    {
      // Setup configuration sources.
      Configuration = new Configuration()
          .AddJsonFile("config.json")
          .AddEnvironmentVariables();
    }

    // This method gets called by the runtime.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add EF services to the services container.
      services.AddEntityFramework(Configuration)  
          .AddSqlServer()
          .AddDbContext<MyCountriesContext>(options =>
          {
            options.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString"));
          });
      
      // Add Identity services to the services container.
      services.AddDefaultIdentity<MyCountriesContext, ApplicationUser, IdentityRole>(Configuration);

      // Add MVC services to the services container.
      services.AddMvc()
        .Configure<MvcOptions>(options =>
        {
          // See Strathweb's great discussion of formatters: http://www.strathweb.com/2014/11/formatters-asp-net-mvc-6/
          //options.InputFormatters.Clear();

          var jsonOutputFormatter = new JsonOutputFormatter();
          jsonOutputFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
          jsonOutputFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

          options.OutputFormatters.RemoveAll(formatter => formatter.Instance.GetType() == typeof(JsonOutputFormatter));
          options.OutputFormatters.Insert(0, jsonOutputFormatter);
        }); ;

      // Add other services
      services.AddScoped<IMyCountriesRepository, MyCountriesRepository>();

      // Uncomment the following line to add Web API servcies which makes it easier to port Web API 2 controllers.
      // You need to add Microsoft.AspNet.Mvc.WebApiCompatShim package to project.json
      // services.AddWebApiConventions();

    }

    // Configure is called after ConfigureServices is called.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
    {
      // Configure the HTTP request pipeline.
      // Add the console logger.
      loggerfactory.AddConsole();

      // Add the following to the request pipeline only in development environment.
      if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
      {
        app.UseBrowserLink();
        app.UseErrorPage(ErrorPageOptions.ShowAll);
        app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
      }
      else
      {
        // Add Error handling middleware which catches all application specific errors and
        // send the request to the following path or controller action.
        app.UseErrorHandler("/Home/Error");
      }

      // Add static files to the request pipeline.
      app.UseStaticFiles();

      // Add cookie-based authentication to the request pipeline.
      app.UseIdentity();

      // Add MVC to the request pipeline.
      app.UseMvc(routes =>
      {
        routes.MapRoute(
              name: "default",
              template: "{controller}/{action}/{id?}",
              defaults: new { controller = "Home", action = "Index" });
        });



      // Sample Data
      SampleData.InitializeData(app.ApplicationServices);

    }
  }
}
