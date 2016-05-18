using System.Security.Principal;

namespace Backend.Interfaces
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
