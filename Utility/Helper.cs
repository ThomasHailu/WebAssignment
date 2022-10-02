using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_System.Utility
{
    public static class Helper
    {
        public static string HR = "HR";
        public static string Doctor = "Doctor";
        public static string Reception = "Reception";
        public static string Labratory = "Labratory";
        public static string Patient = "Patient";


        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value=Helper.HR,Text=Helper.HR },
                new SelectListItem { Value=Helper.Doctor,Text=Helper.Doctor },
                new SelectListItem { Value=Helper.Reception,Text=Helper.Reception },
                new SelectListItem { Value=Helper.Labratory,Text=Helper.Labratory }
            };
        }
        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int i = 1; i <= 6; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr" });
                minute = minute + 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr 30 min" });
                minute = minute + 30;
            }
            return duration;
        }
    }
}
