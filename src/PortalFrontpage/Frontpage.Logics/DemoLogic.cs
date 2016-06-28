using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontpage.Interfaces;
using Frontpage.ViewModels;
using Frontpage.ViewModels.Demo;

namespace Frontpage.Logics
{
    public class DemoLogic : IDemoLogic
    {
        public BaseResponse RequestDemo(DemoRequest request)
        {
            return new BaseResponse { Success = true };
        }
    }
}
