using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApplication1.dbl
{
    public class HTMLHelper
    {
        /// <summary>
        /// 获取CooKie
        /// </summary>
        /// <param name="loginUrl"></param>
        /// <param name="postdata"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public static CookieContainer GetCooKie(string loginUrl, string postdata, HttpHeader header)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                CookieContainer cc = new CookieContainer();
                request = (HttpWebRequest)WebRequest.Create(loginUrl);
                request.Method = header.method;
                request.ContentType = header.contentType;
                byte[] postdatabyte = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = postdatabyte.Length;
                request.AllowAutoRedirect = false;
                request.CookieContainer = cc;
                request.KeepAlive = true;
                request.Host = header.host;
                request.Referer = header.referer;

                //request.Date = DateTime.Now;
                //request.Headers.Add("Upgrade-Insecure-Requests", "1");
                //request.Headers.Add("Cookie", "bid=x4IcfRm_T5k; ll=\"108296\"; _pk_ref.100001.8cb4=%5B%22%22%2C%22%22%2C1488267551%2C%22https%3A%2F%2Fwww.baidu.com%2Flink%3Furl%3Dj_A_XzKpi1jthHtOTUIWUQXX3Y_mL97c16RrnIxTjajsIlceLC03olEEO-ERCxi3%26wd%3D%26eqid%3Deb4c0e4000025fd50000000458b52923%22%5D; __utmt=1; regpop=1; ct=y; _pk_id.100001.8cb4=d890162580033b8e.1488267551.1.1488267881.1488267551.; _pk_ses.100001.8cb4=*; __utma=30149280.39037576.1488267552.1488267552.1488267552.1; __utmb=30149280.4.10.1488267552; __utmc=30149280; __utmz=30149280.1488267552.1.1.utmcsr=baidu|utmccn=(organic)|utmcmd=organic");
                //request.Headers.Add("Origin", "https://www.douban.com");
                //request.Headers.Add("Cache-Control", "max-age=0");
                //request.Headers.Add("Accept-Language", "cs,en-us;q=0.7,en;q=0.3");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate");
                //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

                //提交请求
                Stream stream;
                stream = request.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length);
                stream.Close();

                //接收响应
                response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);

                CookieCollection cook = response.Cookies;
                //Cookie字符串格式
                string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);

                return cc;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取html
        /// </summary>
        /// <param name="getUrl"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public static string GetHtml(string getUrl, CookieContainer cookieContainer, HttpHeader header)
        {
            Thread.Sleep(1000);
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(getUrl);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = header.contentType;
                httpWebRequest.ServicePoint.ConnectionLimit = header.maxTry;
                httpWebRequest.Referer = getUrl;
                httpWebRequest.Accept = header.accept;
                httpWebRequest.UserAgent = header.userAgent;
                httpWebRequest.Method = "GET";
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();
                return html;
            }
            catch (Exception e)
            {
                if (httpWebRequest != null) httpWebRequest.Abort();
                if (httpWebResponse != null) httpWebResponse.Close();
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取CookieCollection
        /// </summary>
        /// <param name="loginUrl"></param>
        /// <param name="postdata"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public static CookieCollection GetCookieCollection(string loginUrl, string postdata, HttpHeader header)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                CookieContainer cc = new CookieContainer();
                request = (HttpWebRequest)WebRequest.Create(loginUrl);
                request.Method = header.method;
                request.ContentType = header.contentType;
                byte[] postdatabyte = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = postdatabyte.Length;
                request.AllowAutoRedirect = false;
                request.CookieContainer = cc;
                request.KeepAlive = true;

                //提交请求
                Stream stream;
                stream = request.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length);
                stream.Close();

                //接收响应
                response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);

                CookieCollection cook = response.Cookies;
                //Cookie字符串格式
                string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);

                return cook;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class HttpHeader
    {
        public string contentType { get; set; }

        public string accept { get; set; }

        public string userAgent { get; set; }

        public string method { get; set; }

        public int maxTry { get; set; }

        public string referer { get; set; }

        public string host { get; set; }

        public string cookie { get; set; }
    }
}
