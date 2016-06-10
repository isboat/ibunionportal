using Portal.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DataAccess.Interfaces
{
    public interface IDemoRepository
    {
        List<DemoSummary> GetRequestedDemos();

        List<Demo> GetCompletedDemos();
        List<Demo> GetScheduledDemos();
        Demo GetDemo(int id);
        int SaveDemo(Demo demo);
    }
}
