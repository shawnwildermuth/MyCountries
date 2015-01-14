using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MyCountries.Web.Data;

namespace MyCountries.Web.Controllers
{
  public class HomeController : Controller
  {
    public HomeController()
    {
    }

    public IActionResult Index()
    {

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