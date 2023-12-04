
using EmployeeDemo.Core.DTOs;
using EmployeeDemo.Models;

namespace EmployeeDemo.Core.Converters
{
    public class EmployeeConverter : BaseConverter<EmployeeDto, Employee>
    {
        public override Employee Convert(EmployeeDto source)
        {
            return new Employee
            {
                //source.EmployeeId == 0 ? 99999 :
                EmployeeId = source.EmployeeId,
                FullName = source.FullName,
                Designation = source.Designation,
                Department = source.Department
            };
        }

        public override EmployeeDto Convert(Employee source)
        {
            return new EmployeeDto
            {
                EmployeeId = source.EmployeeId,
                FullName = source.FullName,
                Designation = source.Designation,
                Department = source.Department
            };
        }
    }
}
