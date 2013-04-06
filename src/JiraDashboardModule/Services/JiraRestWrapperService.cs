using System;
using System.Net;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Documents;
//using System.Windows.Ink;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Animation;
//using System.Windows.Shapes;
using System.ServiceModel;

#if(SILVERLIGHT)
using System.Windows.Browser;
#else
using System.Web;
#endif
namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services
{
    public class JiraRestWrapperService
    {
        private readonly NetworkCredential _credentials;
        private readonly string _url;
        public JiraRestWrapperService(string url)
            :this(url, null)
        {
        }
        public JiraRestWrapperService(string url, NetworkCredential credentials)
        {
            if(url.EndsWith("/"))
                url=url.Remove(url.Length-1);
            _url = url;
            _credentials = credentials;
        }
        public void BeginSearch(Action<SearchResult> result, string jql, int pos, int count)
        {
            const string searchUrlPattern = "/rest/api/2/search?jql={0}&startAt={1}&maxResults={2}";
            string call = _url + searchUrlPattern;
            call = string.Format(call, HttpUtility.UrlEncode(jql), pos, count);
            WebRequest request = WebRequest.Create(call);
            request.ContentType = "application/json;charset=UTF-8";
            request.ContentLength = 0;
            //request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(
            //            System.Text.Encoding.UTF8.GetBytes(
            //                string.Format("{0}:{1}", _credentials.UserName, _credentials.Password))));
            var ar = request.BeginGetResponse(new AsyncCallback(ReceivingWebResponse), new object[]{request,result});
        }
        private void ReceivingWebResponse(IAsyncResult ar)
        {
            var response = ((WebRequest)((object[])ar.AsyncState)[0]).EndGetResponse(ar);
            var stream = response.GetResponseStream();
            System.Runtime.Serialization.Json.DataContractJsonSerializer s = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(SearchResult));
            var res = (SearchResult)s.ReadObject(stream);
            var callback = (Action<object>)((object[])ar.AsyncState)[1];
            callback(res);
        }
    }

}
