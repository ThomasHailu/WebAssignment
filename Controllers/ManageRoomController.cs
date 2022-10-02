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
using Hospital_Management_System.Migrations;
using ManageRoom = Hospital_Management_System.Models.Reception.ManageRoom;

namespace Hospital_Management_System.Controllers
{
    public class ManageRoomController : Controller
    {
        private readonly IManageRoomServices _services;

        public ManageRoomController(IManageRoomServices services)
        {
            _services = services;
        }

        // GET: ManageRoom
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

            var manageroom = await _services.GetByIdAsync((long)id);
            if (manageroom == null)
            {
                return NotFound();
            }

            return View(manageroom);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,EndTime,ApplicationUserId,RegisterPatientId")] ManageRoom manageRoom)
        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(manageRoom);
                return RedirectToAction(nameof(Index));

            }
            return View(manageRoom);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageroom = await _services.GetByIdAsync((long)id);
            if (manageroom == null)
            {
                return NotFound();
            }
            return View(manageroom);
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,RoomNumber,RegisterPatientId,RoomType")] ManageRoom manageRoom)
        {
            if (id != manageRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _services.UpdateAsync(id, manageRoom);

                return RedirectToAction(nameof(Index));
            }
            return View(manageRoom);
        }

    }

}
