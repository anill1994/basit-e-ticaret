using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanerPower.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Pieces { get; set; }
        public string Pay { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }


        [BindNever]
        public DateTime Date { get; set; }

    }
}
