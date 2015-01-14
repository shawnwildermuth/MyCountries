using System;

namespace MyCountries.Web.Data
{
  public class Visit
  {
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public DateTime VisitDate { get; set; }
    public bool ForWork { get; set; }
    public bool ForFun { get; set; }
    public string Notes { get; set; }
    public int Duration { get; set; }
    public bool FirstVisit { get; set; }

    public virtual string UserName { get; set; }
  }
}