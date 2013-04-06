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
using System.Collections.ObjectModel;

namespace Zieschang.Net.Projects.SLJiraClient.DashboardModule.ViewModel
{
    public class DashboardViewModel : ViewModelBase, Zieschang.Net.Projects.SLJiraClient.DashboardModule.ViewModel.IDashboardViewModel
    {
        public IDashboardView View { get; private set; }

        public DashboardViewModel(IDashboardView view)
        {
            AdditionalFilterList = new ObservableCollection<FilterContainer>();
            this.View = view;
            this.View.Model = this;
        }

        private FilterContainer _MainFilter;
        public FilterContainer MainFilter
        {
            get
            {
                return _MainFilter;
            }
            set
            {
                _MainFilter = value;
                ChangeProperty(ref _MainFilter, value, () => MainFilter);
            }
        }
        private FilterContainer _SecondFilter;
        public FilterContainer SecondFilter
        {
            get
            {
                return _SecondFilter;
            }
            set
            {
                ChangeProperty(ref _SecondFilter, value, () => SecondFilter);
            }
        }
        private ObservableCollection<FilterContainer> _additionalFilter;
        public ObservableCollection<FilterContainer> AdditionalFilterList
        {
            get
            {
                return _additionalFilter;
            }
            set
            {
                ChangeProperty(ref _additionalFilter, value, ()=>AdditionalFilterList);
            }
        }
    }
}
