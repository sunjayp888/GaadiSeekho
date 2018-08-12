using System.Net;

namespace Gadi.Models
{   
    public class JsonErrorResult : JsonNetResult
    {
        public JsonErrorResult(object responseBody) : base(responseBody, HttpStatusCode.InternalServerError)
        {
        }
    }
}