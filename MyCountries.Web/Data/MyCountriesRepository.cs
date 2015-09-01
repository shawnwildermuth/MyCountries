using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

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

    public async Task<bool> AddVisitAsync(Visit newVisit)
    {
      _context.Visits.Add(newVisit);

      return (await _context.SaveChangesAsync() > 0);
    }

    public async Task<bool> UpdateVisitAsync(Visit visit)
    {
      _context.Visits.Update(visit);

      return (await _context.SaveChangesAsync() > 0);
    }

    public async Task<Visit> GetVisitByIdAsync(int id)
    {
      return await _context.Visits
        .Where(v => v.Id == id)
        .FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteVisitAsync(int id)
    {
      var visit = await GetVisitByIdAsync(id);

      if (visit == null) return false;

      _context.Visits.Remove(visit);

      return (await _context.SaveChangesAsync() > 0);
    }
  }
}