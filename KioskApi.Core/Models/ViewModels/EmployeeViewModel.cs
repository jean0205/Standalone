using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KioskAPI.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public int NisNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public DateTime? DateOB { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Parish { get; set; }
        public string Phone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
       
    }
}