using Hospital_Management_System.Migrations;
using Hospital_Management_System.Models.Base;
using Hospital_Management_System.Models.Reception;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegisterPatient = Hospital_Management_System.Models.Reception.RegisterPatient;

namespace Hospital_Management_System.Models.Laboratory
{
    public class LabResult : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public long RegisterPatientId { get; set; }

        public string PatientName { get; set; }
        [Required]
        public string MedicalCase { get; set; }
        [Required]
        public string TestNo { get; set; }
        public bool BloodWork { get; set; }
        public bool Stool { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SignedBy { get; set; }

        public virtual RegisterPatient RegisterPatient { get; set; }
    }
}

