using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.dbl;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //HttpHeader header = new HttpHeader();
            //header.accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
            ////header.accept = "*/*";
            //header.contentType = "application/x-www-form-urlencoded";
            //header.method = "POST";
            ////header.userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            //header.userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            //header.maxTry = 300;


            //CookieCollection mycookie = HTMLHelper.GetCookieCollection("https://www.douban.com/accounts/login",
            //                   "source=index_nav&form_email=791928163%40qq.com&form_password=z123456789", header);
            ////__EVENTTARGET=btnLogin&__EVENTARGUMENT=&__VIEWSTATE=EkHCjgCKu6Pz4LjCikKuW%2FEEvatJu6%2Fo7uixsMmpK7MotDc%2FkR9I2K%2BJylTPkdk2EdQXsOck%2Fhf9t%2BJpED1M1uEEHRtj9n%2FnmoLaeBs7Lz0%3D&__VIEWSTATEGENERATOR=C2EE9ABB&__EVENTVALIDATION=R1Miao38A8tauHdJtZPQCjD%2FGAh%2FW7DREKWmflHnEK3baCw7MQwP76sL%2FuN1zfZes9wREYp7HdXX421ZFi0b7rwyAEkJs5pp%2BnmQlDKVAye8M1lSFxPTNtmomdrpebDnn%2BOWUl2IfB%2BCtCQ1Sb6Nu9D4qNQ8PQ6I6TJCttpv8TE%3D&txtUser=admin&txtPassword=admin
            ////source=index_nav&redir=https%3A%2F%2Fwww.douban.com%2F&form_email=791928163%40qq.com&form_password=z123456789&remember=on&login=%E7%99%BB%E5%BD%95
            //foreach (Cookie cookie in mycookie) //将cookie设置为浏览的cookie  
            //{

            //    InternetSetCookie(

            //         "http://" + cookie.Domain.ToString(),

            //         cookie.Name.ToString(),

            //         cookie.Value.ToString() + ";expires=Sun,22-Feb-2099 00:00:00 GMT");

            //}
            //System.Diagnostics.Process.Start("https://www.douban.com/");


            HttpHeader header = new HttpHeader();
            header.accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
            header.contentType = "application/x-www-form-urlencoded";
            header.method = "POST";
            header.userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";
            header.maxTry = 300;
            header.host = "www.douban.com";
            header.referer = "https://www.douban.com/";

            string html = HTMLHelper.GetHtml("https://www.douban.com/", HTMLHelper.GetCooKie("https://www.douban.com/accounts/login",
                "source=index_nav&form_email=791928163%40qq.com&form_password=z123456789", header), header);

            txtresult.Text = html;

            //Console.WriteLine(html);


            //Console.ReadLine();
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]

        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);


        
    }
}
