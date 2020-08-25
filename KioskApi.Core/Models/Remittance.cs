using System;
using System.Collections.Generic;

namespace KioskApi.Core.Models
{
    public partial class Remittance
    {
        public int Id { get; set; }
        public int EmployerNo { get; set; }
        public int EmployerSub { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int NisNumber { get; set; }
        public string Name { get; set; }
        public string Frequence { get; set; }
        public int WeekW { get; set; }
        public decimal? Earnings { get; set; }
        public decimal? Contribution { get; set; }
        public decimal? Penalties { get; set; }
        public decimal? Interest { get; set; }
        public string Week1 { get; set; }
        public string Week2 { get; set; }
        public string Week3 { get; set; }
        public string Week4 { get; set; }
        public string Week5 { get; set; }
        public DateTime? RecordDate { get; set; }
    }
}
