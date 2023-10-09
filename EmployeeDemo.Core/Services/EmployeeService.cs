using EmployeeDemo.Core.DTOs;
using EmployeeDemo.Core.Repositories;
using EmployeeDemo.Models;
using Microsoft.AspNetCore.Http.HttpResults;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDto>> GetAllEmployee()
        {
            var result = await _employeeRepository.GetAllEmployee();
            var response = new List<EmployeeDto>();
            result?.ForEach(_employee =>
            {
                response.Add(new EmployeeDto
                {
                    FullName = _employee.FullName,
                    EmployeeId = _employee.EmployeeId
                });
            });

            return response;
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                throw new Exception();
            }

            var result = new EmployeeDto();
            result.FullName = employee.FullName;
            result.EmployeeId = employee.EmployeeId;

            return result;

        }

        public async Task<EmployeeDto> PutEmployee(int id, EmployeeDto employeeDto)
        {
            var model = new Employee();
            model.FullName = employeeDto.FullName;
            model.EmployeeId = employeeDto.EmployeeId;
            if (id == 0)
            {
                throw new Exception("Is shouldn't be zero value");
            }
            if (!_employeeRepository.EmployeeExists(id))
            {
                throw new Exception("not exist");
            }

            await _employeeRepository.PutEmployee(id, model);
            return employeeDto;
        }

        public async Task<EmployeeDto> PostEmployee(EmployeeDto employee)
        {
            if (employee == null)
            {
                throw new Exception();
            }
            var model = new Employee();
            model.FullName = employee.FullName;
            model.Designation = employee.Designation;
            var result = await _employeeRepository.PostEmployee(model);
            var response = new EmployeeDto();
            response.FullName = result.FullName;
            response.EmployeeId = result.EmployeeId;
            return response;            
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                throw new Exception();
            }
            await _employeeRepository.DeleteEmployee(employee);
        }
    }
}
