using System.ComponentModel;

namespace Portal.Web.ViewModels.Authentication
{
    public class ChangePasswordRequest
    {
        public string AccountKey { get; set; }

        [DisplayName("Current password")]
        public string OldPassword { get; set; }

        [DisplayName("New password")]
        public string NewPassword { get; set; }

        [DisplayName("Confirm new password")]
        public string ConfirmNewPassword { get; set; }
    }
}
