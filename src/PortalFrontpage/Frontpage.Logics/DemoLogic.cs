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
            var result = this.demoRepository.SaveDemo(new Demo
            {
                AsscAddr = request.AsscAddr,
                AsscCountry = request.AsscCountry,
                AsscName = request.AsscName,
                Completed = false,
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Schedule = false,
                Telephone = request.Telephone
            });
            return new BaseResponse { Success = true, Message = "Thanks for requesting for a demo, a member of staff will get in touch with you."};
        }
    }
}
