using System.Web.Http;

namespace SignalRService.Controller
{
    public class SayHelloController : ApiController
    {
        [HttpGet]
        public string SayHello() {
            return "Hello World!";
        }
    }
}
