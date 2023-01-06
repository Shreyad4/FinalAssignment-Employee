using EmployeeWebAPI.Data;
using EmployeeWebAPI.Interface;
using EmployeeWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Repository
{
    public class EmployeeRepository :IEmployee
    {
        private readonly EmployeeDbContext _db;


        public EmployeeRepository(EmployeeDbContext db)
        {
            _db = db;


        }

        public IEnumerable<Employee> GetEmployees()
        {
        IEnumerable<Employee> employee = _db.Employeedata
                .ToList();


        return employee;
    }


        public Employee PostEmployee(Employee employee)
        {
            _db.Employeedata.Add(employee);

            Save();
            return employee;

        }

            public Employee PutEmployee(Employee employee)
        {
            _db.Employeedata.Update(employee);

            Save();
            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _db.Employeedata.Where(u => u.EmployeeID == id).FirstOrDefault();


            _db.Employeedata.Remove(employee);
            Save();
            return true;
        }

        public bool Id(int id)
        {
            return _db.Employeedata.Any(u => u.EmployeeID == id);
        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
