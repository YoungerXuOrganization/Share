using System.Linq;
using System.Web.Http;

namespace SignalRService.Controller
{
    public class QRLoginController : ApiController
    {
        [HttpGet]
        public string QRLgoin(string uuid, string userInfo)
        {
            var client = Program.ClientInfoList.Where(u => u.UUID == uuid).SingleOrDefault();
            if (client != null)
            {
                Program.MyHub.SendUserInfo(client.ConnectionId, userInfo);
                Program.ClientInfoList.Remove(client);

                return "登录成功,登录结果:" + userInfo;
            }
            return "登录失败,二维码已过期";
        }
    }
}
