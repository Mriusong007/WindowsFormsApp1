using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ChromiumWebBrowser webview;
        private void Form1_Load(object sender, EventArgs e)
        {



       
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="obj2"></param>
        //发送http
        private void Re_msg2(string obj, object obj2)
        {
          
        }
        string pass_ticket = String.Empty;
        private void Re_msg(string obj)
        {
        }





        /// <summary>
        /// 判断页面加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrameEndFunc(object sender, FrameLoadEndEventArgs e)
        {
           // MessageBox.Show("加载完毕");
            this.BeginInvoke(new Action(() => {
                String html = webview.GetSourceAsync().Result;
            }));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ddd=webview.GetCookieManager().VisitAllCookiesAsync().Result;
            var d= Cef.GetGlobalCookieManager().VisitAllCookiesAsync().Result;
            string cookie = "";
            foreach (var item in ddd)
            {
                cookie += item.Name + "=" + item.Value + ";";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var d = webview.GetBrowser().MainFrame;
            var dc = webview.GetBrowser().MainFrame.Browser;
            //   webview.TryGetBrowserCoreById
            String html = webview.GetSourceAsync().Result;

            var dddddd = this.webview.GetBrowser().GetFrameIdentifiers();
            //获取html
            string htmsls = webview.GetSourceAsync().Result;

            IFrame frame = webview.GetBrowser().GetFrame(dddddd[1]);
            //获取html
            string framehtml = frame.GetSourceAsync().Result;
            var d1 = frame.
            EvaluateScriptAsync("document.getElementById('loginname').value='17830767'").Result;

            var d2 = frame.
         EvaluateScriptAsync("document.getElementById('nloginpwd').value='1413Nm'").Result;

            var d3 = frame.
 EvaluateScriptAsync("document.getElementById('paipaiLoginSubmit').click()").Result;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String html = webview.GetSourceAsync().Result;
           
        }

        private void chromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //var data=webview.EvaluateScriptAsync("document.getElementById('loginname').value='17830830767'").Result;
          

            var html = webview.GetBrowser().EvaluateScriptAsync
                (" document.getElementsByTagName('div')[0].innerHTML;").Result;
            var task01 = webview.GetBrowser().GetFrame(webview.GetBrowser().GetFrameNames()[0]).
                EvaluateScriptAsync(" document.getElementsByTagName('div')[0].innerHTML;").Result;

            //
            JavascriptResponse task = webview.EvaluateScriptAsync(
              "document.getElementById('el-id-2588-4').value='1413Nm'").Result;
            //getElementsByClassName
            //getElementsByTagName
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var settings = new CefSettings();// html

            settings.CachePath = "cache";//.net

            settings.CefCommandLineArgs.Add("proxy-server","127.0.0.1:8080");// 代理

            Cef.Initialize(settings); //co
        }

        private void button7_Click(object sender, EventArgs e)
        {
            webview.ShowDevTools();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count == 8)
            {//移除之前打开的
                panel1.Controls.RemoveAt(7);
            }
            //  chromiumHostControl1.LoadUrlAsync("");
            //webview = new ChromiumWebBrowser("https://union.jd.com/index");

            new TestImageFilter();
       //监控请求数据
       
              webview = new ChromiumWebBrowser("http://v8.youlingsha.com/index.html#/dashboard");
            //  webview = new ChromiumWebBrowser("https://www.codebye.com/cefsharp-delete-cookies-async-method.html");
            webview.Dock = DockStyle.Fill;
            webview.RequestHandler = new request();

            //载入view
            panel1.Controls.Add(webview);
            //判断页面加载完成
            webview.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>(FrameEndFunc);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (webview != null)
            {
                webview.Dispose();
            }
        }
    }
}
