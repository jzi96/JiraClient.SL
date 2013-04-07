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


        public ActionResult UserOpenJiraIssues(string username, int numResults)
        {
            Services.Jira jira = new Services.Jira();
            return Json(jira.Search("status!='Closed' AND status!='Resolved' AND assignee='" + username + "' ORDER BY PRIORITY", 0, numResults), JsonRequestBehavior.AllowGet);
        }
    }
}
