using Backend.Interfaces;
using Backend.ViewModels;
using Backend.ViewModels.Demo;
using Portal.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Portal.DataObjects;

namespace Backend.Logics
{
    public class DemoLogic : IDemoLogic
    {
        private readonly IDemoRepository demoRepository;

        public DemoLogic(IDemoRepository demoRepository)
        {
            this.demoRepository = demoRepository;
        }

        public BaseResponse RequestDemo(DemoRequestViewModel request)
        {
            return new BaseResponse {Success = true};
        }

        public List<DemoSummaryViewMdoel> GetRequestedDemos()
        {
            var reqs = demoRepository.GetRequestedDemos();
            return CreateDemos(reqs);
        }

        public List<DemoRequestViewModel> GetCompletedDemos()
        {
            var demos = demoRepository.GetCompletedDemos();
            return new List<DemoRequestViewModel>
            {
                new DemoRequestViewModel
            {
                Id = 1,
                AsscAddr = "AsscAddr",
                AsscCountry = "d.AsscCountry",
                AsscName = "d.AsscName Completed",
                Email = "d.Email"
            }
            };
            //return demos.Select(d => new DemoRequestViewModel
            //{
            //    Id = d.Id,
            //    AsscAddr = d.AsscAddr,
            //    AsscCountry = d.AsscCountry,
            //    AsscName = d.AsscName,
            //    Email = d.Email
            //}).ToList();
        }

        public List<DemoRequestViewModel> GetScheduledDemos()
        {
            var demos = demoRepository.GetScheduledDemos();
            return new List<DemoRequestViewModel>
            {
                new DemoRequestViewModel
            {
                Id = 1,
                AsscAddr = "AsscAddr",
                AsscCountry = "d.AsscCountry",
                AsscName = "d.AsscName schedule demo",
                Email = "d.Email"
            }
            };
            //return demos.Select(d => new DemoRequestViewModel
            //{
            //    Id = d.Id,
            //    AsscAddr = d.AsscAddr,
            //    AsscCountry = d.AsscCountry,
            //    AsscName = d.AsscName,
            //    Email = d.Email
            //}).ToList();
        }

        private List<DemoSummaryViewMdoel> CreateDemos(List<DemoSummary> demoSummaries)
        {
            return demoSummaries.Select(req => new DemoSummaryViewMdoel
            {
                Id = req.Id, AsscName = req.AsscName, Telephone = req.Telephone
            }).ToList();
        }
    }
}
