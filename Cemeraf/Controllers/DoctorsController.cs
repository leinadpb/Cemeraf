﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cemeraf.Models;
using Cemeraf.Services;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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