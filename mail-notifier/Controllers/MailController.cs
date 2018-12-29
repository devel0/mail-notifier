using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace mail_notifier.Controllers
{

    [Route("mail")]
    [ApiController]
    public class MailController : ControllerBase
    {

        Config config { get { return Global.Instance.Config; } }

        // GET mail?from=emailfrom&to=emailto&subj=subject&body=body
        [HttpGet]
        public void Get(string from, string to, string subj, string body)
        {
            if (string.IsNullOrEmpty(from)) from = config.login;
            if (string.IsNullOrEmpty(to)) to = config.login;            
            System.Console.WriteLine($"===> sending email from[{from}] to[{to}] subj[{subj}] body[{body}]");

            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(from));
            msg.To.Add(new MailboxAddress(to));
            if (!string.IsNullOrEmpty(subj)) msg.Subject = subj;
            if (!string.IsNullOrEmpty(body))
            {
                var html = new TextPart(TextFormat.Html);
                html.Text = body;
                msg.Body = html;
            }

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(config.smtpserver, config.smtpport, config.sslmode);
                client.Authenticate(config.login, config.password);
                client.Send(msg);
                client.Disconnect(true);
            }
        }
    }
}
