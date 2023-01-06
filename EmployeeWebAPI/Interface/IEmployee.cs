using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Interface
{
    public interface IEmployee
    {

        IEnumerable<Employee> GetEmployees();
     
        Employee PostEmployee(Employee employee);
        Employee PutEmployee(Employee employee);
        bool DeleteEmployee(int id);

        void Save();
        bool Id(int id);
    }
}
