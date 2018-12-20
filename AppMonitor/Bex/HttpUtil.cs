using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AppMonitor.Bex
{
    public class HttpUtil
    {
        public static void get(string url, DownloadStringCompletedEventHandler handler)
        {
            HttpWebRequest client = (HttpWebRequest)WebRequest.Create(url);
            client.GetResponse();
        }

    }



    [Serializable]
    public class RequestInfo
    {
        public RequestInfo(string url)
        {
            Url = url;
            AllowAutoRedirect = true;
        }
        public string Url { set; get; }
        public byte[] PostData { set; get; }
        public WebHeaderCollection Headers { set; get; }
        public bool AllowAutoRedirect { set; get; }
        public Dictionary<string, string> ExternalData { set; get; }
    }

    [Serializable]
    public class ResponseInfo
    {
        public RequestInfo RequestInfo { set; get; }
        public Stream ResponseContent { set; get; }
        public HttpStatusCode StatusCode { set; get; }
        public WebHeaderCollection Headers { set; get; }
        public string GetString(Encoding coding)
        {
            StringBuilder str = new StringBuilder();
            Stream sr = ResponseContent;
            sr.Seek(0, SeekOrigin.Begin);
            byte[] data = new byte[1024 * 1024];
            int readcount = sr.Read(data, 0, data.Length);
            while (readcount > 0)
            {
                str.Append(coding.GetString(data, 0, readcount));
                readcount = sr.Read(data, 0, data.Length);
            }
            return str.ToString();
        }
    }

    internal class StateObject
    {
        public byte[] Buffer { set; get; }
        public ResponseInfo ResponseInfo { set; get; }
        public Stream ReadStream { set; get; }
        public HttpWebRequest HttpWebRequest { set; get; }
        public Action<ResponseInfo> Action { set; get; }

    }

    public class RequestHttpWebRequest
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");
        static RequestHttpWebRequest()
        {
            ServicePointManager.DefaultConnectionLimit = 100;
        }

        public RequestHttpWebRequest()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
        }

        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开  
            return true;
        }

        public void GetResponseAsync(RequestInfo info, Action<ResponseInfo> act)
        {
            HttpWebRequest webRequest;
            StateObject state;
            InitWebRequest(info, act, out webRequest, out state);
            try
            {
                webRequest.Timeout = 20 * 1000;
                if (info.PostData != null && info.PostData.Length > 0)
                {
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    webRequest.BeginGetRequestStream(EndRequest, state);
                }
                else
                {
                    webRequest.BeginGetResponse(EndResponse, state);
                }

            }
            catch (Exception ex)
            {
                HandException(ex, state);
            }
        }

        void EndRequest(IAsyncResult ar)
        {
            StateObject state = ar.AsyncState as StateObject;
            try
            {
                HttpWebRequest webRequest = state.HttpWebRequest as HttpWebRequest;
                webRequest.Timeout = 20 * 1000;
                using (Stream stream = webRequest.EndGetRequestStream(ar))
                {
                    byte[] data = state.ResponseInfo.RequestInfo.PostData;
                    stream.Write(data, 0, data.Length);
                }
                webRequest.BeginGetResponse(EndResponse, state);

            }
            catch (Exception ex)
            {
                HandException(ex, state);
            }
        }

        void EndResponse(IAsyncResult ar)
        {
            StateObject state = ar.AsyncState as StateObject;
            try
            {
                HttpWebResponse webResponse = state.HttpWebRequest.EndGetResponse(ar) as HttpWebResponse;
                state.ResponseInfo.StatusCode = webResponse.StatusCode;
                state.ResponseInfo.Headers = new WebHeaderCollection();
                foreach (string key in webResponse.Headers.AllKeys)
                {
                    state.ResponseInfo.Headers.Add(key, webResponse.Headers[key]);
                }
                state.ReadStream = webResponse.GetResponseStream();
                state.ReadStream.BeginRead(state.Buffer, 0, state.Buffer.Length, ReadCallBack, state);
            }
            catch (Exception ex)
            {
                HandException(ex, state);
            }
        }

        void ReadCallBack(IAsyncResult ar)
        {
            StateObject state = ar.AsyncState as StateObject;
            try
            {
                int read = state.ReadStream.EndRead(ar);
                if (read > 0)
                {
                    state.ResponseInfo.ResponseContent.Write(state.Buffer, 0, read);
                    state.ReadStream.BeginRead(state.Buffer, 0, state.Buffer.Length, ReadCallBack, state);
                }
                else
                {
                    state.ReadStream.Close();
                    state.HttpWebRequest.Abort();
                    if (state.Action != null)
                    {
                        state.Action(state.ResponseInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                HandException(ex, state);
            }
        }

        private void InitWebRequest(RequestInfo info, Action<ResponseInfo> act, out HttpWebRequest webRequest, out StateObject state)
        {

            webRequest = HttpWebRequest.CreateDefault(new Uri(info.Url)) as HttpWebRequest;
            webRequest.KeepAlive = true;
            webRequest.Timeout = 20 * 1000;
            webRequest.AllowAutoRedirect = info.AllowAutoRedirect;
            if (info.Headers != null && info.Headers.Count > 0)
            {
                foreach (string key in info.Headers.Keys)
                {
                    webRequest.Headers.Add(key, info.Headers[key]);
                }
            }
            //webRequest.Proxy = WebProxy.GetDefaultProxy();
            //webRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;  
            //webResponse.Headers.Get("Set-Cookie");
            state = new StateObject
            {
                Buffer = new byte[1024 * 1024],
                HttpWebRequest = webRequest,
                Action = act,
                ResponseInfo = new ResponseInfo
                {
                    RequestInfo = info,
                    ResponseContent = new MemoryStream()
                }
            };
        }

        private void HandException(Exception ex, StateObject state)
        {
            string message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : " + state.ResponseInfo.RequestInfo.Url + " : " + ex.Message;
            if (state.Action != null)
            {
                state.Action(state.ResponseInfo);
            }
            logger.Error(message);
        }
    }

}
