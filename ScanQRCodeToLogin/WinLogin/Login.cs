using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLogin
{
    public partial class Login : Form
    {
        HubConnection connection;
        IHubProxy hub;
        string url = "http://localhost:9999";
        //Safe
        //private delegate void SafeCallDelegate(TextBox textBoxControl, string text);

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //控件跨线程安全验证设置为false，不然无法对控件进行赋值。
            //微软官方说明 https://docs.microsoft.com/zh-cn/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls?f1url=%3FappId%3DDev14IDEF1%26l%3DZH-CN%26k%3Dk(EHInvalidOperation.WinForms.IllegalCrossThreadCall);k(TargetFrameworkMoniker-.NETFramework,Version%253Dv4.5.2);k(DevLang-csharp)%26rd%3Dtrue&view=netframeworkdesktop-4.8
            //我尝试用安全的方式去对控件进行赋值，但是失败了。所有注释为Safe的代码都是微软建议的写法，但是没有成功
            //如果您有更好的方式，请在评论区告诉我，谢谢！
            Control.CheckForIllegalCrossThreadCalls = false;

            connection = new HubConnection(url);
            //类名必须与服务端一致
            hub = connection.CreateHubProxy("MyHub");

            //方法名必须与服务端一致
            hub.On<string>("GetUUID", getUUID);

            hub.On<string>("GetUserInfo", getUserInfo);

            connection.Start().Wait();

            hub.Invoke("Register").Wait();
        }

        private void getUUID(string message)
        {
            this.txtUUID.Text = message;
            //Safe
            //WriteTextSafe(txtUUID, message);
        }
        private void getUserInfo(string message)
        {
            this.txtUserInfo.Text = message;
            //Safe
            //WriteTextSafe(txtUserInfo, message);
        }

        //Safe
        //private void WriteTextSafe(TextBox textBoxControl, string text)
        //{
        //    if (textBoxControl.InvokeRequired)
        //    {
        //        var d = new SafeCallDelegate(WriteTextSafe);
        //        textBoxControl.Invoke(d, new object[] { text });
        //    }
        //    else
        //    {
        //        textBoxControl.Text = text;
        //    }
        //}
    }
}
