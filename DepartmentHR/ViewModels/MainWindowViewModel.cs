using DepartmentHR.Views;
using Microsoft.Practices.Prism.Commands;

using Microsoft.Practices.Prism.Regions;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentHR.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
           _regionManager = regionManager;
            
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string obj)
        {
            _regionManager.RequestNavigate("ContentRegion", obj);
        }
    }
}
