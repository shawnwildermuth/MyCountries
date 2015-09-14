using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using MyCountries.Web.Data;
using MyCountries.Web.Models;
using MyCountries.Web.Services;
using Newtonsoft.Json.Serialization;

namespace MyCountries.Web
{
  public class Startup
  {
    public IConfigurationRoot Configuration { get; set; }

    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
      var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
              .AddJsonFile("config.json")
              .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();

    }

    // This method gets called by the runtime.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add EF services to the services container.
      services.AddEntityFramework()
          .AddSqlServer()
          .AddDbContext<MyCountriesContext>(options =>
              options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

      // Add Identity services to the services container.
      services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<MyCountriesContext>()
          .AddDefaultTokenProviders();

      // Add MVC services to the services container.
      services.AddMvc()
        .AddJsonOptions(opts =>
        {
          opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });

      // Add other services
      services.AddTransient<SampleDataInitializer>();
      services.AddScoped<IMyCountriesRepository, MyCountriesRepository>();
#if DEBUG
      services.AddScoped<IEmailer, ConsoleEmailer>();
#else
  services.AddScoped<IEmailer, Emailer>();
#endif
    }

    // Configure is called after ConfigureServices is called.
    public async void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env, 
                                ILoggerFactory loggerfactory, 
                                SampleDataInitializer sampleData)
    {
      // Configure the HTTP request pipeline.
      // Add the console logger.
      loggerfactory.AddConsole(minLevel: LogLevel.Warning);

      app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");

      // Add the following to the request pipeline only in development environment.
      if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
      {
        //app.UseBrowserLink();
        app.UseErrorPage();
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

      // Add Sample Data
      await sampleData.InitializeDataAsync();

    }
  }
}
