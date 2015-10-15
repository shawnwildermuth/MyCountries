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

    public SampleDataInitializer(MyCountriesContext ctx)
    {
      _ctx = ctx;
    }

    public void InitializeData()
    {
      CreateVisits();
    }

    private void CreateVisits()
    {
      if (!_ctx.Visits.Any())
      {
        _ctx.Visits.Add(new Visit()
        {
          Id = 0,
          UserName = "shawn@wildermuth.com",
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
          UserName = "shawn@wildermuth.com",
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
          UserName = "shawn@wildermuth.com",
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
          UserName = "shawn@wildermuth.com",
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