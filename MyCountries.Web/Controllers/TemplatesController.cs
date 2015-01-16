using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Linq;

namespace MyCountries.Web.Controllers
{
  public class TemplatesController : Controller
  {
    public ActionResult NewVisit()
    {
      ViewBag.Countries = ISO3166.Country.List.Select(c => new SelectListItem() { Text = c.Name }).ToList();
      return View();
    }

    public ActionResult MyVisits()
    {
      return View();
    }
  }
}