using Microsoft.AspNet.Mvc;
using MyCountries.Web.Data;
using System;
using System.Threading.Tasks;

namespace MyCountries.Web.Controllers
{
  [Authorize]
  public class MyController : Controller
  {
    private IMyCountriesRepository _repository;
    public MyController(IMyCountriesRepository repository)
    {
      _repository = repository;
    }

    public ActionResult Index()
    {
      return View();
    }

  }
}