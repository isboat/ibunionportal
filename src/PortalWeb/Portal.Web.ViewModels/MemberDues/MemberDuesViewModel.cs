using Portal.DataObjects;
using System.Collections.Generic;
using System.ComponentModel;

namespace Portal.Web.ViewModels.MemberDues
{
    public class ViewMemberDues
    {
        public string MemberId { get; set; }

        public string MemberName { get; set; }

        public MembershipType MembershipType { get; set; }

        public string Address { get; set; }

        public List<MemberDuesViewModel> Dues { get; set; }
        
    }
    public class MemberDuesViewModel
    {
        public int DuesId { get; set; }

        public int MemberId { get; set; }

        [DisplayName("Member's name")]
        public string MemberName { get; set; }

        public decimal Amount { get; set; }

        [DisplayName("Month")]
        public string DuesMonth { get; set; }

        [DisplayName("Year")]
        public string DuesYear { get; set; }

        [DisplayName("Added Date")]
        public string AddedDate { get; set; }

        [DisplayName("Added by")]
        public string AddedBy { get; set; }

        public int AddedById { get; set; }

        public bool Paid { get; set; }
    }

    public class MonthViewModel
    {
        public string Month { get; set; }
        public int Year { get; set; }
    }
}
