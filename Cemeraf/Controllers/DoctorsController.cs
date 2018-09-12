using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cemeraf.Models;
using Cemeraf.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cemeraf.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly DoctorService DoctorsService;
        public DoctorsController(DoctorService doctorService)
        {
            DoctorsService = doctorService;
        }
        public IActionResult Index()
        {
            var doctors = DoctorsService.GetAll().Result;
            return View(doctors);
        }

        [Authorize("ADMINISTRATORS")]
        public IActionResult Edit(int id)
        {
            Doctor doc = DoctorsService.GetById(id).Result;
            if (doc != null)
            {
                return View(doc);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Details(int doctorId)
        {
            Doctor doc = DoctorsService.GetById(doctorId).Result;
            if(doc == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(doc);
            }
        }

        [Authorize("ADMINISTRATORS")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("ADMINISTRATORS")]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var savedDoctor = DoctorsService.Create(doctor);
                if(savedDoctor != null)
                {
                    ViewBag.Success = "El doctor ha sido creado exitosamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "El doctor no se ha podido crear, inténtelo de nuevo. Si el problema persiste contacte a su administrador web.";
                }
            }
            return View();
        }
    }
}