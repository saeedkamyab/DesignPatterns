using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed_Principle.example2.with
{

    /*
     بهبود طراحی (سازگار با Open/Closed Principle):

برای رعایت اصل Open/Closed، می‌توانیم از پلی‌مورفیسم و واسط‌ها استفاده کنیم و انواع تخفیف را در کلاس‌های جداگانه پیاده‌سازی کنیم.
     */
    internal class With_OCP
    {
        public void useTheOcp()
        {
            //استفاده از آن
            var regularDiscount = new DiscountCalculator(new RegularDiscount());
            var vipDiscount = new DiscountCalculator(new VipDiscount());

            decimal regularDiscountAmount = regularDiscount.Calculate(100);
            decimal vipDiscountAmount = vipDiscount.Calculate(100);

            /*با این روش، هر زمان که نیاز به اضافه کردن یک نوع تخفیف جدید باشد، بدون تغییر در کدهای موجود و تنها با اضافه کردن یک کلاس جدید، این قابلیت به سیستم اضافه می‌شود.*/
        }
    }
    // تعریف یک واسط برای تخفیف‌ها
    public interface IDiscount
    {
        decimal ApplyDiscount(decimal amount);
    }

    // کلاس تخفیف برای مشتریان عادی
    public class RegularDiscount : IDiscount
    {
        public decimal ApplyDiscount(decimal amount)
        {
            return amount * 0.1m;
        }
    }

    // کلاس تخفیف برای مشتریان VIP
    public class VipDiscount : IDiscount
    {
        public decimal ApplyDiscount(decimal amount)
        {
            return amount * 0.2m;
        }
    }

    // کلاس محاسبه تخفیف‌ها
    public class DiscountCalculator
    {
        private readonly IDiscount _discount;

        public DiscountCalculator(IDiscount discount)
        {
            _discount = discount;
        }

        public decimal Calculate(decimal amount)
        {
            return _discount.ApplyDiscount(amount);
        }
    }
    /*
     حالا، اگر نیاز به اضافه کردن یک نوع تخفیف جدید باشد، تنها کافی است یک کلاس جدید ایجاد کنیم که از واسط IDiscount ارث‌بری می‌کند، بدون این که نیازی به تغییر در کلاس DiscountCalculator داشته باشیم.
     */

}
