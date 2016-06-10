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

        public DemoRequestViewModel GetDemo(int id)
        {
            var demo = demoRepository.GetDemo(id);

            return demo == null
                ? null
                : new DemoRequestViewModel
                {
                    Id = demo.Id,
                    AsscName = demo.AsscName,
                    AsscAddr = demo.AsscAddr,
                    AsscCountry = demo.AsscCountry,
                    Completed = demo.Completed,
                    CompletionDate = demo.CompletionDate,
                    Email = demo.Email,
                    Firstname = demo.Firstname,
                    Lastname = demo.Lastname,
                    Schedule = demo.Schedule,
                    ScheduleDate = demo.ScheduleDate,
                    Telephone = demo.Telephone
                };
        }

        public BaseResponse SaveDemo(DemoRequestViewModel data)
        {
            var result = demoRepository.SaveDemo(new Demo
            {
                Id = data.Id,
                AsscAddr = data.AsscAddr,
                AsscCountry = data.AsscCountry,
                AsscName = data.AsscName,
                Completed = data.Completed,
                CompletionDate = data.CompletionDate,
                Email = data.Email,
                Firstname = data.Firstname,
                Lastname = data.Lastname,
                Schedule = data.Schedule,
                ScheduleDate = data.ScheduleDate,
                Telephone = data.Telephone
            });

            return result == 1
                ? new BaseResponse {Success = true}
                : new BaseResponse();
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
