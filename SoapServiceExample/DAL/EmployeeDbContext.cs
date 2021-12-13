using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SoapServiceExample.Model;

namespace SoapServiceExample.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("EmployeeDbContext")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
    public class EmployeeDbInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            //You can do someinitialize when u create database here
            // for example
            //context.Employees.Add(new Employee() { Name = "Alex De Souza", Address = "Brazil" });
            //context.SaveChanges();
        }
    }
}