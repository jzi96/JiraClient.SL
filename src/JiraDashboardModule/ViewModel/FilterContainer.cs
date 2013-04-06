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
using Zieschang.Net.Projects.SLJiraClient.DashboardModule.Views;
using System.ComponentModel;
using System.Linq.Expressions;
using Zieschang.Net.Projects.SLJiraClient.Infrastructure;

namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.ViewModel
{
    public class FilterContainer : ViewModelBase
    {
        private string _FilterHeading;
        public string FilterHeading
        {
            get
            {
                return _FilterHeading;
            }
            set
            {
                ChangeProperty(ref _FilterHeading, value, () => FilterHeading);
            }
        }
        private string _jqlExpression;
        public string JqlExpression
        {
            get
            {
                return _jqlExpression;
            }
            set
            {
                ChangeProperty(ref _jqlExpression, value, () => JqlExpression);
            }
        }
    }
}
