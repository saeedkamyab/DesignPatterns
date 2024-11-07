using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple.With_SRP
{
    // Original Employee class violating SRP
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        private readonly IEmployeeRepository _repository;
        private readonly INotificationService _notificationService;

        public Employee(IEmployeeRepository repository, INotificationService notificationService)
        {
            _repository = repository;
            _notificationService = notificationService;
        }

        public void UpdateEmployeeInfo(string newName, decimal newSalary)
        {
            Name = newName;
            Salary = newSalary;
            _repository.SaveEmployee(this);
            _notificationService.SendNotification("HR Department", $"Updated: {Name}'s salary to ${newSalary}");
        }
    }
}
