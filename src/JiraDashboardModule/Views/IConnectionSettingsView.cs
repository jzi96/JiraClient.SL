using System;
namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.Views
{
    public interface IConnectionSettingsView
    {
        Zieschang.Net.Projects.SLJiraClient.DashboardModule.ViewModel.IConnectionSettingsViewModel Model { get; set; }
    }
}
