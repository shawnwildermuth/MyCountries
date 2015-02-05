using Microsoft.Data.Entity.SqlServer;
using MyCountries.Web.Data;
using System;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Identity;
using MyCountries.Web.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;

namespace MyCountries.Web
{
  public class SampleData
  {
    public static void InitializeData(IServiceProvider serviceProvider)
    {
      using (var ctx = serviceProvider.GetService<MyCountriesContext>())
      {
        //var sqlServerDataStore = ctx.Database.Configuration.DataStore as SqlServerDataStore;
        //if (sqlServerDataStore != null)
        //{
          if (ctx.Database.EnsureCreated())
          {
            CreateUsers(serviceProvider).Wait();
            CreateVisits(serviceProvider);
          }
        //}
        //else
        //{
        //  CreateUsers(serviceProvider).Wait();
        //  CreateVisits(serviceProvider);
        //}

      }
    }

    private static async Task CreateUsers(IServiceProvider serviceProvider)
    {
      var configuration = new Configuration()
                  .AddJsonFile("config.json")
                  .AddEnvironmentVariables();

      var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

      var user = await userManager.FindByEmailAsync("shawnwildermuth");
      if (user == null)
      {
        user = new ApplicationUser { UserName = "shawnwildermuth", Email = "shawn@wildermuth.com" };
        await userManager.CreateAsync(user, "P@ssw0rd!");

        await userManager.AddClaimAsync(user, new Claim("ManageStore", "Allowed"));
      }

    }

    private static void CreateVisits(IServiceProvider serviceProvider)
    {
      var configuration = new Configuration()
                  .AddJsonFile("config.json")
                  .AddEnvironmentVariables();

      using (var ctx = serviceProvider.GetService<MyCountriesContext>())
      {

        if (ctx.Visits.Count() == 0)
        {
          ctx.Visits.Add(new Visit()
          {
            Id = 0,
            UserName = "shawnwildermuth",
            Country = "France",
            City = "Paris",
            VisitDate = new DateTime(2014, 6, 4),
            Duration = 31,
            Notes = "Start of our round-the-world trip",
            ForWork = false,
            ForFun = true
          });

          ctx.Visits.Add(new Visit()
          {
            Id = 0,
            UserName = "shawnwildermuth",
            Country = "United Kingdom",
            City = "London",
            VisitDate = new DateTime(2014, 7, 2),
            Duration = 28,
            Notes = "Our visit to the UK",
            ForWork = true,
            ForFun = true
          });

          ctx.Visits.Add(new Visit()
          {
            Id = 0,
            UserName = "shawnwildermuth",
            Country = "France",
            City = "Paris",
            VisitDate = new DateTime(2014, 6, 4),
            Duration = 31,
            Notes = "Start of our round-the-world trip",
            ForWork = false,
            ForFun = true
          });

          ctx.Visits.Add(new Visit()
          {
            Id = 0,
            UserName = "shawnwildermuth",
            Country = "France",
            City = "Paris",
            VisitDate = new DateTime(2014, 6, 4),
            Duration = 31,
            Notes = "Start of our round-the-world trip",
            ForWork = false,
            ForFun = true
          });

          ctx.SaveChanges();

          Console.WriteLine("Wrote Sample Data to DB");

        }
      }
    }

  }
}