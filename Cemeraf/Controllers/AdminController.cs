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

        private const string ADMINISTRATORS_ROLE = "ADMINISTRATORS";

        private readonly UserService UsersService;
        public AdminController(CitasService citasS, DoctorService doctorsS,
            UserManager<CemerafUser> userM,
            SpecialtiesService specialtiesS,
            UserService usersService)
        {
            CitasService = citasS;
            DoctorsService = doctorsS;
            UserManager = userM;
            SpecialtiesService = specialtiesS;
            UsersService = usersService;
        }

        public IActionResult Index()
        {
            var msg = TempData["MSG"];
            if (msg != null)
            {
                if(!msg.Equals(""))
                    ViewBag.Msg = msg;
            }
            CemerafUser currentUser = UserManager.GetUserAsync(HttpContext.User).Result;
            string userId = currentUser.Id;
            int totalDoctors = DoctorsService.GetAll().Result.Count();
            int totalCitas = CitasService.GetAllByUser(userId).Result.Count();
            int totalSpecialties = SpecialtiesService.GetAll().Result.Count();
            int totalUsers = UsersService.GetAll().Result.Count();
            return View(new AdminIndexViewModel {
                TotalDoctorsAdded = totalDoctors,
                TotalCitasByCurrentUser = totalCitas,
                TotalSpecialties = totalSpecialties,
                Name = currentUser.Firstname,
                Lastname = currentUser.Lastname,
                Birthdate = currentUser.Birthdate,
                Sexo = currentUser.Sex,
                ProfilePicture = "",
                Nacionalidad = "",
                TotalUsers = totalUsers
            });
        }

        public IActionResult AllUsers()
        {
            var users = UsersService.GetAll().Result;
            AllUsersViewModel model = new AllUsersViewModel();
            List<Usuario> Usuarios = new List<Usuario>();
            List<Usuario> Administradores = new List<Usuario>();

            foreach (CemerafUser u in users)
            {
                var user = new Usuario {
                    Nombre = u.Firstname,
                    Apellido = u.Lastname,
                    Email = u.Email,
                    Edad = GetUserAge(u.Birthdate),
                    Id = u.Id,
                    Sexo = u.Sex,
                    TotalCitas = CitasService.GetAllByUser(u.Id).Result.Count()
                };

                if (IsAdmin(u))
                {
                    Administradores.Add(user);
                }
                else
                {
                    Usuarios.Add(user);
                }
            }
            model.Administrators = Administradores;
            model.Users = Usuarios;

            return View(model);
        }

        private bool IsAdmin(CemerafUser u)
        {
            bool result = false;
            CemerafUser user = UsersService.GetById(u.Id).Result;

            if(user != null)
            {
                if(UserManager.IsInRoleAsync(user, ADMINISTRATORS_ROLE).Result)
                {
                    result = true;
                }
            }

            return result;
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

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MakeUserAdmin(string userId)
        {
            CemerafUser user = UsersService.GetById(userId).Result;
            if(user == null)
            {
                TempData["MSG"] = "Usuario no encontrado.";
                return RedirectToAction("Index");
            }
            bool result = UsersService.AddToRolAsync(user, ADMINISTRATORS_ROLE).Result;

            if (result)
            {
                TempData["MSG"] = "El usuario ha sido agregado al grupo de administradores.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["MSG"] = "No se pudo agregar este usuario al grupo de administradores.";
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult RemoveUserAdmin(string userId)
        {
            CemerafUser user = UsersService.GetById(userId).Result;
            if (user == null)
            {
                TempData["MSG"] = "Usuario no encontrado.";
                return RedirectToAction("Index");
            }
            bool result = UsersService.RemoveFromRolAsync(user, ADMINISTRATORS_ROLE).Result;

            if (result)
            {
                TempData["MSG"] = "El usuario ha sido eliminado del grupo de administradores.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["MSG"] = "No se pudo eliminar este usuario del grupo de administradores.";
                return RedirectToAction("Index");
            }

        }
    }
}