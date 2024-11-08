using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple.Without_SRP
{
    // Original Employee class violating SRP
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public void CalculateSalary()
        {
            // Complex salary calculation logic
        }

        public void SaveToDatabase()
        {
            // Database operations
        }

        public void SendEmailNotification()
        {
            // Email sending logic
        }
    }
}
