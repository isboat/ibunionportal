using Backend.Interfaces;
using Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logics
{
    public class SubscriptionLogic : ISubscriptionLogic
    {
        public List<SubscriptionViewModel> GetSubscriptions(int assocId)
        {
            return new List<SubscriptionViewModel>
            {
                new SubscriptionViewModel { AssocId = assocId, EndDate = "01/09/2017", StartDate = "sept 2015"},
                new SubscriptionViewModel { AssocId = assocId, EndDate = "01/09/2015", StartDate = "sept 2014"}
            };
        }

        public BaseResponse SubscribeAssoc(SubscribeAssocRequest data)
        {
            return new BaseResponse {Success = true};
        }
    }
}
