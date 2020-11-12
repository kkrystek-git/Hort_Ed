using System;
using System.Collections.Generic;

namespace Hort_Ed.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Enrollments = new HashSet<Enrollments>();
            Transactions = new HashSet<Transactions>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string UserAccountId { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
    }
}
