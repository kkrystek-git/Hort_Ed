using System;
using System.Collections.Generic;

namespace Hort_Ed.ViewModels {

public class EnrollViewModel
    {
        public int EnrollmentId { get; set; }
        public string SeminarId { get; set; }
        public string SeminarName { get; set; }
        public int? KitSelection { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Notes { get; set; }


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

    }
}
