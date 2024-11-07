using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed_Principle.Violating_OCP
{
    public class PaymentProcessor
    {
        public bool ProcessPayment(PaymentContext paymentContext)
        {
            switch (paymentContext.BankAccount.Bank)
            {
                case Bank.BankA:
                    return ProcessBankAPayment(paymentContext);

                case Bank.BankB:
                    return ProcessBankBPayment(paymentContext);

                default:
                    throw new ArgumentException("Unsupported bank");
            }
        }

        private bool ProcessBankAPayment(PaymentContext paymentContext)
        {
            // Complex logic for BankA payments
            return true;
        }

        private bool ProcessBankBPayment(PaymentContext paymentContext)
        {
            // Complex logic for BankB payments
            return false;
        }
    }

}
