using Microsoft.Owin.Hosting;
using System.ServiceProcess;

namespace WebApiService
{
    partial class WebApiService : ServiceBase
    {
        public WebApiService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            WebApp.Start<Startup>("http://127.0.0.1:8088");
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
        }
    }
}
