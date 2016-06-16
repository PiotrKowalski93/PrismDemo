using DepartmentHR.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepartmentHR.Interfaces
{
    public interface IHrService
    {
        Task<IEnumerable<Employee>> GetEmployeesByJobTitle(string jobTitle);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<IEnumerable<Employee>> GetEmployeesByGender(string gender);
        Task<bool> AddEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
        Task UpdateEmployee(Employee employee);
    }
}
