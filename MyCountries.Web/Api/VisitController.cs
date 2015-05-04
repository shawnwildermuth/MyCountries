using Microsoft.AspNet.Mvc;
using MyCountries.Web.Data;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Net;
using System;
using Microsoft.AspNet.Authorization;

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
      var username = User.Identity.Name;
      var results = await _repository.GetVisitsByUserNameAsync(username);

      return Json(results);
    }

    [HttpPost("")]
    public async Task<ActionResult> Post([FromBody] Visit newVisit)
    {
      var username = User.Identity.Name;

      newVisit.UserName = username;

      if (await _repository.AddVisitAsync(newVisit))
      {
        Response.StatusCode = (int)HttpStatusCode.Created;
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
      var currentUserName = User.Identity.Name;

      // Valid User Updating
      if (visit.UserName != currentUserName)
      {
        return new HttpStatusCodeResult((int)HttpStatusCode.Unauthorized);
      }

      if (await _repository.UpdateVisitAsync(visit))
      {
        Response.StatusCode = (int)HttpStatusCode.OK;
        return Json(visit);
      }

      return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var currentUserName = User.Identity.Name;

      var visit = await _repository.GetVisitByIdAsync(id);

      // Valid User Updating
      if (visit.UserName != currentUserName)
      {
        return new HttpStatusCodeResult((int)HttpStatusCode.Unauthorized);
      }

      if (await _repository.DeleteVisitAsync(id))
      {
        Response.StatusCode = (int)HttpStatusCode.OK;
        return Json(new { success = true });
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
