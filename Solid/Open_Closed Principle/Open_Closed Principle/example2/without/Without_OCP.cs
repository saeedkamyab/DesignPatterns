using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed_Principle.example2.without
{
    /*
     Open/Closed Principle (اصل باز/بسته) یکی از اصول SOLID است که تاکید می‌کند کلاس‌ها، ماژول‌ها یا توابع باید برای گسترش باز و برای تغییر بسته باشند. این اصل بیان می‌کند که شما باید بتوانید بدون تغییر در کد موجود، قابلیت‌های جدیدی را اضافه کنید.
توضیح بیشتر درباره اصل Open/Closed:

در این اصل، باید ساختار کد را به گونه‌ای طراحی کنید که با اضافه کردن رفتارهای جدید، نیازی به دست بردن در کدهای قدیمی نباشد. این کار باعث می‌شود که احتمال بروز باگ‌های جدید در کد کاهش پیدا کند و نگهداری و توسعه‌ی سیستم ساده‌تر شود. یکی از روش‌های مرسوم برای پیاده‌سازی این اصل، استفاده از پلی‌مورفیسم (چندریختی) و واسط‌ها است.
     */
    internal class Without_OCP
    {
    }

    /*
     فرض کنید می‌خواهیم یک سیستم تخفیف برای یک فروشگاه آنلاین ایجاد کنیم. در ابتدا، یک کلاس برای محاسبه تخفیف‌ها می‌سازیم.
طراحی اولیه (غیرسازگار با Open/Closed Principle):
     */

    public class DiscountCalculator
    {
        public decimal CalculateDiscount(string customerType, decimal amount)
        {
            if (customerType == "Regular")
            {
                return amount * 0.1m; // تخفیف 10 درصدی برای مشتریان عادی
            }
            else if (customerType == "VIP")
            {
                return amount * 0.2m; // تخفیف 20 درصدی برای مشتریان VIP
            }
            else
            {
                return 0; // بدون تخفیف
            }
        }
    }
    /*
     در اینجا اگر بخواهیم یک نوع مشتری جدید اضافه کنیم (مثلاً مشتری وفادار با تخفیف ۱۵٪)، باید در متد CalculateDiscount کد جدیدی اضافه کنیم. این باعث می‌شود که هر بار نیاز به اضافه کردن شرایط جدید، کد موجود تغییر کند، که با اصل باز/بسته سازگار نیست.
     */

}
