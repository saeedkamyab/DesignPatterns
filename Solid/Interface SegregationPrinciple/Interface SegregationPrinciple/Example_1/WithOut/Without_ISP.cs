using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interface_SegregationPrinciple.Example_1.WithOut
{

//    اصل Interface Segregation Principle(ISP)، یکی از اصول SOLID، بیان می‌کند که یک واسط(interface) نباید بیش از حد بزرگ باشد و فقط متدهایی را تعریف کند که یک کلاس واقعاً به آن‌ها نیاز دارد.
//تعریف رسمی:
//    "Clients should not be forced to depend on methods they do not use." (مشتری‌ها نباید مجبور شوند به متدهایی وابسته شوند که از آن‌ها استفاده نمی‌کنند.)
//این اصل می‌گوید اگر یک واسط متدهایی داشته باشد که همه‌ی پیاده‌کنندگان آن نیازی به استفاده از آن‌ها ندارند، بهتر است آن واسط به چند واسط کوچک‌تر تقسیم شود.
//چرا ISP مهم است؟
//    کاهش وابستگی‌های ناخواسته: اگر واسط بزرگی ایجاد شود، تغییر در یک قسمت می‌تواند بر تمامی کلاس‌هایی که آن واسط را پیاده‌سازی می‌کنند، تأثیر بگذارد.
//    افزایش انعطاف‌پذیری: واسط‌های کوچک‌تر امکان انعطاف‌پذیری بیشتری به کد می‌دهند.
//    رعایت تک‌مسئولیتی: واسط‌های کوچک‌تر، وظیفه‌های مشخص‌تری دارند.
    internal class Without_ISP
    {

    }
    //فرض کنید یک واسط برای موجودی‌ها در یک بازی طراحی کرده‌ایم:
    public interface IPlayerActions
    {
        void Attack();
        void Defend();
        void Heal();
    }

    //اکنون کلاس‌های مختلفی داریم که این واسط را پیاده‌سازی می‌کنند:
    //یک جنگجو(Warrior) فقط می‌تواند حمله و دفاع کند.
    //یک پزشک (Medic) فقط می‌تواند درمان کند.
    //اما هر دوی آن‌ها مجبور هستند متدهایی را پیاده‌سازی کنند که به آن‌ها نیازی ندارند.
    public class Warrior : IPlayerActions
    {
        public void Attack()
        {
            Console.WriteLine("Warrior attacks!");
        }

        public void Defend()
        {
            Console.WriteLine("Warrior defends!");
        }

        public void Heal()
        {
            throw new NotImplementedException(); // Warrior نیازی به Heal ندارد.
        }
    }

    public class Medic : IPlayerActions
    {
        public void Attack()
        {
            throw new NotImplementedException(); // Medic نیازی به Attack ندارد.
        }

        public void Defend()
        {
            throw new NotImplementedException(); // Medic نیازی به Defend ندارد.
        }

        public void Heal()
        {
            Console.WriteLine("Medic heals!");
        }
    }
    //در اینجا، واسط بزرگ IPlayerActions اصل ISP را نقض می‌کند، زیرا همه کلاس‌ها مجبور به پیاده‌سازی متدهایی شده‌اند که نیازی به آن‌ها ندارند.


}
