using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.Reception;
using Hospital_Management_System.Models.Services;

namespace Hospital_Management_System.Controllers
{
    public class RegisterPatientController : Controller
    {
        private readonly IRegisterPatientServices _services;

        public RegisterPatientController(IRegisterPatientServices services)
        {
            _services = services;
        }

        // GET: RegisterPatients
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAllAsync());
        }
        
        public async Task<IActionResult> Index2()
        {
            return View(await _services.GetAllAsync());
        }


        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerpatient = await _services.GetByIdAsync((long)id);
            if (registerpatient == null)
            {
                return NotFound();
            }

            return View(registerpatient);
        }

        // GET: RegisterPatients/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,PhoneNo,DateOfBirth,Gender,Adrress,Height,Weight,BloodType,Allergies,Active")] RegisterPatient registerPatient)
        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(registerPatient);
                return RedirectToAction(nameof(Index));

            }
            return View(registerPatient);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerpatient = await _services.GetByIdAsync((long)id);
            if (registerpatient == null)
            {
                return NotFound();
            }
            return View(registerpatient);
        }
       
        public async Task<IActionResult> Edit2(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerpatient = await _services.GetByIdAsync((long)id);
            if (registerpatient == null)
            {
                return NotFound();
            }
            return View(registerpatient);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,MiddleName,LastName,PhoneNo,DateOfBirth,Gender,Adrress,Height,Weight,BloodType,Allergies,Active")] RegisterPatient registerPatient)
        {
            if (id != registerPatient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _services.UpdateAsync(id, registerPatient);

                return RedirectToAction(nameof(Index));
            }
            return View(registerPatient);
        }

       
    }
}
