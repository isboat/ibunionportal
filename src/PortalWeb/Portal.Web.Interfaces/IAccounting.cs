using Portal.Web.ViewModels.Accounting;

namespace Portal.Web.Interfaces
{
    public interface IAccounting
    {
        TotalData TotalMonthlyDues(int year);

        TotalData InvestmentData(int year);
    }
}
