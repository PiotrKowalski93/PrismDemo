using DepartmentHR.Interfaces;
using DepartmentHR.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentHR.ViewModels
{
    public class EmployeeViewModel : BindableBase, INotifyPropertyChanged
    {
        private readonly IHrService _hrService;

        public DelegateCommand LoadEmployeesCommand { get; set; }
        
        public EmployeeViewModel(IHrService hrService)
        {
            _hrService = hrService;

            LoadEmployeesCommand = new DelegateCommand(LoadEmployees);            
        }

        private void LoadEmployees()
        {
            Task.Run(async () =>
           {
               Employees = (await _hrService.GetAllEmployees()).ToList();
           });            
        }

        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                NotifyPropertyChanged("Employees");
            }
        }

        private List<Employee> _selectedEmployee;
        public List<Employee> SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                NotifyPropertyChanged("Employees");
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
