using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Threading;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services;

namespace JiraClient.WebMVC.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Jira
    {
        [OperationContract]
        public string GetJiraUrl()
        {
            string url = ConfigurationManager.AppSettings["JIRA"];
            if (url!= null && url.EndsWith("/"))
                url = url.Remove(url.Length - 1);
            return url;
        }
        [OperationContract]
        public Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services.SearchResult Search(string jql, int pos, int count)
        {
            SearchResult r = null;
            ManualResetEvent wait = new ManualResetEvent(false);
            JiraRestWrapperService svc = new JiraRestWrapperService(GetJiraUrl(), new System.Net.NetworkCredential(ConfigurationManager.AppSettings["JIRA_U"], ConfigurationManager.AppSettings["JIRA_P"]));
            svc.BeginSearch(result => { r = result; wait.Set(); }, jql, pos, count);
            wait.WaitOne();
            return r;
        }
    }
}
