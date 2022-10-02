﻿using Hospital_Management_System.Models.Base;
using Hospital_Management_System.Models.Reception;

namespace Hospital_Management_System.Models.Services
{
    public class ManageAppointmentServices : EntityBaseRepository<ManageAppointment>, IManageAppointmentServices
    {
        public ManageAppointmentServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
