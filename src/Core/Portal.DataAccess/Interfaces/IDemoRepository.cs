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
    }
}
