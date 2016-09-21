using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.DataObjects;

namespace Portal.DataAccess.Interfaces
{
    public interface ISubscriptionRepository
    {
        List<Subscription>  GetSubscriptions(int assocId);

        int UpdateSubscription(Subscription subscribe);
    }
}
