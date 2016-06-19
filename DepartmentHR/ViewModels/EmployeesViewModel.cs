using DepartmentHR.Interfaces;
using DepartmentHR.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DepartmentHR.ViewModels
{
    public class EmployeesViewModel : BindableBase, INotifyPropertyChanged
    {
        private readonly IHrService _hrService;

        public DelegateCommand LoadEmployeesCommand { get; set; }
        public DelegateCommand DeleteEmployeeCommand { get; set; }
        public DelegateCommand SaveEmployeeCommand { get; set; }

        public EmployeesViewModel(IHrService hrService)
        {
            _hrService = hrService;

            LoadEmployeesCommand = new DelegateCommand(LoadEmployees);
            DeleteEmployeeCommand = new DelegateCommand(DeleteEmployee);
            SaveEmployeeCommand = new DelegateCommand(SaveEmployee);
        }

        private void SaveEmployee()
        {
            Task.Run(async () =>
            {
                await _hrService.UpdateEmployee(SelectedEmployee);
                Employees = (await _hrService.GetAllEmployees()).ToList();
            });
        }

        private void DeleteEmployee()
        {
            Task.Run(async () =>
            {
                await _hrService.DeleteEmployee(SelectedEmployee.BusinessEntityID);
            });
        }

        private void LoadEmployees()
        {
            Task.Run(async () =>
           {
               Employees = (await _hrService.GetAllEmployees()).ToList();
           });
        }

        private bool _isEditEnable;
        public bool IsEditEnable
        {
            get
            {
                return _isEditEnable;
            }
            set
            {
                _isEditEnable = value;
                NotifyPropertyChanged("IsEditEnable");
            }
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

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                NotifyPropertyChanged("Employees");
                IsEditEnable = true;
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
