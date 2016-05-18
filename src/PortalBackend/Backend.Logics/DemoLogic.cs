using Backend.Interfaces;
using Backend.ViewModels;
using Backend.ViewModels.Demo;

namespace Backend.Logics
{
    public class DemoLogic : IDemoLogic
    {
        public Backend.ViewModels.BaseResponse RequestDemo(DemoRequest request)
        {
            return new BaseResponse {Success = true};
        }
    }
}
