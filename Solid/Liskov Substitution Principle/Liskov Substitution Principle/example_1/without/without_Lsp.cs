using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_Substitution_Principle.example_1.without
{

    /*

     Liskov Substitution Principle (LSP) یکی از پنج اصل SOLID در طراحی شی‌گرا است. این اصل بیان می‌کند که در یک برنامه، اگر کلاسی از یک کلاس والد ارث‌بری می‌کند، باید بتواند به جای آن کلاس والد استفاده شود، بدون این که تغییری در رفتار صحیح برنامه ایجاد شود. به عبارت دیگر، یک زیرکلاس نباید رفتار کلاس والد را نقض یا تغییر دهد.
   تعریف اصل:

   اصل جایگزینی لیسکوف می‌گوید: "هر جا از یک شیء کلاس والد استفاده شده، باید بتوان از شیء کلاس فرزند نیز به‌جای آن استفاده کرد، بدون اینکه نیاز به تغییرات دیگری در کد باشد."

   به عبارت ساده‌تر، کد شما نباید بسته به این که از یک کلاس والد یا فرزند استفاده می‌شود، رفتار متفاوتی داشته باشد. این اصل از پایبندی به رفتارهای قراردادی کلاس والد حمایت می‌کند و از بروز مشکلات پیش‌بینی‌نشده در رفتار سیستم جلوگیری می‌کند.
     */
    internal class without_Lsp
    {
    }

    /// <summary>
    /// فرض کنید کلاسی به نام Bird داریم که متدی برای پرواز دارد و کلاسی به نام Penguin که از Bird ارث‌بری می‌کند.
    /// در اینجا، کد ما با اصل جایگزینی لیسکوف سازگار نیست، چون Penguin نمی‌تواند به‌درستی جایگزین Bird شود؛ زیرا Penguin برخلاف رفتار قراردادی کلاس Bird قادر به پرواز نیست.
    /// </summary>

    public class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }

    public class Penguin : Bird
    {
        public override void Fly()
        {
            throw new InvalidOperationException("Penguins cannot fly!");
        }
    }


}
