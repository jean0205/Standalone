using System;
using System.Collections.Generic;

namespace KioskApi.Core.Models
{
    public partial class Empr
    {
        public int Id { get; set; }
        public int EmployerNo { get; set; }
        public int EmployerSub { get; set; }
        public string BusinessName { get; set; }
        public string RealName { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessTown { get; set; }
        public string BusinesssParish { get; set; }
        public string RealAddress { get; set; }
        public string RealTown { get; set; }
        public string RealParish { get; set; }
        public string RealPhone { get; set; }
        public string BusinessPhone { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
    }
}
