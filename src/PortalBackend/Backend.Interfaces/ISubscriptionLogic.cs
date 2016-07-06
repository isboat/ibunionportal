using Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface ISubscriptionLogic
    {
        List<SubscriptionViewModel> GetSubscriptions(int assocId);
        BaseResponse SubscribeAssoc(SubscribeAssocRequest data);
    }
}
