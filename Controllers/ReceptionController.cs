using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class ReceptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
