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
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Zieschang.Net.Projects.SLJiraClient.Infrastructure;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.ViewModel;
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.Views;

namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule
{
    public class Module : IModule
    {
        private IRegionManager _manager;
        private IUnityContainer _container;

        public Module(IRegionManager manager, IUnityContainer container)
        {
            _manager = manager;
            _container = container;
        }
        public void Initialize()
        {
            this.RegisterServices();
            this.RegisterViews();
            if(this._manager.Regions.ContainsRegionWithName(RegionNames.MainRegion))
                this._manager.Regions[RegionNames.MainRegion].Add(this._container.Resolve<IDashboardViewModel>().View);

        }

        private void RegisterViews()
        {
            this._container.RegisterType<IDashboardView, DashboardView>();
            this._container.RegisterType<IDashboardViewModel, DashboardViewModel>();

            this._container.RegisterType<IConnectionSettingsView, ConnectionSettingsView>();
            this._container.RegisterType<IConnectionSettingsViewModel, ConnectionSettingsViewModel>();
        }

        private void RegisterServices()
        {
        }
    }
}
