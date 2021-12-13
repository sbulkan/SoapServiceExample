using SoapServiceExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SoapServiceExample.DAL;

namespace SoapServiceExample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        EmployeeDbContext db = new EmployeeDbContext();
        public bool Add(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //Write log etc.
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var employee = db.Employees.Find(id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                //Write log etc.
                return false;
            }
        }

        public bool Edit(Employee employee)
        {
            try
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //Write log etc.
                return false;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return db.Employees.ToList();
            }
            catch (Exception)
            {
                //Write Log etc
                return null;
            }

        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                return db.Employees.Find(id);

            }
            catch (Exception)
            {
                //Write log etc.
                return null;
            }
        }
    }
}
