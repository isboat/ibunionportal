using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Web.Interfaces;
using Portal.Web.ViewModels;
using Portal.Web.ViewModels.Demo;

namespace Portal.Web.Logics
{
    public class DemoLogic : IDemoLogic
    {
        public BaseResponse RequestDemo(DemoRequest request)
        {
            return new BaseResponse {Success = true};
        }
    }
}
