using Microsoft.AspNetCore.Identity;

namespace Hospital_Management_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
