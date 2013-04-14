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
            using (ManualResetEvent wait = new ManualResetEvent(false))
            {
                JiraRestWrapperService svc = CreateJiraService();
                svc.BeginSearch(result => { r = result; wait.Set(); }, jql, pos, count);
                wait.WaitOne();
                return r;
            }
        }
        [OperationContract]
        public string UpdateWorklog(string issueId, string timespent)
        {
            string r = null;
            using (ManualResetEvent wait = new ManualResetEvent(false))
            {
                JiraRestWrapperService svc = CreateJiraService();
                svc.UpdateWorkLog(result => { r = result; wait.Set(); }, issueId, timespent);
                wait.WaitOne();
                return r;
            }
        }

        private JiraRestWrapperService CreateJiraService()
        {
            JiraRestWrapperService svc = new JiraRestWrapperService(GetJiraUrl(), new System.Net.NetworkCredential(ConfigurationManager.AppSettings["JIRA_U"], ConfigurationManager.AppSettings["JIRA_P"]));
            return svc;
        }
    }
}
