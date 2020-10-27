using Microsoft.Owin.Hosting;
using SignalRService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRService
{
    class Program
    {
        public static List<ClientInfo> ClientInfoList = new List<ClientInfo>();
        public static MyHub MyHub;
        static void Main(string[] args)
        {
            WebApp.Start<Startup>("http://localhost:9999");
            Console.Write("SignalRService Started!");
            Console.ReadKey();
        }
    }
}
