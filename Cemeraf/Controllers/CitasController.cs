using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Cemeraf.Models;
using Cemeraf.Services;
using Cemeraf.ViewModels;

namespace Cemeraf.Controllers
{
    [Authorize]
    public class CitasController : Controller
    {
        private readonly SignInManager<CemerafUser> SignInManager;
        private readonly UserManager<CemerafUser> UserManager;
        private readonly UserService UserService;
        private readonly CitasService CitasService;
        private readonly DoctorService DoctorsService;

        public CitasController(SignInManager<CemerafUser> signInManager,
            UserService userService,
            CitasService citasService,
            DoctorService doctorsService,
            UserManager<CemerafUser> userManager)
        {
            SignInManager = signInManager;
            UserService = userService;
            CitasService = citasService;
            DoctorsService = doctorsService;
            UserManager = userManager;
        }

        public IActionResult Index()
        {
            string username = UserManager.GetUserAsync(HttpContext.User).Result.Email;
            IEnumerable<Cita> citas = CitasService.GetAllByUser(username).Result;
            return View(citas);
        }

        public IActionResult Create()
        {
            string userEmail = SignInManager.Context.User.Identity.Name;
            CemerafUser user = UserService.GetByEmail(userEmail).Result;

            int userAge = GetUserAge(user.Birthdate);

            return View(new CreateCitaViewModel {
                Doctors = DoctorsService.GetAll().Result.ToList()
            });
        }

        [HttpPost]
        public IActionResult Create(string Description, Int32? DoctorId, DateTime DateAssigned)
        {
            Cita cita = new Cita();
            if (Description != null && !Description.Equals("") && DateAssigned != null)
            {
                cita.Description = Description;
                cita.Doctor = null;
                cita.Status = "PENDING";
                cita.Approved = false;
                cita.DateRequested = DateTime.Now;
                cita.DateAssigned = DateAssigned;
            }
            if (DoctorId != null)
            {
                if (DoctorId > 0)
                {
                    Doctor doc = DoctorsService.GetById(DoctorId).Result;
                    if (doc != null)
                    {
                        cita.Doctor = doc;
                    }
                }
            }
            CemerafUser currentUser = UserManager.GetUserAsync(HttpContext.User).Result;
            cita.CemerafUser = currentUser;
            var savedCita = CitasService.Add(cita, currentUser.Id).Result;
            if (savedCita != null)
            {
                ViewBag.Success = "La cita se ha registrado, dentro de poco minutos un personal le estará dando seguimiento. ¡Gracias por su tiempo!";
                return RedirectToAction("Index");
            }
            ViewBag.Error = "No puedes tener más de tres citas en estado PENDIENTE. Espera algunos minutos para volver a solicitar otra cita. ¡Gracias!";
            return View(new CreateCitaViewModel
            {
                Doctors = DoctorsService.GetAll().Result.ToList()
            });
        }

        private int GetUserAge(DateTime birthdate)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(birthdate).Ticks).Year - 1;
            DateTime PastYearDate = birthdate.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return Years;
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Cita cita)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id)
        {
            //int _id = Int32.Parse(id);
            Cita cita = CitasService.GetById(id).Result;
            Cita deletedCita = CitasService.Delete(cita).Result;
            if(deletedCita != null)
            {
                ViewBag.Success = "Cita eliminada.";
            }
            return RedirectToAction("Index");
        }
    }
}