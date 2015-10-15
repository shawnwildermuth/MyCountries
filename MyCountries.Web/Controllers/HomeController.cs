using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyCountries.Web.Data;
using MyCountries.Web.Models;
using MyCountries.Web.Services;

namespace MyCountries.Web.Controllers
{
  public class HomeController : Controller
  {
    private IEmailSender _emailer;
    public HomeController(IEmailSender emailer)
    {
      _emailer = emailer;
    }

    public ActionResult Index()
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
    public async Task<IActionResult> Contact(ContactModel model)
    {
      ViewBag.Message = "Let us know what you think!";

      if (ModelState.IsValid)
      {
        try
        {
          await _emailer.SendEmailAsync("shawn@wildermuth.com", "Message From MyCountries.io",
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


    public IActionResult Error(int id)
    {
      ViewBag.ErrorCode = id;

      return View("~/Views/Shared/Error.cshtml");
    }
  }
}