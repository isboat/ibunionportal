using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.ViewModels;
using Backend.ViewModels.Demo;

namespace Backend.Logics
{
    public class AssociationLogic : IAssociationLogic
    {
        private readonly IDemoLogic demoLogic;

        public AssociationLogic(IDemoLogic demoLogic)
        {
            this.demoLogic = demoLogic;
        }
        public SummaryViewModel GetSummary()
        {
            var summary = new SummaryViewModel 
            { 
                AssociationCount = 100,
                DemoRequests = demoLogic.GetRequestedDemos()
            };

            return summary;
        }
    }
}
