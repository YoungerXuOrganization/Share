using System.Web.Http;

namespace WebApiService.Controller.V2
{
    public class GetVerController : ApiController
    {
        public string GetVer()
        {
            return "This V2 Api!";
        }
    }
}
