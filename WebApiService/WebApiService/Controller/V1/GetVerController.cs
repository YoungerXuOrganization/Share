using System.Web.Http;

namespace WebApiService.Controller.V1
{
    public class GetVerController : ApiController
    {
        public string GetVer()
        {
            return "This V1 Api!";
        }
    }
}
