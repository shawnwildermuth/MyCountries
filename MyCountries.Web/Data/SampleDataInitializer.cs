using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyCountries.Web.Models;

namespace MyCountries.Web.Data
{
  public class SampleDataInitializer
  {
    private MyCountriesContext _ctx;
    private UserManager<ApplicationUser> _userManager;

    public SampleDataInitializer(MyCountriesContext ctx, UserManager<ApplicationUser> userManager)
    {
      _ctx = ctx;
      _userManager = userManager;
    }

    public async Task InitializeDataAsync()
    {
      await CreateUsersAsync();
      CreateVisits();
    }

    private async Task CreateUsersAsync()
    {
      var user = await _userManager.FindByEmailAsync("shawnwildermuth");
      if (user == null)
      {
        user = new ApplicationUser { UserName = "shawnwildermuth", Email = "shawn@wildermuth.com" };
        await _userManager.CreateAsync(user, "P@ssw0rd!");

        await _userManager.AddClaimAsync(user, new Claim("ManageStore", "Allowed"));
      }

    }

    private void CreateVisits()
    {
      if (!_ctx.Visits.Any())
      {
        _ctx.Visits.Add(new Visit()
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

        _ctx.Visits.Add(new Visit()
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

        _ctx.Visits.Add(new Visit()
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

        _ctx.Visits.Add(new Visit()
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

        _ctx.SaveChanges();

      }
    }

  }
}