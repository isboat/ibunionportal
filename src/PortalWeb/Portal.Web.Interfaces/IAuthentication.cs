using Portal.Web.ViewModels.Authentication;

namespace Portal.Web.Interfaces
{
    public interface IAuthentication
    {
        LoginResponse Login(string username, string password, bool isAdmin = false);

        ChangePasswordResponse ChangePassword(ChangePasswordRequest request);
    }
}
