using System;
//using System.Net.Mail;
using System.Threading.Tasks;

namespace MyCountries.Web.Services
{
  public class Emailer : IEmailer
  {
    public Emailer()
    {

    }

    public void SendMail(string from, string to, string subject, string body)
    {
      //var client = new SmtpClient();
      //client.EnableSsl = true;
      //client.SendAsync(from, to, subject, body, null);
    }

  }
}