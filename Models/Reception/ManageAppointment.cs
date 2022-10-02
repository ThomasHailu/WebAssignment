using Hospital_Management_System.Models.Base;
using Hospital_Management_System.ViewModels.HR;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models.Reception
{
    public class ManageAppointment : IEntityBase
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ApplicationUserId { get; set; }//DoctorId
        public long RegisterPatientId { get; set; }//patientId

        public virtual RegisterPatient RegisterPatient { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
