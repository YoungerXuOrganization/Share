using System.Web.Http;

namespace ApiV101.Controller.V101
{
    public class GetVerController : ApiController
    {
        public string GetVer()
        {
            return "This V101 Api!";
        }
    }
}
