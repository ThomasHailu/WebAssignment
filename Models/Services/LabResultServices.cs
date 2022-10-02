using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_System.Models.Base;
using Hospital_Management_System.Models.Laboratory;

namespace Hospital_Management_System.Models.Services
{
    public class LabResultServices : EntityBaseRepository<LabResult>, ILabResultServices
    {
       
        public LabResultServices(ApplicationDbContext context):base(context)
        {
           
        }
        
    }
    
}
