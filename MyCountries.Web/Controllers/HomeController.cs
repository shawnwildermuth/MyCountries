using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MyCountries.Web.Data;
using MyCountries.Web.Services;

namespace MyCountries.Web.Controllers
{
  public class HomeController : Controller
  {
    private IEmailer _emailer;
    public HomeController(IEmailer emailer)
    {
      _emailer = emailer;
    }

    public IActionResult Index()
    {

      _emailer.SendMail("shawn@wildermuth.com", "shawn@wilderminds.com", "Testing", "Foo bar");

      return View();
    }

    public IActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public IActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }



    public IActionResult Error()
    {
      return View("~/Views/Shared/Error.cshtml");
    }
  }
}