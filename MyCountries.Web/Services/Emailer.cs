using System;
#if ASPNET50
using System.Net.Mail;
#endif

namespace MyCountries.Web.Services
{
  public class Emailer : IEmailer
  {
    public Emailer()
    {

    }

    public void SendMail(string from, string to, string subject, string body)
    {
#if ASPNET50
      var client = new SmtpClient();
      client.EnableSsl = true;
      client.SendAsync(from, to, subject, body, null);
#endif
    }

  }
}