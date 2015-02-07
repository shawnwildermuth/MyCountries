using System;
using System.Diagnostics;
using Microsoft.Framework.Logging;

namespace MyCountries.Web.Services
{
  public class ConsoleEmailer : IEmailer
  {
    public ConsoleEmailer()
    {
    }

    public void SendMail(string from, string to, string subject, string body)
    {
      Debug.Write(string.Format("Sending Email:{0}From:{1}{0}To:{2}{0}Subject:{3}{0}Body: {4}", Environment.NewLine, from, to, subject, body));      
    }
  }
}