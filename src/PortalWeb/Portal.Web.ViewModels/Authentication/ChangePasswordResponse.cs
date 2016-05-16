using System.Runtime.Serialization;
using Portal.Web.Enums.Authentication;

namespace Portal.Web.ViewModels.Authentication
{
    [DataContract]
    public class ChangePasswordResponse
    {
        public AuthenticationStatus Status { get; set; }
    }
}
