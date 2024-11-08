using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_Substitution_Principle.example_1.with
{
    /*
     بهبود برای رعایت اصل LSP:

برای حل این مشکل، می‌توانیم یک کلاس پایه جدید ایجاد کنیم و کلاس‌های پرنده‌های پرنده و غیرپرنده را از هم جدا کنیم.
     */
    internal class With_Lsp
    {
    }

    public class Bird
    {
        // ویژگی‌ها و رفتارهای عمومی پرنده‌ها
    }

    public class FlyingBird : Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }

    public class Penguin : Bird
    {
        // رفتارهای خاص پنگوئن
    }
    /*
     حالا اگر FlyingBird را از Bird ارث ببریم و کلاس‌های پرنده‌های قابل پرواز (مثل Eagle یا Sparrow) را از FlyingBird ارث ببریم، اصل LSP رعایت می‌شود، چون هیچ‌کدام از کلاس‌ها، رفتار قراردادی والدین خود را نقض نمی‌کنند و پنگوئن بدون امکان پرواز تعریف شده است.

به این ترتیب، از کلاس‌هایی با رفتارهای متفاوت در جاهای مناسب استفاده می‌شود، بدون این که جایگزینی آنها منجر به خطاهای منطقی شود.
     */
}
