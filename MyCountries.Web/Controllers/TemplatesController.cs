using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MyCountries.Web.Controllers
{
  public class TemplatesController : Controller
  {
    private List<SelectListItem> _selectCountriesList;
    public TemplatesController()
    {
      _selectCountriesList = ISO3166.Country.List.Select(c => new SelectListItem() { Text = c.Name }).ToList();
    }

    public ActionResult NewVisit()
    {
      ViewBag.Countries = _selectCountriesList;
      return View();
    }

    public ActionResult EditVisit()
    {
      ViewBag.Countries = _selectCountriesList;
      return View();
    }

    public ActionResult MyVisits()
    {
      return View();
    }
  }
}