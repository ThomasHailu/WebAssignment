using Hospital_Management_System.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using Hospital_Management_System.Models.Reception;

namespace Hospital_Management_System.Models.Doctor
{
    public class PrescribeDrug : IEntityBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Age { get; set; }
        //include patient id
        [Required]
        public long RegisterPatientId { get; set; }
        [Required]
        public string MedicalCase { get; set; }

        public string Allergies { get; set; }

        public string Disabilities { get; set; }

        [Required]
        public string Drugs{get;set;}

        [Required]
        public string Dossage { get; set; }

        [Required]
        public string Unit { get; set; }

        public string DietsToFollow { get; set; }

        [Required]
        public string SignedBy { get; set; } 

        public virtual RegisterPatient RegisterPatient { get; set; }
    }
}
