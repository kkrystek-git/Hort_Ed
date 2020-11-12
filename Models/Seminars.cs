using System;
using System.Collections.Generic;

namespace Hort_Ed.Models
{
    public partial class Seminars
    {
        public Seminars()
        {
            Enrollments = new HashSet<Enrollments>();
            Transactions = new HashSet<Transactions>();
        }

        public string SeminarId { get; set; }
        public string SeminarTitle { get; set; }
        public string Seasonal { get; set; }
        public string DeliveryType { get; set; }
        public int? MaterialKit1 { get; set; }
        public int? MaterialKit2 { get; set; }
        public int? MaterialKit3 { get; set; }
        public string Details { get; set; }
        public string EventDate { get; set; }

        public Kits MaterialKit1Navigation { get; set; }
        public Kits MaterialKit2Navigation { get; set; }
        public Kits MaterialKit3Navigation { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
    }
}
