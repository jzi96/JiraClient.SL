using System;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.ViewModel;
namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.Views
{
    public interface IDashboardView
    {
        IDashboardViewModel Model { get; set; }
    }
}
