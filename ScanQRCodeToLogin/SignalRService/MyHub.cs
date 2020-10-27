using Microsoft.AspNet.SignalR;
using SignalRService.Class;
using SignalRService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRService
{
    public class MyHub : Hub
    {
        /// <summary>
        /// 构造时对Program.MyHub赋值
        /// </summary>
        public MyHub()
        {
            Program.MyHub = this;
        }

        /// <summary>
        /// 实现推送扫码成功的用户信息的方法
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="userInfo"></param>
        public void SendUserInfo(string connectionId, string userInfo) {
            //调用客户端的 GetUserInfo 方法 返回用户信息
            Clients.Client(connectionId).GetUserInfo(userInfo);
        }
        

        /// <summary>
        /// 实现注册方法
        /// </summary>
        public void Register()
        {
            //获取UUID
            var UUID = Helper.GetUUID();
            //查询用户
            var client = Program.ClientInfoList.Where(u => u.ConnectionId == Context.ConnectionId).SingleOrDefault();
            if (client == null)
            {
                client = new ClientInfo()
                {
                    ConnectionId = Context.ConnectionId,
                    UUID = UUID
                };
                Program.ClientInfoList.Add(client);
            }
            else
            {
                client.UUID = UUID;
            }

            //调用客户端的 GetUUID 方法 返回UUID
            Clients.Client(Context.ConnectionId).GetUUID(Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                IsOk = "Y",
                Msg = "",
                UUID = UUID
            }));
            //Helper.Log("LoginLog" + System.DateTime.Now.ToString("yyyyMMdd"), "[Register]    " + Newtonsoft.Json.JsonConvert.SerializeObject(client));
        }

        
        /// <summary>
        /// 重写连接事件 目前没实现功能,你可以在这记日志或者干点别的事情
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            //Helper.Log("ConnectedLog" + System.DateTime.Now.ToString("yyyyMMdd"), "[Connected]    [ConnectionId:" + Context.ConnectionId + "  IP:" + Helper.GetClientIp(Context) + "]");
            return base.OnConnected();
        }

        /// <summary>
        /// 重写连接断开事件
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            //查询用户
            var client = Program.ClientInfoList.Where(u => u.ConnectionId == Context.ConnectionId).SingleOrDefault();
            //判断用户是否存在，存在则删除
            if (client != null)
            {
                //删除用户
                Program.ClientInfoList.Remove(client);
            }
            //Helper.Log("ConnectedLog" + System.DateTime.Now.ToString("yyyyMMdd"), "[Disconnected]    " + Newtonsoft.Json.JsonConvert.SerializeObject(client));

            return base.OnDisconnected(stopCalled);
        }
    }
}
