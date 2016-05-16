using System.Collections.Generic;
using Portal.DataObjects.Accounts;

namespace Portal.DataAccess.Interfaces
{
    public interface IAccountingRepository
    {
        List<MemberDues> GetAll_AnnualDues(int year);

        List<MemberInvmt> GetAll_Investments(int year);
    }
}
