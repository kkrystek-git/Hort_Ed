using System;
using System.Collections.Generic;

namespace Hort_Ed.Models
{
    public partial class Enrollments
    {
        public int EnrollmentId { get; set; }
        public int? CustomerId { get; set; }
        public string SeminarId { get; set; }
        public int? KitSelection { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Notes { get; set; }

        public Customers Customer { get; set; }
        public Kits Kit { get; set; }
        public Seminars Seminar { get; set; }
    }
}
