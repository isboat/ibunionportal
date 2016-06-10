using Backend.ViewModels;
using Backend.ViewModels.Demo;
using System.Collections.Generic;

namespace Backend.Interfaces
{
    public interface IDemoLogic
    {
        BaseResponse RequestDemo(DemoRequestViewModel request);

        List<DemoSummaryViewMdoel> GetRequestedDemos();

        List<DemoRequestViewModel> GetCompletedDemos();
        List<DemoRequestViewModel> GetScheduledDemos();
        DemoRequestViewModel GetDemo(int id);
        BaseResponse SaveDemo(DemoRequestViewModel data);
    }
}
