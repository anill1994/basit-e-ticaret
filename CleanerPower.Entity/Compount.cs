using CleanerPower.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanerPower.Models
{
    public class Compount
    {
        public int CompountId { get; set; }
        public Order Order { get; set; }
        public Message Message { get; set; }
    }
}
