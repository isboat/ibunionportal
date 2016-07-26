using System.Security.Principal;
using Portal.Web.Interfaces;

namespace Portal.Web.Logics.AuthenticationModels
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role) { return false; }



        public int Id { get; set; }

        public int AsscId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int UserLoginRole { get; set; }

        public string MembershipType { get; set; }

        public bool CanInvest { get; set; }

        public bool CanDoChildBenefit { get; set; }

        public bool IsAdmin { get; set; }
    }
}
