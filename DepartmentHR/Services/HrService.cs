using DepartmentHR.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepartmentHR.Model;

namespace DepartmentHR.Services
{
    public class HrService : IHrService
    {
        private readonly IHrRepository _repository;

        public HrService(IHrRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            return await _repository.AddEmployee(employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _repository.DeleteEmployee(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _repository.GetAllEmployees();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByGender(string gender)
        {
            return await _repository.GetEmployeesByGender(gender);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByJobTitle(string jobTitle)
        {
            return await _repository.GetEmployeesByJobTitle(jobTitle);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _repository.UpdateEmployee(employee);
        }
    }
}
