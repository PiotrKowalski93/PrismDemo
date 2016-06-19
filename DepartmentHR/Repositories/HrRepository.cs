using DepartmentHR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentHR.Model;
using System.Data.Entity;

namespace DepartmentHR.Repositories
{
    public class HrRepository : IHrRepository
    {
        private readonly DataContext _context;

        public HrRepository()//(DataContext context)
        {
            //_context = context;
            _context = new DataContext();
        }

        public async Task<bool> AddEmployee(Employee employee)
        {           
            _context.Employee.Add(employee);

            await _context.SaveChangesAsync();

            if(_context.Employee.Where(e => e.BusinessEntityID == employee.BusinessEntityID).Any())
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            Employee toDelete = _context.Employee.Where(e => e.BusinessEntityID == id).SingleOrDefault();

            _context.Employee.Remove(toDelete);

            await _context.SaveChangesAsync();

            if (!_context.Employee.Where(e => e.BusinessEntityID == id).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employee.ToListAsync();
        }
        
        public async Task<IEnumerable<Employee>> GetEmployeesByGender(string gender)
        {
            return await _context.Employee.Where(e => e.Gender == gender).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByJobTitle(string jobTitle)
        {
            return await _context.Employee.Where(e => e.JobTitle == jobTitle).ToListAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employee.Attach(employee);
            var entry = _context.Entry(employee);

            entry.State = EntityState.Modified;

            await _context.SaveChangesAsync();            
        }
    }
}
