using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.ViewModels.HR
{
    public class IndexVM
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
