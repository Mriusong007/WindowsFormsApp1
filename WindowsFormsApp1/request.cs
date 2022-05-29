using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class request : IRequestHandler
    {

        public event Action<string> msg;
        public event Action<string, object> msg2;
        public bool GetAuthCredentials(IWebBrowser chromiumWebBrowser,
            IBrowser browser, string originUrl,
            bool isProxy, string host,
            int port, string realm, string scheme,
            IAuthCallback callback)
        {

            return false;
        }


        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {

            //if (!response.ResponseHeaders["Content-Type"].Contains("application/json"))
            //{
            //    return null;
            //}

            var filter = FilterManager.CreateFilter(request.Identifier.ToString());

            return filter;
        }
        private void Filter_VOIDFUN(string arg1, string arg2, string arg3, long arg4)
        {
            msg2?.Invoke(arg1, arg2);
        }


        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser,
            IFrame frame, IRequest request, bool userGesture, bool isRedirect)
        {

            var m = request.Method;
            msg?.Invoke(request.Url);
            msg?.Invoke(m);
            if (request.Method == "POST")
            {
                using (var postData = request.PostData)
                {
                    if (postData != null)
                    {
                        var elements = postData.Elements;

                        var charSet = request.GetCharSet();

                        foreach (var element in elements)
                        {
                            if (element.Type == PostDataElementType.Bytes)
                            {
                                var body = element.GetBody(charSet);
                                msg?.Invoke(body);
                            }
                        }
                    }
                }
            }

            return false;
        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            var m = request.Method;
            msg?.Invoke(request.Url);
            msg?.Invoke(m);
            if (request.Method == "POST")
            {
                using (var postData = request.PostData)
                {
                    if (postData != null)
                    {
                        var elements = postData.Elements;

                        var charSet = request.GetCharSet();

                        foreach (var element in elements)
                        {
                            if (element.Type == PostDataElementType.Bytes)
                            {
                                var body = element.GetBody(charSet);
                                msg?.Invoke(body);
                            }
                        }
                    }
                }
            }

            return CefReturnValue.Continue;
        }

        public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            return true;
        }

        public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return false;
        }

        public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
        {

        }

        public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
        {
            return false;
        }

        public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            return false;
        }

        public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
        {

        }

        public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
        {

        }

      

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, ref string newUrl)
        {

        }

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {

        }

      

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            return true;
        }

        void IRequestHandler.OnDocumentAvailableInMainFrame
            (IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return;
        }


        IResourceRequestHandler IRequestHandler.GetResourceRequestHandler
            (IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, 
            IRequest request, bool isNavigation, bool isDownload, 
            string requestInitiator, ref bool disableDefaultHandling)
        {
            
          
                var url = request.Url;
            Console.WriteLine(url);
            if (request.Method == "POST")
            {

                var data = request.Headers;
                Dictionary<string, string> Headers = new Dictionary<string, string>();
                foreach (var element in data)
                {
                    Headers.Add( element.ToString(), data[element.ToString()]);
                }
                
                var postData = request.PostData;
                var charSet = request.GetCharSet();
                var elements = postData.Elements;
                foreach (var element in elements)
                {
                    if (element.Type == PostDataElementType.Bytes)
                    {
                        var body = element.GetBody(charSet);
                        msg?.Invoke(body);
                    }
                }
            }
                return null;
        }

       
    }
}
