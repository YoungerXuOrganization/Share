using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebApiService
{
    public class VersionnControllerSelector : DefaultHttpControllerSelector
    {
        public HttpConfiguration _config;
        public VersionnControllerSelector(HttpConfiguration config)
        : base(config)
        {
            _config = config;
        }
        public override IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            Dictionary<string, HttpControllerDescriptor> dic = new Dictionary<string, HttpControllerDescriptor>();
            foreach (var ams in _config.Services.GetAssembliesResolver().GetAssemblies())
            {
                // 获取继承自 ApiControl 的非抽象类
                var controlTypes = ams.GetTypes().Where(p => !p.IsAbstract && typeof(ApiController).IsAssignableFrom(p)).ToArray();
                foreach (var ctrlType in controlTypes)
                {
                    // 从 namespace 中提取出版本号
                    var match = Regex.Match(ctrlType.Namespace,
                    @"\w+.Controller.(V\d+)", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        string verNum = match.Groups[1].Value;// 获取版本号
                        string ctrlName =
                        Regex.Match(ctrlType.Name, @"(\w+)Controller").Groups[1].Value;// 从 LoginController 中拿到 Login
                        string key = verNum + "/" + ctrlName;//Personv2 为 key
                        dic[key.ToUpper()] = new HttpControllerDescriptor(_config, ctrlName, ctrlType);
                    }
                    else
                    {
                        string ctrlName =
                        Regex.Match(ctrlType.Name, @"(\w+)Controller").Groups[1].Value;// 从 LoginController 中拿到 Login
                        string key = ctrlName;//Personv2 为 key
                        dic[key.ToUpper()] = new HttpControllerDescriptor(_config, ctrlName, ctrlType);
                    }
                }
            }
            return dic;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            // 获取所有 Controller 集合
            var controllers = GetControllerMapping();
            // 获取路由数据
            var routeData = request.GetRouteData();
            // 从 url 中获取到版本号
            string verNum =
            Regex.Match(request.RequestUri.PathAndQuery, @"api/([\w/]+)", RegexOptions.IgnoreCase).Groups[1].Value;

            if (controllers.ContainsKey(verNum.ToUpper()))// 获取 HttpControllerDescriptor
            {
                return controllers[verNum.ToUpper()];
            }
            else
            {
                return null;
                //return base.SelectController(request);
            }
        }
    }
}
