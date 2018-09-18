using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Cemeraf.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailAddress from, EmailAddress to, string header, string body, string bodyHtml);
    }
}
