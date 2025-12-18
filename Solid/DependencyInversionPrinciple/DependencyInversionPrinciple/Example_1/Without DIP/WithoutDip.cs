using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Example_1.Without_DIP
{

    //    Dependency Inversion Principle(DIP) یکی از اصول SOLID است و بیان می‌کند که:
    //    "Depend on abstractions, not on concretions."
    //    (وابستگی به انتزاع‌ها باشد، نه به پیاده‌سازی‌های خاص.)
    //تعریف رسمی:
    //این اصل دو بخش دارد:
    //    ماژول‌های سطح بالا نباید به ماژول‌های سطح پایین وابسته باشند.هر دو باید به انتزاع‌ها وابسته باشند.
    //    انتزاع‌ها نباید به جزئیات وابسته باشند؛ جزئیات باید به انتزاع‌ها وابسته باشند.
    //چرا DIP مهم است؟
    //اگر کلاس‌ها مستقیماً به یکدیگر وابسته باشند، تغییر در یکی می‌تواند باعث تغییرات گسترده در سیستم شود. DIP با کاهش وابستگی‌ها و استفاده از انتزاع، کد را قابل توسعه و نگهداری‌تر می‌کند.
   
    
    //فرض کنید یک کلاس EmailService داریم که وظیفه ارسال ایمیل را بر عهده دارد.کلاس Notification از این سرویس استفاده می‌کند.
    internal class WithoutDip
    {
    }
    public class EmailService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class Notification
    {
        private EmailService _emailService;

        public Notification()
        {
            _emailService = new EmailService(); // وابستگی مستقیم به پیاده‌سازی خاص
        }

        public void Send(string message)
        {
            _emailService.SendEmail(message);
        }
    }

}
