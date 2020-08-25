using System;
using System.Collections.Generic;

namespace KioskApi.Core.Models
{
    public partial class Rates
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal Value { get; set; }
    }
}
