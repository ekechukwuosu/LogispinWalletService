using Azure;

namespace LogispinWalletService.BL.APIResponse
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public string ResponseMessage { get; set; }
    }
}
