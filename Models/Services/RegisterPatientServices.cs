using Hospital_Management_System.Models.Base;
using Hospital_Management_System.Models.Reception;

namespace Hospital_Management_System.Models.Services
{
    public class RegisterPatientServices : EntityBaseRepository<RegisterPatient>, IRegisterPatientServices
    {
        public RegisterPatientServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
