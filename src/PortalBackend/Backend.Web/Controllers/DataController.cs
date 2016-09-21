using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Backend.Interfaces;
using Backend.ViewModels;
using Backend.ViewModels.Demo;
using Portal.Common.IoC;

namespace Backend.Web.Controllers
{
    public class DataController : ApiController
    {
        private readonly IDemoLogic demoLogic = IoC.Instance.Resolve<IDemoLogic>();
        private readonly IAssociationLogic associationLogic = IoC.Instance.Resolve<IAssociationLogic>();
        private readonly ISubscriptionLogic subscriptionLogic = IoC.Instance.Resolve<ISubscriptionLogic>();
        private readonly IPaymentsLogic paymentsLogic = IoC.Instance.Resolve<IPaymentsLogic>();

        public DataController(){}

        [HttpGet]
        public object Get(string dataKey)
        {
            return string.IsNullOrEmpty(dataKey) ?
                string.Empty :
                this.DataMapper(dataKey);
        }

        [HttpPost]
        public BaseResponse SaveDemo(DemoRequestViewModel data)
        {
            return data == null ? new BaseResponse() : this.demoLogic.SaveDemo(data);
        }

        [HttpPost]
        public BaseResponse SaveAssociation(AssociationViewModel data)
        {
            return data == null ? new BaseResponse() : this.associationLogic.SaveAssociation(data);
        }

        [HttpPost]
        public BaseResponse AddPayment(AddPaymentRequest data)
        {
            return data == null ? new BaseResponse() : this.paymentsLogic.AddPayment(data);
        }

        [HttpPost]
        public BaseResponse SubscribeAssoc(SubscribeAssocRequest data)
        {
            return data == null ? new BaseResponse() : this.subscriptionLogic.SubscribeAssoc(data);
        }

        private object DataMapper(string dataKey)
        {
            var segments = dataKey.Split('|');

            var result = new object();

            switch (segments[0])
            {
                case "summary":
                    result = new SummaryViewModel
                    {
                        DemoRequests = demoLogic.GetRequestedDemos(),
                        AssociationCount = associationLogic.GetAllAssociations().Count
                    };
                    break;

                case "allassc":
                    result = associationLogic.GetAllAssociations();
                    break;

                case "assoc":
                    result = associationLogic.GetAssociation(Convert.ToInt32(segments[1]));
                    break;

                case "demos":
                    result = new
                    {
                        Completed = demoLogic.GetCompletedDemos(),
                        Scheduled = demoLogic.GetScheduledDemos(),
                        Requested = demoLogic.GetRequestedDemos()
                    };
                    break;

                case "demo":
                    result = demoLogic.GetDemo(Convert.ToInt32(segments[1]));
                    break;

                case "payments":
                    result = new
                    {
                        Payments = paymentsLogic.GetPayments(Convert.ToInt32(segments[1]))
                    };
                    break;

                case "subscription":
                    result = new
                    {
                        Subscriptions = subscriptionLogic.GetSubscriptions(Convert.ToInt32(segments[1]))
                    };
                    break;

                default:
                    result = string.Empty;
                    break;
            }

            return result;
        }
    }
}
