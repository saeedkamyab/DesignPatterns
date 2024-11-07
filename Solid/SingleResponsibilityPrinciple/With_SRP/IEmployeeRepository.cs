using SingleResponsibilityPrinciple.With_SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple.With_SRP
{
    public interface IEmployeeRepository
    {
        void SaveEmployee(Employee employee);
    }

}
