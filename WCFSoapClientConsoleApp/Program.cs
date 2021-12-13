using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WCFSoapClientConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Before run this code, right click on employeeService.svc then click view in browser
            //if u dont do this program won't be run.

            //by the way employee service is code first so u must run employeeservice.svc. leftclick on
            //employeeservice.svc then run debug for create table.

            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();

            GetAllEmployee(client);
            AddEmployee(client);
            DeleteEmployee(client);
            //etc

        }

        private static bool DeleteEmployee(EmployeeService.EmployeeServiceClient client)
        {
            return client.Delete(4);
        }

        private static bool AddEmployee(EmployeeService.EmployeeServiceClient client)
        {
            var employee = new EmployeeService.Employee() { Name = "Diego Lugano", Address = "Uruguay" };
            return client.Add(employee);
        }

        private static void GetAllEmployee(EmployeeService.EmployeeServiceClient client)
        {
            var employees = client.GetAllEmployees();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name + " - " + employee.Address);
            }
        }
    }
}
