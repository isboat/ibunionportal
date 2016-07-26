using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontpage.Interfaces;
using Frontpage.ViewModels;
using Frontpage.ViewModels.Demo;
using Portal.DataAccess.Interfaces;
using Portal.DataObjects;

namespace Frontpage.Logics
{
    public class DemoLogic : IDemoLogic
    {
        private readonly IDemoRepository demoRepository;

        public DemoLogic(IDemoRepository demoRepository)
        {
            this.demoRepository = demoRepository;
        }

        public BaseResponse RequestDemo(DemoRequest request)
        {
            var result = this.demoRepository.SaveDemo(new Demo());
            return new BaseResponse { Success = true };
        }
    }
}
