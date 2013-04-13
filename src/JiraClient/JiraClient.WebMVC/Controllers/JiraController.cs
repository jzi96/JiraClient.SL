using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services;
using JiraClient.WebMVC.Models;

namespace JiraClient.WebMVC.Controllers
{
    public class JiraController : Controller
    {
        private readonly Services.Jira _Jira = new Services.Jira();
        readonly JiraPagePropertiesModel _model;
        public JiraController()
        {
            _model = new JiraPagePropertiesModel();
            _model.JiraUrl = _Jira.GetJiraUrl();
        }
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Dashboard");
        }
        public ActionResult Dashboard()
        {
            return View(_model);
        }
        public ActionResult Personal()
        {
            return View(_model);
        }


        public ActionResult UserOpenJiraIssues(string username, int numResults)
        {
            return Json(_Jira.Search("status!='Closed' AND status!='Resolved' AND assignee='" + username + "' ORDER BY PRIORITY, UPDATED DESC", 0, numResults), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RecentChanges(string project, int numResults)
        {
            string projectFilter = GetProjectFilter(project);
            return Json(_Jira.Search("ORDER BY UPDATED", 0, numResults), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListActiveHighIssues(string project, int numResults)
        {
            string projectFilter = GetProjectFilter(project);
            if(!string.IsNullOrEmpty(projectFilter))
                projectFilter +=" AND ";
            return Json(_Jira.Search(projectFilter + "status!='Closed' AND priority > 2 ORDER BY UPDATED", 0, numResults), JsonRequestBehavior.AllowGet);
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
