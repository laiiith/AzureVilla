using System.Net;

namespace MagicVilla_Models.API_Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMesssages { get; set; }
        public object Result { get; set; }
    }
}
