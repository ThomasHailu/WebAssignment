using Hospital_Management_System.Models;
using Hospital_Management_System.ViewModels.HR;
using Hospital_Management_System.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace Hospital_Management_System.Controllers
{
    public class HRController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HRController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var obj = (from user in _db.Users
                       join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                       join roles in _db.Roles on userRoles.RoleId equals roles.Id
                       select new IndexVM
                       {
                           Id = user.Id,
                           Name = user.Name,
                           Role = roles.Name,
                           IsActive = user.IsActive
                       }).ToList();
            return View(obj);
        }

        public async Task<IActionResult> RegisterEmployee()
        {
            if (!_roleManager.RoleExistsAsync(Helper.HR).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.HR));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Doctor));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Reception));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Labratory));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterEmployee(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Id = model.Id,
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    IsActive = model.IsActive
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "HR");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public IActionResult UpdateEmployee(string id)
        {
            if (id == null) return NotFound();
            var obj = _db.Users.Find(id);
            if (obj == null) return NotFound();

            UpdateVM employee = new UpdateVM()
            {
                Name = obj.Name,
                Email = obj.Email,
                IsActive = obj.IsActive,
                RoleName = (from user in _db.Users
                            where user.Id == id
                            join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                            join roles in _db.Roles on userRoles.RoleId equals roles.Id
                            select roles.Name).FirstOrDefault()
                
            };
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateVM model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.Id);
                if (user == null) return NotFound();

                bool passwordChanged = false;
                if (model.Password != "") passwordChanged = true;
                if (passwordChanged) user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    user.UserName = model.Email;
                    user.Email = model.Email;
                    user.Name = model.Name;
                    user.IsActive = model.IsActive;
                    var roleToEditID = _db.UserRoles.FirstOrDefault(ur => ur.UserId == model.Id).RoleId;
                    var oldRoleName = _db.Roles.FirstOrDefault(r => r.Id == roleToEditID).Name;
                    result = await _userManager.RemoveFromRoleAsync(user, oldRoleName);
                    //Check for err
                    result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    return RedirectToAction("Index", "HR");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
