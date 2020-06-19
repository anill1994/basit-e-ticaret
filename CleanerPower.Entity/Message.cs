using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanerPower.Entity
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mesaj { get; set; }
        

        [BindNever]
        public DateTime Date { get; set; }

    }
}
