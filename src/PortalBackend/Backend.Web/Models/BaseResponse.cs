using System.Web;

namespace Portal.Web.Models
{
    public class BaseResponse
    {
        public string Message { get; set; }

        public BaseResponseStatus Status { get; set; }

        public HtmlString HtmlString { get; set; }
    }

    public enum BaseResponseStatus
    {
        Success,
        Failed,
        Rejected
    }
}