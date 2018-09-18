using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cemeraf.Models;
using Cemeraf.Services;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;

namespace Cemeraf.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailService EmailsService;
        private readonly IConfiguration Configuration;

        public HomeController(EmailService emailsService, IConfiguration cfg)
        {
            EmailsService = emailsService;
            Configuration = cfg;
        }

        public IActionResult Index()
        {
            if(TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(string From, string Firstname,
            string Lastname, string Message)
        {
            if(!String.IsNullOrEmpty(From) && !String.IsNullOrEmpty(Message) && !String.IsNullOrEmpty(Firstname) && !String.IsNullOrEmpty(Lastname))
            {
                // Try to send mail
                var fromAddr = new EmailAddress(From, String.Concat(Firstname," ", Lastname));
                var toAddr = new EmailAddress(Configuration.GetSection("Cemeraf:Email").Value, "CEMERAF");
                string subject = $"Mensaje de contacto en la página principal | {Firstname} {Lastname}";
                string body = Message;
                string HtmlBody = @"<div>
                                        <strong> MENSAJE DE CONTACTO </strong> <br>
                                        <div>
                                            "+ Message + @"
                                        </div>
                                   </div>";
                bool result = await EmailsService.SendEmail(fromAddr, toAddr, subject, body, HtmlBody);

                if (result)
                {
                    TempData["Success"] = "Mensaje enviado satisfactoriamente!";
                    
                }

            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
