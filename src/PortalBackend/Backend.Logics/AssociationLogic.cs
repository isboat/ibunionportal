using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.ViewModels;

namespace Backend.Logics
{
    public class AssociationLogic : IAssociationLogic
    {
        public SummaryViewModel GetSummary()
        {
            var summary = new SummaryViewModel { AssociationCount = 100};

            return summary;
        }
    }
}
