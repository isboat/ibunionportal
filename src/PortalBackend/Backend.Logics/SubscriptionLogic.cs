using Backend.Interfaces;
using Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.DataAccess.Interfaces;
using Portal.DataObjects;

namespace Backend.Logics
{
    public class SubscriptionLogic : ISubscriptionLogic
    {
        private readonly ISubscriptionRepository subscriptionRepository;

        public SubscriptionLogic(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        public List<SubscriptionViewModel> GetSubscriptions(int assocId)
        {
            var subs = this.subscriptionRepository.GetSubscriptions(assocId);
            return subs.Select(x => new SubscriptionViewModel
            {
                Id = x.Id,
                AssocId = x.AssocId,
                EndDate = x.EndDate,
                StartDate = x.StartDate
            }).ToList();
        }

        public BaseResponse SubscribeAssoc(SubscribeAssocRequest data)
        {
            var response = new BaseResponse();

            var result =
                this.subscriptionRepository.UpdateSubscription(new Subscription
                {
                    AssocId = data.AssocId,
                    EndDate = data.End,
                    StartDate = data.Start
                });

            response.Success = result == 1;

            if (!response.Success)
            {
                response.Message = "Error occurred";
            }

            return response;
        }
    }
}
