using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MyCountries.Web.Data;
using MyCountries.Web.Models;
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
      ViewBag.Message = "An example of ASP.NET 5";

      return View();
    }

    public IActionResult About()
    {
      ViewBag.Message = "An example of ASP.NET 5";

      return View();
    }

    public IActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    [HttpPost]
    public IActionResult Contact(ContactModel model)
    {
      ViewBag.Message = "Let us know what you think!";

      if (ModelState.IsValid)
      {
        try
        {
          _emailer.SendMail("shawn@wildermuth.com", "shawn@wildermuth.com", "Message From MyCountries.io",
            string.Format(@"From: {1} ({2}){0}Comment: {3}",
              Environment.NewLine,
              model.Name,
              model.Email,
              model.Comments));

          ModelState.Clear();
          ViewBag.Result = "Message Sent";
        }
        catch
        {
          ModelState.AddModelError("", "Failed to send email. Please try again later. The error was logged.");
        }
      }

      return View();
    }


    public IActionResult Error()
    {
      return View("~/Views/Shared/Error.cshtml");
    }
  }
}