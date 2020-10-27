using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiService.Controller
{
    public class GetDataController : ApiController
    {
        public string GetData()
        {
            return "Hello Word!";
        }
    }
}
