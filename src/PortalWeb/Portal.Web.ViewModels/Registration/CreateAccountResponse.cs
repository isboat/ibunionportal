using System.Runtime.Serialization;
using Portal.Web.Enums.Registration;

namespace Portal.Web.ViewModels.Registration
{
    [DataContract]
    public class CreateAccountResponse
    {

        [DataMember(IsRequired = true)]
        public int MemberId { get; set; }
        
        [DataMember(IsRequired = true)]
        public RegistrationStatus Status { get; set; }
        
    }
}
