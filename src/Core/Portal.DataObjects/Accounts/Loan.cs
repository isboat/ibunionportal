using System;

namespace Portal.DataObjects.Accounts
{
    public class Loan : PendingLoan
    {
        public int LoanId { get; set; }

        public DateTime AddedDate { get; set; }

        public string AddedBy { get; set; }

        public int AddedById { get; set; }
    }
}
