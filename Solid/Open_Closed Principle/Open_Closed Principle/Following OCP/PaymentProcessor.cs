using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed_Principle.Following_OCP
{
    public abstract class PaymentProcessor
    {
        public abstract bool ProcessPayment(PaymentContext paymentContext);
    }
}
