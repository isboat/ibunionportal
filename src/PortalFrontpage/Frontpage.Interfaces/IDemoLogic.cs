using Frontpage.ViewModels;
using Frontpage.ViewModels.Demo;

namespace Frontpage.Interfaces
{
    public interface IDemoLogic
    {
        BaseResponse RequestDemo(DemoRequest request);
    }
}