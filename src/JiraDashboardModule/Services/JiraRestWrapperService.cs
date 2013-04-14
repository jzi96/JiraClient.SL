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

#if(SILVERLIGHT)
using System.Windows.Browser;
#else
using System.Web;
#endif
namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <para>If you need to view messages exchanged with the JIRA server, use a web debugger like <a href="www.fiddler.com">Fiddler</a>.</para></remarks>
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
            string call = PrepareRequestUrl(searchUrlPattern, new string[]{jql, pos.ToString(), count.ToString()});
#if(SILVERLIGHT)
            bool httpResult = WebRequest.RegisterPrefix("http://", System.Net.Browser.WebRequestCreator.ClientHttp);
#endif
            WebRequest request = WebRequest.Create(call);
            request.ContentType = "application/json;charset=UTF-8";
            request.ContentLength = 0;
#if(SILVERLIGHT)

#else
            //not supported by silverlight
            request.Headers.Add("Authorization", " Basic " + Convert.ToBase64String(
                        System.Text.Encoding.UTF8.GetBytes(
                            string.Format("{0}:{1}", _credentials.UserName, _credentials.Password))));
#endif
            var ar = request.BeginGetResponse(new AsyncCallback(ReceivingWebResponse), new object[]{request,result});
        }
        private void ReceivingWebResponse(IAsyncResult ar)
        {
            var response = ((WebRequest)((object[])ar.AsyncState)[0]).EndGetResponse(ar);
            var stream = response.GetResponseStream();
            System.Runtime.Serialization.Json.DataContractJsonSerializer s = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(SearchResult));
            var res = (SearchResult)s.ReadObject(stream);
            var callback = (Action<SearchResult>)((object[])ar.AsyncState)[1];
            callback(res);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="issueid">Could be key or Id of the issue</param>
        /// <param name="timeSpentValue"></param>
        public void UpdateWorkLog(Action<string> result, string issueid, string timeSpentValue)
        {
            const string searchUrlPattern = "/rest/api/2/issue/{0}/worklog";
            string[] urlArguments = new string[1];
            urlArguments[0] = issueid;
            string call = PrepareRequestUrl(searchUrlPattern, urlArguments);
            //Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services.WorkLogChange updateTimeCall = new WorkLogChange();
            //updateTimeCall.update = new WorkLogUpdate();
            //updateTimeCall.update.worklog = new Worklog[]{new Worklog()};
            var upd = new WorkLogAdd() { timeSpent = timeSpentValue };
            //updateTimeCall.update.worklog[0].add = upd;
            var request = PrepareRequest(call, upd);
            var ar = request.BeginGetResponse(new AsyncCallback(ReceivingUpdateworlLogWebResponse), new object[] { request, result });
        }
        private void ReceivingUpdateworlLogWebResponse(IAsyncResult ar)
        {
            var response = ((WebRequest)((object[])ar.AsyncState)[0]).EndGetResponse(ar);
            var stream = response.GetResponseStream();
            //System.Runtime.Serialization.Json.DataContractJsonSerializer s = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(SearchResult));
            //var res = (SearchResult)s.ReadObject(stream);
            using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
            {
                var res = sr.ReadToEnd();
                var callback = (Action<string>)((object[])ar.AsyncState)[1];
                callback(res);
            }
        }
        private WebRequest PrepareRequest(string url)
        {
            return PrepareRequest(url, null);
        }
        private WebRequest PrepareRequest(string url, object postdata)
        {
#if(SILVERLIGHT)
            bool httpResult = WebRequest.RegisterPrefix("http://", System.Net.Browser.WebRequestCreator.ClientHttp);
#endif
            WebRequest request = WebRequest.Create(url);
            request.ContentType = "application/json;charset=UTF-8";
#if(SILVERLIGHT)

#else
            //not supported by silverlight
            request.Headers.Add("Authorization", " Basic " + Convert.ToBase64String(
                        System.Text.Encoding.UTF8.GetBytes(
                            string.Format("{0}:{1}", _credentials.UserName, _credentials.Password))));
#endif
            if (postdata != null)
            {
                SetPostData(postdata, request);
            }
            else
            {
                request.ContentLength = 0;
            }
            return request;
        }

        private static void SetPostData(object postdata, WebRequest request)
        {
            using (System.Threading.ManualResetEvent man = new System.Threading.ManualResetEvent(false))
            {
                request.Method = "POST";
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(postdata.GetType());
                using (var mem = new System.IO.MemoryStream())
                {
                    serializer.WriteObject(mem, postdata);
                    mem.Position = 0;
                    request.ContentLength = mem.Length;
                    request.BeginGetRequestStream((s) =>
                    {
                        using (var postStream = request.EndGetRequestStream(s))
                        {
                            mem.CopyTo(postStream);
                        }
                        man.Set();
                    }, null);
                    man.WaitOne();
                }
            }
        }
        private string PrepareRequestUrl(string searchUrlPattern, string[] urlArguments)
        {
            string call = _url + searchUrlPattern;
            if (urlArguments == null || urlArguments.Length == 0)
                return call;
            for (int i = 0; i < urlArguments.Length; i++)
            {
                urlArguments[i] = HttpUtility.UrlEncode(urlArguments[i]);
            }
            call = string.Format(call, urlArguments);
            return call;
        }

    }

}
