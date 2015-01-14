using Microsoft.AspNet.Mvc;
using MyCountries.Web.Data;
using System.Threading.Tasks;
using System.Security.Principal;

namespace MyCountries.Web.Api
{
  [Authorize]
  [Route("api/visits")]
  public class VisistController : Controller
  {
    private IMyCountriesRepository _repository;
    public VisistController(IMyCountriesRepository repository)
    {
      _repository = repository;
    }

    [HttpGet("")]
    public async Task<ActionResult> Get()
    {
      var username = User.Identity.GetUserName();
      var results = await _repository.GetVisitsByUserNameAsync(username);

      return Json(results);
    }

    [AllowAnonymous]
    [HttpGet("latest")]
    public async Task<ActionResult> GetLatest()
    {
      return Json(await _repository.GetLatestVisits(5));
    }


  }
}
