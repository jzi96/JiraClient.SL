using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services;

namespace JiraClient.WebMVC.Controllers
{
    public class JiraController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Dashboard");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Personal()
        {
            return View();
        }


        public ActionResult UserOpenJiraIssues(string username, int numResults)
        {
            Services.Jira jira = new Services.Jira();
            return Json(jira.Search("status!='Closed' AND status!='Resolved' AND assignee='" + username + "' ORDER BY PRIORITY", 0, numResults), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RecentChanges(string project, int numResults)
        {
            Services.Jira jira = new Services.Jira();
            string projectFilter = GetProjectFilter(project);
            return Json(jira.Search("ORDER BY UPDATED", 0, numResults), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListActiveHighIssues(string project, int numResults)
        {
            Services.Jira jira = new Services.Jira();
            string projectFilter = GetProjectFilter(project);
            if(!string.IsNullOrEmpty(projectFilter))
                projectFilter +=" AND ";
            return Json(jira.Search(projectFilter+ "status!='Closed' AND priority > 2 ORDER BY UPDATED", 0, numResults), JsonRequestBehavior.AllowGet);
        }

        private static string GetProjectFilter(string project)
        {
            string projectFilter = string.Empty;
            if (!string.IsNullOrEmpty(project))
            {
                projectFilter = "(project='" + project + "') ";
            }
            return projectFilter;
        }
    }
}
