using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioskApi.Core.Models.ViewModels
{
    public class RemittanceViewModel   {       
           
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
