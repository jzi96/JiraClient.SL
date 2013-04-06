using System;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.Views;
namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.ViewModel
{
    public interface IDashboardViewModel
    {
        IDashboardView View { get; }
    }
}
