using Prism.Unity;
using System.Windows;
using Microsoft.Practices.Unity;
using DepartmentHR.Views;
using DepartmentHR.Interfaces;
using DepartmentHR.Services;
using DepartmentHR.Repositories;
using DepartmentHR.Model;

namespace DepartmentHR
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
                        
            Container.RegisterType(typeof(IHrRepository), typeof(HrRepository));
            Container.RegisterType(typeof(IHrService), typeof(HrService));
            Container.RegisterType(typeof(DataContext), typeof(DataContext));
            Container.RegisterType(typeof(object), typeof(EmployeesView), "Employee");
            //Container.RegisterTypeForNavigation<EmployeesView>("Employee");            
        }        
    }

    public static class UnityExtensions
    {
        public static void RegisterTypeForNavigation<T>(this IUnityContainer container, string name)
        {
            container.RegisterType(typeof(object), typeof(T), name);
        }
    }
}
