using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentSystem.Models
{
    public partial class Payment
    {
        //public int Id { get; set; }
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
