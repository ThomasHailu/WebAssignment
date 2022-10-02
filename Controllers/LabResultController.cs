using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.Laboratory;
using Hospital_Management_System.Models.Services;
using Hospital_Management_System.Migrations;

namespace Hospital_Management_System.Controllers
{
    public class LabResultController : Controller
    {
        private readonly ILabResultServices _services;

        public LabResultController(ILabResultServices services)
        {
            _services = services;
        }

        // GET: LabResult
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

            var labResult = await _services.GetByIdAsync((long)id);
            if (labResult == null)
            {
                return NotFound();
            }

            return View(labResult);
        }
        public async Task<IActionResult> Details2(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labResult = await _services.GetByIdAsync((long)id);
            if (labResult == null)
            {
                return NotFound();
            }

            return View(labResult);
        }


        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,RegisterPatientId,PatientName,MedicalCase,TestNo,BloodWork,Stool,Description,SignedBy")] LabResult labResult)
        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(labResult);
                return RedirectToAction(nameof(Index));
              
            }
            return View(labResult);
        }

        
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labResult = await _services.GetByIdAsync((long)id);
            if (labResult == null)
            {
                return NotFound();
            }
            return View(labResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Date,RegisterPatientId,PatientName,MedicalCase,TestNo,BloodWork,Stool,Description,SignedBy")] LabResult labResult)
        {
            if (id != labResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _services.UpdateAsync(id, labResult);
  
                return RedirectToAction(nameof(Index));
            }
            return View(labResult);
        }


        
    }
}
