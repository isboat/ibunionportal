using Backend.Interfaces;
using Backend.ViewModels;
using Backend.ViewModels.Demo;
using Portal.DataAccess.Interfaces;
using System.Collections.Generic;

namespace Backend.Logics
{
    public class DemoLogic : IDemoLogic
    {
        private readonly IDemoRepository demoRepository;

        public DemoLogic(IDemoRepository demoRepository)
        {
            this.demoRepository = demoRepository;
        }

        public Backend.ViewModels.BaseResponse RequestDemo(DemoRequest request)
        {
            return new BaseResponse {Success = true};
        }

        public List<DemoSummary> GetRequestedDemos()
        {
            var demos = new List<DemoSummary>();

            var reqs = demoRepository.GetRequestedDemos();
            foreach (var req in reqs)
            {
                demos.Add(new DemoSummary
                {
                    Id = req.Id,
                    AsscName = req.AsscName,
                    Telephone = req.Telephone
                });
            }

            return demos;
        }
    }
}
