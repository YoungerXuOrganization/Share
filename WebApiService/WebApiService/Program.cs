using System;
using Microsoft.Owin.Hosting;
using System.ServiceProcess;
using System.Linq;

namespace WebApiService
{
    class Program
    {
        static void Main(string[] args)
        {
            //启动服务使用该段代码
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new WebApiService () //此处是我们的windows服务类名称
            //};
            //ServiceBase.Run(ServicesToRun);

            //调试使用该段代码
            WebApp.Start<Startup>("http://127.0.0.1:8088");
            Console.WriteLine("Service Started!");
            Console.Read();
        }
    }
}
