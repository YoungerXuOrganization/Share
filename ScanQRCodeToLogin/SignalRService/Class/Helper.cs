using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRService.Class
{
    public static class Helper
    {
        /// <summary>
        /// 获取UUID
        /// </summary>
        /// <returns></returns>
        public static string GetUUID() {
            return Guid.NewGuid().ToString();

            //产生的UUID为 字母+数字
            //return Guid.NewGuid().ToString("N");
        }

    }
}
