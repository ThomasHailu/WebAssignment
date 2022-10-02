using Hospital_Management_System.Models.Base;
using Hospital_Management_System.Models.Reception;

namespace Hospital_Management_System.Models.Services
{
    public class ManageRoomServices : EntityBaseRepository<ManageRoom>, IManageRoomServices
    {
        public ManageRoomServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
