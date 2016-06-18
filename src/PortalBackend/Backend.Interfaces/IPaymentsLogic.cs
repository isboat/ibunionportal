using Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IPaymentsLogic
    {
        List<PaymentViewModel> GetPayments(int asscId);
    }
}
