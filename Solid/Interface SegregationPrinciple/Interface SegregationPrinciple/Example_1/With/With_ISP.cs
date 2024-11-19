using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_SegregationPrinciple.Example_1.With
{
//    رعایت ISP - طراحی صحیح:
//برای رعایت این اصل، واسط‌ها را کوچک‌تر کرده و آن‌ها را به وظایف مشخص تقسیم می‌کنیم:
    internal class With_ISP
    {
    }
    public interface IAttack
    {
        void Attack();
    }

    public interface IDefend
    {
        void Defend();
    }

    public interface IHeal
    {
        void Heal();
    }
    //حالا کلاس‌ها فقط واسط‌هایی را پیاده‌سازی می‌کنند که واقعاً به آن‌ها نیاز دارند:
    public class Warrior : IAttack, IDefend
    {
        public void Attack()
        {
            Console.WriteLine("Warrior attacks!");
        }

        public void Defend()
        {
            Console.WriteLine("Warrior defends!");
        }
    }

    public class Medic : IHeal
    {
        public void Heal()
        {
            Console.WriteLine("Medic heals!");
        }
    }
//    مزایای طراحی جدید:
//    هر کلاس فقط متدهای مرتبط با وظایف خودش را پیاده‌سازی می‌کند.
//    تغییرات در واسط‌ها فقط بر کلاس‌های مرتبط تأثیر می‌گذارد.
//    انعطاف‌پذیری و خوانایی کد افزایش می‌یابد.
//جمع‌بندی:
//اصل ISP به ما یادآوری می‌کند که واسط‌های بزرگ و چندمنظوره طراحی نکنیم.به‌جای آن، واسط‌های کوچک و هدفمند ایجاد کنیم تا کلاس‌ها فقط متدهایی را پیاده‌سازی کنند که واقعاً به آن‌ها نیاز دارند.

}
