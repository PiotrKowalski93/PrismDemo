using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

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
