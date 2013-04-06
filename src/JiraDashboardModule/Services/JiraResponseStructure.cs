using System;
using System.Net;
using System.Collections.Generic;

namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.Services
{
    public class Progress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class Issuetype
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
    }

    public class Votes
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }

    public class AvatarUrls
    {
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__48x48 { get; set; }
    }

    public class Reporter
    {
        public string self { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
    }

    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Watches
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class AvatarUrls2
    {
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__48x48 { get; set; }
    }

    public class Assignee
    {
        public string self { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls2 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
    }

    public class AvatarUrls3
    {
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__48x48 { get; set; }
    }

    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public AvatarUrls3 avatarUrls { get; set; }
    }

    public class Aggregateprogress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class Fields
    {
        public string summary { get; set; }
        public Progress progress { get; set; }
        public Issuetype issuetype { get; set; }
        public Votes votes { get; set; }
        public object resolution { get; set; }
        public List<object> fixVersions { get; set; }
        public object resolutiondate { get; set; }
        public object timespent { get; set; }
        public Reporter reporter { get; set; }
        public object aggregatetimeoriginalestimate { get; set; }
        public string updated { get; set; }
        public string created { get; set; }
        public string description { get; set; }
        public Priority priority { get; set; }
        public object duedate { get; set; }
        public List<object> issuelinks { get; set; }
        public Watches watches { get; set; }
        public List<object> subtasks { get; set; }
        public Status status { get; set; }
        public List<object> labels { get; set; }
        public Assignee assignee { get; set; }
        public int workratio { get; set; }
        public object aggregatetimeestimate { get; set; }
        public Project project { get; set; }
        public List<object> versions { get; set; }
        public object environment { get; set; }
        public object timeestimate { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public object lastViewed { get; set; }
        public List<object> components { get; set; }
        public object timeoriginalestimate { get; set; }
        public object aggregatetimespent { get; set; }
    }

    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }

    public class SearchResult
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }
    }
}
