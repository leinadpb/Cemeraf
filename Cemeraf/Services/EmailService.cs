using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Data;
using Cemeraf.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Cemeraf.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration Configuration;

        public EmailService(IConfiguration cfg)
        {
            Configuration = cfg;
        }

        public Task<bool> SendEmail(EmailAddress from, EmailAddress to, string header, string body, string bodyHtml)
        {
            return Task.Run(async () => {

                string apiKey = Configuration.GetSection("SendGrid:Key").Value.Trim();
                var client = new SendGridClient(apiKey);

                var msg = MailHelper.CreateSingleEmail(from, to, header, body, bodyHtml);

                try
                {
                    var response = await client.SendEmailAsync(msg);
                    return true;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error: {exp}");
                }

                return false;

            });
        }
    }
}
