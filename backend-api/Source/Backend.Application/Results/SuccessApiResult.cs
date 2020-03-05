using System.Net;

namespace Backend.Application.Results
{
    public class SuccessApiResult : AbstractApiResult
    {
        public SuccessApiResult(HttpStatusCode code, object data)
        {
            Code = code;
            Status = Success;
            Data = data;
        }
    }
}
