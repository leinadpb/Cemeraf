using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cemeraf.Models;
using Cemeraf.Services;
using Microsoft.AspNetCore.Authorization;
using Cemeraf.ViewModels;

namespace Cemeraf.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly DoctorService DoctorsService;
        private readonly SpecialtiesService SpecialtiesService;

        public DoctorsController(DoctorService doctorService, SpecialtiesService specialtiesService)
        {
            DoctorsService = doctorService;
            SpecialtiesService = specialtiesService;
        }

        [HttpGet]
        public IActionResult Index([FromRoute] string searchText)
        {
            IEnumerable<Doctor> doctors;

            if (String.IsNullOrEmpty(searchText))
            {
                doctors = DoctorsService.GetAll().Result;
            }
            else
            {
                List<string> words = GetWholeWords(searchText); // in upper case, without spaces
                doctors = DoctorsService.FilterBy(words).Result;
            }
            if(TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }
            ViewBag.search = $"{doctors.Count()} doctores encontrados.";

            return View(doctors);
        }

        private List<string> GetWholeWords(string searchText)
        {
            return searchText.Trim().ToUpper().Split(",").ToList();
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
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var savedDoctor = await DoctorsService.Create(doctor);
                
                if(savedDoctor != null)
                {
                    TempData["Success"] = "El doctor ha sido creado exitosamente.";
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