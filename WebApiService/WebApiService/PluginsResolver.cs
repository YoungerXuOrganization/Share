using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Web.Http.Dispatcher;

namespace WebApiService
{
    public class PluginsResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            //动态加载dll中的Controller，类似于插件服务，在WebApiConifg中添加配置
            // config.Services.Replace(typeof(IAssembliesResolver), new PluginsResolver());

            List<Assembly> assemblies = new List<Assembly>(base.GetAssemblies());
            string directoryPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "ModuleApi");

            foreach (var fileName in Directory.GetFiles(directoryPath).Where(r => Path.GetExtension(r) == ".dll"))
            {
                try
                {
                    assemblies.Add(Assembly.LoadFrom(Path.Combine(directoryPath, fileName)));
                }
                catch
                {

                }
            }
            return assemblies;
        }
    }
}
