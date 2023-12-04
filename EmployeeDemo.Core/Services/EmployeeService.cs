using EmployeeDemo.Core.Converters;
using EmployeeDemo.Core.DTOs;
using EmployeeDemo.Core.Repositories;
using EmployeeDemo.Models;
using System.Text;

namespace EmployeeDemo.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IConverter<EmployeeDto, Employee> _employeeConverter;
        public EmployeeService(IEmployeeRepository employeeRepository, IConverter<EmployeeDto, Employee> Employeeconverter)
        {
            _employeeRepository = employeeRepository;
            _employeeConverter = Employeeconverter;
        }

        public async Task<List<EmployeeDto>> GetAllEmployee()
        {
            var result = await _employeeRepository.GetAllEmployeeAsync();
            var response = _employeeConverter.Convert(result);
            return response;
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                throw new Exception();
            }

            var result = _employeeConverter.Convert(employee);
            return result;

        }

        public async Task<EmployeeDto> PutEmployee(int id, EmployeeDto employeeDto)
        {
            var model = new Employee();
            model.FullName = employeeDto.FullName;
            model.EmployeeId = employeeDto.EmployeeId;
            //if (id == 0)
            //{
            //    throw new Exception("Id shouldn't be zero value");
            //}
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
            //var model = new Employee();
            //model.FullName = employee.FullName;
            //model.Designation = employee.Designation;

            //var converter = new DtoToModelConverter();
            //var model = converter.Convert(employee);


            var result = await _employeeRepository.PostEmployee(_employeeConverter.Convert(employee));
            var response = _employeeConverter.Convert(result);
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
