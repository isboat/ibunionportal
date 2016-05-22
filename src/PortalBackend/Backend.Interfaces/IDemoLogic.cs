using Backend.ViewModels;
using Backend.ViewModels.Demo;
using System.Collections.Generic;

namespace Backend.Interfaces
{
    public interface IDemoLogic
    {
        BaseResponse RequestDemo(DemoRequest request);
        List<DemoSummary> GetRequestedDemos();
    }
}
