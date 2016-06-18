using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.ViewModels;

namespace Backend.Logics
{
    public class PaymentsLogic : IPaymentsLogic
    {
        public List<PaymentViewModel> GetPayments(int asscId)
        {
            return new List<PaymentViewModel>();
        }
    }
}
