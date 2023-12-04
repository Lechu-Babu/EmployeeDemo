using EmployeeDemo.Core.DTOs;
using EmployeeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDemo.Core.Convertors
{
    internal class DtoToModelConverter
    {
        public Employee Convert(EmployeeDto employee)
        {

            //Employee _employee = new Employee();
            //_employee.EmployeeId = employee.EmployeeId;
            //return _employee;

            return new Employee
            {
                EmployeeId = employee.EmployeeId,
                CreateDate = DateTime.Now,
                FullName = employee.FullName,
            };
        }

        public EmployeeDto Convert(Employee employee)
        {
            return new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                FullName = employee.FullName,
            };
        }

    }
}
