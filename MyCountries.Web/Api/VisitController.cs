using Microsoft.AspNet.Mvc;
using MyCountries.Web.Data;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Net;
using System;

namespace MyCountries.Web.Api
{
  [Authorize]
  [Route("api/visits")]
  public class VisitsController : Controller
  {
    private IMyCountriesRepository _repository;
    public VisitsController(IMyCountriesRepository repository)
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

    [HttpPost("")]
    public async Task<ActionResult> Post([FromBody] Visit newVisit)
    {
      var username = User.Identity.GetUserName();

      newVisit.UserName = username;

      if (await _repository.AddVisitAsync(newVisit))
      {
        Response.StatusCode = (int) HttpStatusCode.Created;
        // TODO Fix for full path, Request doesn't include full request URI for some reason
        var location = string.Concat("/api/visits/", newVisit.Id);
        Response.Headers["location"] = location.ToString();
        
        return Json(newVisit);
      }

      return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Visit visit)
    {
      var username = User.Identity.GetUserName();

      // Valid User Updating
      if (visit.UserName == username)
      {

      }

      if (await _repository.UpdateVisitAsync(visit))
      {
        Response.StatusCode = (int)HttpStatusCode.OK;
        return Json(visit);
      }

      return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
    }


    [AllowAnonymous]
    [HttpGet("latest")]
    public async Task<ActionResult> GetLatest()
    {
      return Json(await _repository.GetLatestVisits(5));
    }


  }
}
