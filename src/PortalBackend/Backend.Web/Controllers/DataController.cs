using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backend.Interfaces;
using Backend.ViewModels;
using Portal.Common.IoC;

namespace Backend.Web.Controllers
{
    public class DataController : ApiController
    {
        private readonly IDemoLogic demoLogic = IoC.Instance.Resolve<IDemoLogic>();

        private readonly IAssociationLogic associationLogic = IoC.Instance.Resolve<IAssociationLogic>();

        [HttpGet]
        public object Get(string dataKey)
        {
            return string.IsNullOrEmpty(dataKey) ?
                string.Empty :
                this.DataMapper(dataKey);
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

                default:
                    result = string.Empty;
                    break;
            }

            return result;
        }
    }
}
