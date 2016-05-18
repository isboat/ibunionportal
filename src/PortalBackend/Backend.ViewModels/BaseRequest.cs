using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModels
{
    public class BaseRequest
    {
        public int MemberId { get; set; }

        public string Address { get; set; }

        [DisplayName("Request date")]
        public string RequestDate { get; set; }

        public string MemberName { get; set; }

        [DisplayName("Tick to Grant")]
        public bool Granted { get; set; }

        [DisplayName("Amount")]
        [Required]
        public decimal Amount { get; set; }
    }
}
