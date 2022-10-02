using Hospital_Management_System.Models.Base;
using Hospital_Management_System.Models.Doctor;

namespace Hospital_Management_System.Models.Services
{
    public class PrescribeDrugServices : EntityBaseRepository<PrescribeDrug>, IPrescribeDrugServices
    {
        public PrescribeDrugServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
