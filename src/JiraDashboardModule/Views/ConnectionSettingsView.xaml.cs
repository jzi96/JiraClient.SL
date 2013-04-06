using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.ViewModel;

namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.Views
{
    public partial class ConnectionSettingsView : UserControl, Zieschang.Net.Projects.SLJiraClient.DashboardModule.Views.IConnectionSettingsView
    {
        public ConnectionSettingsView()
        {
            InitializeComponent();
        }

        public IConnectionSettingsViewModel Model
        {
            get
            {
                return this.DataContext as IConnectionSettingsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
