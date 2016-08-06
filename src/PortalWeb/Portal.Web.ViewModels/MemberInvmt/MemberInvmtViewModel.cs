using Portal.DataObjects;
using System.Collections.Generic;
using System.ComponentModel;

namespace Portal.Web.ViewModels.MemberInvmt
{
    public class MemberInvmtViewModel
    {
        public int InvmtId { get; set; }

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

    public class ViewMemberInvestment
    {
        public string MemberId { get; set; }

        public string MemberName { get; set; }

        public MembershipType MembershipType { get; set; }

        public string Address { get; set; }

        public decimal TotalInvested { get; set; }

        public List<MemberInvmtViewModel> Investments { get; set; }

        public List<WithdrawInvestmentRequest> Withdrawals { get; set; }
    }
}
