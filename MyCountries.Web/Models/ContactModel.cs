using System.ComponentModel.DataAnnotations;

namespace MyCountries.Web.Models
{
  public class ContactModel
  {
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Comments { get; set; }

  }
}