
using Backend.ViewModels.Authentication;

namespace Backend.Interfaces
{
    public interface IAuthentication
    {
        LoginResponse Login(string username, string password, bool isAdmin = false);
    }
}
