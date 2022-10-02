using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_System.ViewModels;
using Hospital_Management_System.Models.Laboratory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.Models.Doctor;
using Hospital_Management_System.Models.Reception;

namespace Hospital_Management_System.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LabResult> LabResults { get; set; }
        public DbSet<PrescribeDrug> PrescribeDrugs { get; set; }
        public DbSet<RegisterPatient> RegisterPatients { get; set; }
        public DbSet<ManageRoom> ManageRooms { get; set; }
        public DbSet<ManageAppointment> ManageAppointments { get; set; }


    }

}
