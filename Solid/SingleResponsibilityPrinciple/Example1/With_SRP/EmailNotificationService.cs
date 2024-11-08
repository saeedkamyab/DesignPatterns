using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple.With_SRP
{
    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            // Email sending logic
        }
    }

}
