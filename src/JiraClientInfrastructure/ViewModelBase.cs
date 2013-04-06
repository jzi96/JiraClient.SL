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
using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Zieschang.Net.Projects.SLJiraClient.Infrastructure
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged<T>(Expression<Func<T>> expr)
        {
            var body = expr.Body as MemberExpression;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(body.Member.Name));
        }
        protected bool ChangeProperty<T>(ref T field, T value, Expression<Func<T>> expr)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;

            //following lines are used to get the caller of the method
            //for static class
            //var body = expr.Body as MemberExpression;
            //var vmExpression = body.Expression as ConstantExpression;
            //if (vmExpression != null)
            //{
                //LambdaExpression lambda = System.Linq.Expressions.Expression.Lambda(vmExpression);
                //Delegate vmFunc = lambda.Compile();
                //object sender = vmFunc.DynamicInvoke();

            //}
            OnPropertyChanged(expr);

            
            return true;
        }

    }
}
