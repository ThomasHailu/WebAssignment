using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.Doctor;
using Hospital_Management_System.Models.Services;

namespace Hospital_Management_System.Controllers
{
    public class PrescribeDrugController : Controller
    {
        private readonly IPrescribeDrugServices _services;
        


        public PrescribeDrugController(IPrescribeDrugServices services)
        {
            _services = services;
        
        }

      
        public async Task<IActionResult> Index()
        {
            
            return View(await _services.GetAllAsync());
        }

       
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescribedrug = await _services.GetByIdAsync((long)id);
            if (prescribedrug == null)
            {
                return NotFound();
            }

            return View(prescribedrug);
        }

       
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Age,RegisterPatientId,MedicalCase,Allergies,Disabilities,Drugs,Dossage,Unit,DietsToFollow,SignedBy")] PrescribeDrug prescribeDrug)
        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(prescribeDrug);
                return RedirectToAction(nameof(Index));

            }
            return View(prescribeDrug);
        }

        
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescribedrug = await _services.GetByIdAsync((long)id);
            if (prescribedrug == null)
            {
                return NotFound();
            }
            return View(prescribedrug);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Date,Age,RegisterPatientId,MedicalCase,Allergies,Disabilities,Drugs,Dossage,Unit,DietsToFollow,SignedBy")] PrescribeDrug prescribeDrug)
        {

            if (id != prescribeDrug.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _services.UpdateAsync(id, prescribeDrug);

                return RedirectToAction(nameof(Index));
            }
            return View(prescribeDrug);
        }

        

        
    }
}
