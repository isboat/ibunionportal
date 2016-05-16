namespace Portal.Web.Logics.AuthenticationModels
{
    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserLoginRole { get; set; }
        public string MembershipType { get; set; }
        public bool CanInvest { get; set; }
        public bool CanDoChildBenefit { get; set; }
        public bool IsAdmin { get; set; }
    }
}
