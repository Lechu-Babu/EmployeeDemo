using EmployeeDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployee(int id);
        Task PutEmployee(int id, Employee employee);
        Task<Employee> PostEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
        bool EmployeeExists(int id);
    }
}
