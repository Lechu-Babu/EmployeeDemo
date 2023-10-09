using EmployeeDemo.Core.DTOs;
using EmployeeDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo.Core.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployee();
        Task<EmployeeDto> GetEmployee(int id);
        Task<EmployeeDto> PutEmployee(int id, EmployeeDto employee);
        Task<EmployeeDto> PostEmployee(EmployeeDto employee);
        Task DeleteEmployee(int id);
    }
}
