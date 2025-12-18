using DependencyInversionPrinciple.Example_1.Without_DIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Example_1.With_DIP
{
//    رعایت DIP - طراحی صحیح:

//برای رعایت DIP، می‌توانیم از یک انتزاع(Interface) استفاده کنیم.ابتدا یک واسط تعریف می‌کنیم و سپس کلاس‌های مختلف (مانند EmailService و SMSService) آن را پیاده‌سازی می‌کنند.


    internal class WithDip
    {

        public void use()
        {
            //    استفاده:

            //در اینجا، ماژول سطح بالا(Notification) به یک واسط وابسته است، نه به پیاده‌سازی خاص.بنابراین می‌توانیم به راحتی نوع سرویس را تغییر دهیم:


            // ارسال ایمیل
            IMessageService emailService = new EmailService();
            Notification emailNotification = new Notification(emailService);
            emailNotification.Send("Hello via Email!");

            // ارسال SMS
            IMessageService smsService = new SMSService();
            Notification smsNotification = new Notification(smsService);
            smsNotification.Send("Hello via SMS!");

            //مزایای طراحی جدید:
            //    کاهش وابستگی‌ها: کلاس Notification دیگر به پیاده‌سازی خاصی وابسته نیست.
            //    افزایش انعطاف‌پذیری: افزودن انواع جدید سرویس‌ها (مانند پیامک، پوش نوتیفیکیشن، و غیره) نیازی به تغییر کد کلاس Notification ندارد.
            //    تست‌پذیری بالا: به راحتی می‌توان از واسط‌ها برای ساخت Mock و تست استفاده کرد.
            //جمع‌بندی:

            //Dependency Inversion Principle یکی از اصول مهم در طراحی سیستم‌های نرم‌افزاری است که وابستگی کلاس‌ها را به انتزاع‌ها محدود می‌کند و امکان توسعه، نگهداری و تست آسان‌تر را فراهم می‌سازد.

        }

    }
    // واسط
    public interface IMessageService
    {
        void SendMessage(string message);
    }

    // پیاده‌سازی ایمیل
    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    // پیاده‌سازی SMS
    public class SMSService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    // کلاس Notification که به انتزاع وابسته است
    public class Notification
    {
        private readonly IMessageService _messageService;

        public Notification(IMessageService messageService)
        {
            _messageService = messageService; // وابستگی به انتزاع
        }

        public void Send(string message)
        {
            _messageService.SendMessage(message);
        }
    }

}
