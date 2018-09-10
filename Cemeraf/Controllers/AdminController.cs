using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cemeraf.Models;
using Cemeraf.Services;
using Cemeraf.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Cemeraf.Controllers
{
    [Authorize()]
    public class AdminController : Controller
    {
        private readonly CitasService CitasService;
        private readonly DoctorService DoctorsService;
        private readonly UserManager<CemerafUser> UserManager;
        private readonly SpecialtiesService SpecialtiesService;
        public AdminController(CitasService citasS, DoctorService doctorsS,
            UserManager<CemerafUser> userM,
            SpecialtiesService specialtiesS)
        {
            CitasService = citasS;
            DoctorsService = doctorsS;
            UserManager = userM;
            SpecialtiesService = specialtiesS;
        }

        public IActionResult Index()
        {
            CemerafUser currentUser = UserManager.GetUserAsync(HttpContext.User).Result;
            string userId = currentUser.Email;
            int totalDoctors = DoctorsService.GetAll().Result.Count();
            int totalCitas = CitasService.GetAllByUser(userId).Result.Count();
            int totalSpecialties = SpecialtiesService.GetAll().Result.Count();
            return View(new AdminIndexViewModel {
                TotalDoctorsAdded = totalDoctors,
                TotalCitasByCurrentUser = totalCitas,
                TotalSpecialties = totalSpecialties,
                Name = currentUser.Firstname,
                Lastname = currentUser.Lastname,
                Birthdate = currentUser.Birthdate,
                Sexo = currentUser.Sex,
                ProfilePicture = "",
                Nacionalidad = ""
            });
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}