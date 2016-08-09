using Portal.Web.ViewModels.Accounting;

namespace Portal.Web.Interfaces
{
    public interface IAccounting
    {
        TotalData TotalMonthlyDues(int year, string mType);

        TotalData InvestmentData(int year, string mType);
    }
}
