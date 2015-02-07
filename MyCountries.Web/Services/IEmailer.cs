namespace MyCountries.Web.Services
{
  public interface IEmailer
  {
    void SendMail(string from, string to, string subject, string body);
  }
}