using DepartmentHR.Interfaces;
using DepartmentHR.Model;
using DepartmentHR.Repositories;
using DepartmentHR.Services;
using Ninject.Modules;
using Prism.Regions;

namespace DepartmentHR
{
    class Dependencies : NinjectModule
    {
        public override void Load()
        {
            Bind<DataContext>().To<DataContext>();
            Bind<IHrRepository>().To<HrRepository>();
            Bind<IHrService>().To<HrService>();
        }
    }
}
