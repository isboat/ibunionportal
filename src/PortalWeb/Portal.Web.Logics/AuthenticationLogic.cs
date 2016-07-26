using System;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.Security;
using Portal.Caching;
using Portal.DataAccess.Interfaces;
using Portal.Web.Enums.Authentication;
using Portal.Web.Interfaces;
using Portal.Web.Logics.AuthenticationModels;
using Portal.Web.ViewModels.Authentication;

namespace Portal.Web.Logics
{
    public class AuthenticationLogic : IAuthentication
    {
        //private readonly UpaCarConfiguration upaCarConfiguration = new UpaCarConfiguration();

        private readonly IAccountRepository accountRepository;

        private readonly IAdminRepository adminRepository;

        public AuthenticationLogic(IAccountRepository accountRepository, IAdminRepository adminRepository)
        {
            this.accountRepository = accountRepository;
            this.adminRepository = adminRepository;
        }

        public LoginResponse Login(string username, string password, bool isAdmin = false)
        {
            var cacheKey = GlobalCachingProvider.Instance.GetCacheKey("AuthenticationLogic", "Login", username, password, isAdmin.ToString());

            if (GlobalCachingProvider.Instance.ItemExist(cacheKey))
            {
                // return (LoginResponse)GlobalCachingProvider.Instance.GetItem(cacheKey);
            }

            var asscId = Convert.ToInt32(ConfigurationManager.AppSettings["asscid"]);

            var userAccount = isAdmin ?
                this.adminRepository.Login(username, password, asscId) :
                this.accountRepository.Login(username, password, asscId);
            
            if (userAccount != null)
            {
                var serializeModel = new CustomPrincipalSerializeModel
                {
                    Id = userAccount.AccountId,
                    AsscId = userAccount.AsscId,
                    FirstName = userAccount.FirstName,
                    LastName = userAccount.LastName,
                    Email = userAccount.EmailAddress,
                    UserLoginRole = userAccount.LoginRole,
                    MembershipType = userAccount.MembershipType,
                    CanInvest = userAccount.CanInvest,
                    CanDoChildBenefit = userAccount.CanDoChildBenefit,
                    IsAdmin = userAccount.IsAdmin
                };

                var response = new LoginResponse();

                if (userAccount.LoginRole == 0)
                {
                    response.AuthenticationStatus = AuthenticationStatus.Failed;
                    response.Message = "Your information has been received, waiting for approval.";
                    return response;
                }

                var serializer = new JavaScriptSerializer();
                var userData = serializer.Serialize(serializeModel);

                var authTicket = new FormsAuthenticationTicket(
                    1,
                    username,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(15),
                    false,
                    userData);
                
                response = new LoginResponse
                           {
                               AuthenticationStatus = AuthenticationStatus.Successful,
                               AccountKey = userAccount.AccountId.ToString(),
                               FirstName = userAccount.FirstName,
                               LastName = userAccount.LastName,
                               EmailAddress = userAccount.EmailAddress,
                               FormsAuthCookieName = FormsAuthentication.FormsCookieName,
                               FormsAuthCookieValue = FormsAuthentication.Encrypt(authTicket)
                           };

                GlobalCachingProvider.Instance.AddItem(cacheKey, response);

                return response;
            }

            return null;
        }

        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            var oldpwd = this.accountRepository.GetPassword(request.AccountKey);
            var response = new ChangePasswordResponse { Status = AuthenticationStatus.Failed };

            if (oldpwd != request.OldPassword)
            {
                return response;
            }

            var res = this.accountRepository.ChangePassword(request.AccountKey, request.NewPassword);
            if (res > 0)
            {
                response.Status = AuthenticationStatus.Successful;
            }

            return response;
        }
    }
}
