using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Web.ViewModels;
using Portal.Web.ViewModels.Demo;

namespace Portal.Web.Interfaces
{
    public interface IDemoLogic
    {
        BaseResponse RequestDemo(DemoRequest request);
    }
}
