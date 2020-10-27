using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Dispatcher;

[assembly: OwinStartup(typeof(WebApiService.Startup))]

namespace WebApiService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            config.Services.Replace(typeof(IAssembliesResolver), new PluginsResolver());//此处是插件式开发的 配置,在此时还未实现先注释
            config.Services.Replace(typeof(IHttpControllerSelector), new VersionnControllerSelector(config));//此处是多版本管控的配置,在此时还未实现先注释
            app.UseWebApi(config);
        }
    }
}
