using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentSystem.Models
{
    public partial class User
    {
        public User()
        {
            Payments = new HashSet<Payment>();
        }
        //public int UserId { get; set; }
        public int Id { get; set; }
        public decimal AccountBalance { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
