using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portal.Web.ViewModels.Account
{
    public class LoanRequest : BaseRequest
    {
        [DisplayName("Reason for requesting loan")]
        [Required]
        public string Reason { get; set; }

        public int PendingLoanId { get; set; }
    }
}
