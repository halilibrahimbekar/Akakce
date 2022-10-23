using Service.Services.Common.Enum;

namespace Service.Services.Commands.Response
{
    public class BaseResponse
    {
        public ResultStatusEnum Status { get; set; }

        public string Message { get; set; }
    }
}
