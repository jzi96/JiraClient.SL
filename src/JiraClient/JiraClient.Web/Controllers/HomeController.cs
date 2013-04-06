using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using Zieschang.Net.Projects.SLJiraClient.Web.Services;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Zieschang.Net.Projects.SLJiraClient.Web.Controllers;
using System.Net;
using System.Runtime.Serialization.Json;

namespace JiraClient.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {


            return View();
        }

    }
}