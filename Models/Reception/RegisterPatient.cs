using Hospital_Management_System.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Hospital_Management_System.Models.Reception
{
    public class RegisterPatient : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set ; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(13)]
        public string PhoneNo { get; set; }

        [Required]
        [MaxLength(10)]
        public string DateOfBirth { get; set; }

        [Required]
        
        public string Gender { get; set; }

        [Required]
        public string Adrress { get; set; }

        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public bool Active { get; set; }

    
    }
}
