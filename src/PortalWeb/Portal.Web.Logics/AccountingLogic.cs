using System;
using System.Collections.Generic;
using System.Linq;
using Portal.DataAccess.Interfaces;
using Portal.DataObjects.Accounts;
using Portal.Web.Interfaces;
using Portal.Web.ViewModels.Account;
using Portal.Web.ViewModels.Accounting;

namespace Portal.Web.Logics
{
    public class AccountingLogic : IAccounting
    {
        
        #region Instances variables
        
        private readonly IAccountRepository accountRepository;

        private readonly IAccountingRepository accountingRepository;

        #endregion

        #region constructors
        
        public AccountingLogic(IAccountRepository accountRepository, IAccountingRepository accountingRepository)
        {
            this.accountRepository = accountRepository;
            this.accountingRepository = accountingRepository;
        }

        #endregion

        public TotalData TotalMonthlyDues(int year, string mType)
        {
            var annualDues = this.accountingRepository.GetAll_AnnualDues(year);
            var allMembers = this.accountRepository.GetMembershipUsers(mType);
            var months = GetMonths(year);

            var total = new TotalData
            {
                AnnualChartData = AnnualDues(annualDues, year, allMembers),
                TotalAmount = GetTotalAmount(annualDues, allMembers),
                TotalUsersWith = allMembers.FindAll(x => months.TrueForAll(m => annualDues.Exists(d => d.DuesMonth == m && x.AccountId == d.MemberId))).Count,
                TotalUsersWithout = allMembers.FindAll(x => !annualDues.Exists(m => m.MemberId == x.AccountId)).Count,
                AnnualMonthlyPaidUser = AnnualMonthlyPaidUser(annualDues, year, allMembers)
            };
            
            return total;
        }

        public TotalData InvestmentData(int year, string mType)
        {
            var investments = this.accountingRepository.GetAll_Investments(year);
            var allMembers = this.accountRepository.GetMembershipUsers(mType);

            var total = new TotalData 
            {
                MTypeMembersCount = allMembers.Count,
                TotalAmount = investments.Sum(x => x.Amount),
                TotalUsersWith =  GetTotalMTypeUsersWith(investments, allMembers),
                TopTenHighestMembers = GetTopTenHighestMembers(investments),
                TopTenMTypeMembers = GetTopTenHighestMTypeMembers(investments, allMembers),
                TotalUsersWithout = allMembers.Where(x => !investments.Exists(e => e.MemberId == x.AccountId)).Count()
            };

            return total;
        }

        private decimal GetTotalAmount(List<MemberDues> annualDues, List<UserAccount> members)
        {
            var membersDues = annualDues.FindAll(x => members.Exists(m => m.AccountId == x.MemberId));
            
            return membersDues.Sum(x => x.Amount);
        }

        private IEnumerable<MemberData> GetTopTenHighestMembers(List<MemberInvmt> investments)
        {
            var users = new List<MemberData>();
            var groups = investments.GroupBy(x => x.MemberId);
            foreach (var g in groups)
            {
                users.Add(new MemberData
                {
                    MemberId = g.First().MemberId,
                    Name = g.First().MemberName,
                    Amount = g.Sum(s => s.Amount)
                });
            }

            return users.OrderByDescending(x => x.Amount).Take(10);
        }

        private int GetTotalMTypeUsersWith(List<MemberInvmt> investments, List<UserAccount> members)
        {
            var indInvts = investments.GroupBy(x => x.MemberId);

            var count = indInvts.Count(indInvt => members.Exists(m => m.AccountId == indInvt.First().MemberId));

            return count;
        }

        private IEnumerable<MemberData> GetTopTenHighestMTypeMembers(List<MemberInvmt> investments, List<UserAccount> members)
        {
            var users = new List<MemberData>();
            var individualInvestments = investments.GroupBy(x => x.MemberId);
            
            foreach (var individualInvestment in individualInvestments)
            {
                var firstInv = individualInvestment.First();

                if (members.Exists(m => firstInv.MemberId == m.AccountId))
                {
                    users.Add(new MemberData
                    {
                        MemberId = firstInv.MemberId,
                        Name = firstInv.MemberName,
                        Amount = individualInvestment.Sum(s => s.Amount)
                    });
                }
            }

            return users.OrderByDescending(x => x.Amount).Take(10);
        }

        private Profile GetHighestPaidUser(List<MemberInvmt> investments, out decimal highest)
        {
            highest = 0;
            Profile user = null;
            foreach (var item in investments)
            {
                var temp = investments.Where(x => x.MemberId == item.MemberId).ToList().Sum(x => x.Amount);
                if (temp > highest)
                {
                    highest = temp;
                    user = new Profile
                    {
                       MemberId = item.MemberId,
                       FirstName = item.MemberName
                    };
                }
            }

            return user;
        }

        private List<KeyValuePair<string, decimal>> AnnualMonthlyPaidUser(List<MemberDues> dues, int year, List<UserAccount> members)
        {
            var months = new List<KeyValuePair<string, decimal>>();
            var yearMonths = GetMonths(year);
            
            foreach (var mon in yearMonths)
            {
                var count = dues.FindAll(due => due.DuesYear == year && due.DuesMonth == mon && members.Exists(m => m.AccountId == due.MemberId)).Count;
                months.Add(new KeyValuePair<string, decimal>(mon, count));
            }

            return months;

        }

        private List<KeyValuePair<string, decimal>> AnnualDues(List<MemberDues> dues, int year, List<UserAccount> members)
        {
            var months = new List<KeyValuePair<string, decimal>>();

            for (var i = 1; i <= 12; i++)
            {
                var month = new DateTime(year, i, 1).ToString("MMM");

                var dateAmount = dues.Where(due => due.DuesYear == year && due.DuesMonth == month && members.Exists(m => due.MemberId == m.AccountId)).Sum(due => due.Amount);
                months.Add(new KeyValuePair<string, decimal>(month, dateAmount));
            }

            return months;
        }

        private List<string> GetMonths(int year)
        {
            var months = new List<string>();

            if (year > DateTime.Now.Year)
            {
                return months;
            }

            var isCurrentYear = DateTime.Now.Year == year;

            var curMonth = DateTime.Now.Month;
            for (var i = 1; i <= (isCurrentYear ? curMonth : 12); i++)
            {
                var d = new DateTime(year, i, 1);
                months.Add(d.ToString("MMM"));
            }

            return months;
        }
    }
}
