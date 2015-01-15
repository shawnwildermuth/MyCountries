using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCountries.Web.Data
{
  public class MyCountriesRepository : IMyCountriesRepository
  {
    private MyCountriesContext _context;
    public MyCountriesRepository(MyCountriesContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Visit>> GetVisitsByUserNameAsync(string username)
    {
      var lowerUserName = username.ToLowerInvariant();

      return await _context.Visits
        .Where(v => v.UserName.ToLowerInvariant() == lowerUserName)
        .OrderBy(v => v.VisitDate)
        .ToListAsync();
    }

    public async Task<IEnumerable<Visit>> GetLatestVisits(int number)
    {
      return await _context.Visits
        .OrderByDescending(v => v.VisitDate)
        .Take(number)
        .ToListAsync();
    }
  }
}