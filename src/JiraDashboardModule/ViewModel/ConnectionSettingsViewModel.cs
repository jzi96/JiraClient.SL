using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Zieschang.Net.Projects.SLJiraClient.Infrastructure;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.Views;

namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.ViewModel
{
    public class ConnectionSettingsViewModel : ViewModelBase, IConnectionSettingsViewModel
    {

        public IConnectionSettingsView View
        {
            get;
            private set;

        }

        public ConnectionSettingsViewModel(IConnectionSettingsView view)
        {
            this.View = view;
        }

        private string _JiraServerUrl;
        public string JiraServerUrl
        {
            get
            {
                return _JiraServerUrl;
            }
            set
            {
                ChangeProperty(ref _JiraServerUrl, value, () => JiraServerUrl);
            }
        }
        private string _UserName;
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                ChangeProperty(ref _UserName, value, () => UserName);
            }
        }
        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                ChangeProperty(ref _Password, value, () => Password);
                _Password = value;
            }
        }
    }

}
