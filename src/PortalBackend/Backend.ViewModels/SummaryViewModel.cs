using Backend.ViewModels.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class SummaryViewModel
    {
        public int AssociationCount { get; set; }

        public List<DemoSummaryViewMdoel> DemoRequests { get; set; }
    }
}
