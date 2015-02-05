using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using MyCountries.Web.Data;
using System.Threading.Tasks;
using MyCountries.Web.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCountries.Web.Controllers
{
  [Route("user")]
  public class UserController : Controller
  {
    private IMyCountriesRepository _repository;
    private UserManager<ApplicationUser> _userManager;

    public UserController(IMyCountriesRepository repository, UserManager<ApplicationUser> userManager)
    {
      _repository = repository;
      _userManager = userManager;
    }

    [HttpGet("{username}", Name = "UserVisits")]
    public async Task<ActionResult> Visits(string username)
    {
      var user = await _userManager.FindByNameAsync(username);
      if (user == null)
      {
        return RedirectToAction("Index", "Home");
      }

      var visits = await _repository.GetVisitsByUserNameAsync(username);

      return View(visits);
    }

  }
}
