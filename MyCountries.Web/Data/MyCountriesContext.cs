using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using MyCountries.Web.Models;

namespace MyCountries.Web.Data
{
  public class MyCountriesContext : IdentityDbContext<ApplicationUser>
  {
    public MyCountriesContext()
    {
      Database.EnsureCreated();
    }

    public DbSet<Visit> Visits { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Visit>().HasKey(v => v.Id);

      base.OnModelCreating(builder);
    }
  }
}