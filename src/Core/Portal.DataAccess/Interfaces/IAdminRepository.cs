using System.Collections.Generic;
using Portal.DataObjects.Accounts;
using Portal.DataObjects.Admin;

namespace Portal.DataAccess.Interfaces
{
    public interface IAdminRepository
    {
        BaseUserInfo Login(string email, string password, int asscId);

        int CreateAdmin(CreateAdmin admin);
        List<BaseUserInfo> GetAllAdmins();
        AdminUserInfo GetAdmin(int id);
        int EditAdmin(EditAdmin editAdmin);
        int DeleteAdmin(int id);
    }
}
