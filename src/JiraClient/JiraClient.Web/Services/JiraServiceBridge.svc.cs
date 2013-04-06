using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Description;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services;
using System.Configuration;
using System.Threading;

namespace Zieschang.Net.Projects.SLJiraClient.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class JiraServiceBridge
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public string GetJiraUrl()
        {
            return ConfigurationManager.AppSettings["JIRA"];
        }
        [OperationContract]
        public Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services.SearchResult Search(string jql, int pos, int count)
        {
            SearchResult r = null;
            ManualResetEvent wait =new ManualResetEvent(false);
            JiraRestWrapperService svc = new JiraRestWrapperService(GetJiraUrl(), new System.Net.NetworkCredential(ConfigurationManager.AppSettings["JIRA_U"], "", ConfigurationManager.AppSettings["JIRA_P"]));
            svc.BeginSearch(result => { r = result; wait.Set(); }, jql, pos, count);
            wait.WaitOne();
            return r;
        }
        // Add more operations here and mark them with [OperationContract]
    }

}
