using Hospital_Management_System.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hospital_Management_System.Models.Reception
{
    public class ManageRoom : IEntityBase
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long RoomNumber { get; set; }

        [AllowNull]
        public long RegisterPatientId { get; set; }

        [Required]
        public string RoomType { get; set; }


        public virtual RegisterPatient RegiterPatient { get; set; } 
    }
}
