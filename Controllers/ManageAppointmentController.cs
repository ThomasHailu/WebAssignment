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
    public class ManageAppointmentController : Controller
    {
        private readonly IManageAppointmentServices _services;

        public ManageAppointmentController(IManageAppointmentServices services)
        {
            _services = services;
        }

        // GET: ManageAppointment
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAllAsync());
        }

        // GET: ManageAppointment/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageappointment = await _services.GetByIdAsync((long)id);
            if (manageappointment == null)
            {
                return NotFound();
            }

            return View(manageappointment);
        }

        // GET: ManageAppointment/Create
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,EndTime,ApplicationUserId,RegisterPatientId")] ManageAppointment manageAppointment)
        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(manageAppointment);
                return RedirectToAction(nameof(Index));

            }
            return View(manageAppointment);
        }

       
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageappointment = await _services.GetByIdAsync((long)id);
            if (manageappointment == null)
            {
                return NotFound();
            }
            return View(manageappointment);
        }

        // POST: ManageAppointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,StartTime,EndTime,ApplicationUserId,RegisterPatientId")] ManageAppointment manageAppointment)
        {
            if (id != manageAppointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _services.UpdateAsync(id, manageAppointment);

                return RedirectToAction(nameof(Index));
            }
            return View(manageAppointment);
        }
         
        

        // GET: ManageAppointment/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var data = await _services.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            return View(data);
        }

        // POST: ManageAppointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var data = await _services.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
