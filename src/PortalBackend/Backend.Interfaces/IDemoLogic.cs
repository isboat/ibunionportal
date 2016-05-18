using Backend.ViewModels;
using Backend.ViewModels.Demo;

namespace Backend.Interfaces
{
    public interface IDemoLogic
    {
        BaseResponse RequestDemo(DemoRequest request);
    }
}
