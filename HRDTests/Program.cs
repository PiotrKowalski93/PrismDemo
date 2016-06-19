using DepartmentHR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDTests
{
    class Program
    {
        static void Main(string[] args)
        {
            HrRepository repo = new HrRepository(new DepartmentHR.Model.DataContext());

            var emp = repo.GetAllEmployees().Result;

            Console.ReadKey();
        }
    }
}
