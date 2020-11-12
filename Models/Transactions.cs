using System;
using System.Collections.Generic;

namespace Hort_Ed.Models
{
    public partial class Transactions
    {
        public int TransactionId { get; set; }
        public int? CustomerId { get; set; }
        public string SeminarId { get; set; }
        public int? KitSelection { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string ChangeAction { get; set; }

        public Customers Customer { get; set; }
        public Kits Kit { get; set; }
        public Seminars Seminar { get; set; }
    }
}
