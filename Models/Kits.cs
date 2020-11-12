using System;
using System.Collections.Generic;

namespace Hort_Ed.Models
{
    public partial class Kits
    {
        public Kits()
        {
            Enrollments = new HashSet<Enrollments>();
            SeminarsMaterialKit1Navigation = new HashSet<Seminars>();
            SeminarsMaterialKit2Navigation = new HashSet<Seminars>();
            SeminarsMaterialKit3Navigation = new HashSet<Seminars>();
            Transactions = new HashSet<Transactions>();
        }

        public int KitId { get; set; }
        public string KitName { get; set; }
        public string Cost { get; set; }
        public string Details { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; }
        public ICollection<Seminars> SeminarsMaterialKit1Navigation { get; set; }
        public ICollection<Seminars> SeminarsMaterialKit2Navigation { get; set; }
        public ICollection<Seminars> SeminarsMaterialKit3Navigation { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
    }
}
