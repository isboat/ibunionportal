using System.Collections.Generic;
using Portal.Web.ViewModels;
using Portal.Web.ViewModels.Admin;

namespace Portal.Web.Interfaces
{
    public interface IAdminLogic
    {
        BaseResponse CreateAdmin(RegisterAdminRequest request);
        List<AdminUser> GetAllAdmins();
        AdminUser GetAdmin(int id);
        BaseResponse EditAdmin(EditAdminRequest request);
        BaseResponse DeleteAdmin(int id);
    }
}
