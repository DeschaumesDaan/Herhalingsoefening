using System;
using System.Collections.Generic;
using System.Text;

namespace HerhalingsOefening.Models
{
    public class Review
    {
        public string UserName { get; set; }
        public decimal Score { get; set; }
        public string Comment { get; set; } = "";
        public DateTime DateOfVisit { get; set; } = DateTime.Now;
    }
}
