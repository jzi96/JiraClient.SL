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
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;

namespace Zieschang.Net.Projects.SLJiraClient
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.RootVisual = (UIElement)Shell;
        }
        protected override DependencyObject CreateShell()
        {
            return new MainPage();
        }

        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog moduleCatalog = new ModuleCatalog();

            // this is the code responsible 
            // for adding Module1 to the application
            moduleCatalog.AddModule
            (
                typeof(Zieschang.Net.Projects.SLJiraClient.DashboardModule.Module)
            );

            return moduleCatalog;
        }
    }
}
