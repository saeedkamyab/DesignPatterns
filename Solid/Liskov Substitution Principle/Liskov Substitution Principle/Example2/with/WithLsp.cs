using Liskov_Substitution_Principle.Example2.without;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_Substitution_Principle.Example2.with
{
	/*
	 رعایت LSP - بهبود طراحی:
	   
	   برای رعایت اصل LSP، می‌توانیم کلاس‌ها را طوری تغییر دهیم که Bird لزوماً متدی برای پرواز نداشته باشد و به جای آن از یک واسط به نام IFlyable استفاده کنیم. سپس کلاس‌هایی که توانایی پرواز دارند، می‌توانند این واسط را پیاده‌سازی کنند.
	 */
	internal class WithLsp
	{
		/*
		 * حالا تابع LetBirdFly فقط بر روی اشیائی که پرواز می‌کنند (یعنی پیاده‌کننده‌ی واسط IFlyable هستند) عمل می‌کند.
		 */
		public void LetBirdFly(IFlyable bird)
		{
			bird.Fly();
		}

		public void doIt()
		{
			// استفاده از تابع LetBirdFly
			IFlyable sparrow = new Sparrow();
			LetBirdFly(sparrow); // خروجی: Flying!

			Bird penguin = new Penguin();
			// LetBirdFly(penguin); // خطا: پنگوئن نمی‌تواند پرواز کند و واسط IFlyable را پیاده‌سازی نکرده است
		}



	}
	public class Bird
	{
		// رفتارهای عمومی پرنده‌ها بدون وابستگی به پرواز
	}

	public interface IFlyable
	{
		void Fly();
	}

	public class Sparrow : Bird, IFlyable
	{
		public void Fly()
		{
			Console.WriteLine("Flying!");
		}
	}

	public class Penguin : Bird
	{
		// پنگوئن بدون نیاز به پیاده‌سازی متد Fly
	}
	/*
	 *توضیح:
	   
	   با این طراحی، تابع LetBirdFly تنها به اشیاءی که قابلیت پرواز دارند اعمال می‌شود. به این ترتیب، اصل جانشینی لیسکوف (LSP) رعایت می‌شود، چون اکنون جایگزینی Sparrow به جای Bird مشکلی ایجاد نمی‌کند و Penguin نیز به درستی در این ساختار قرار می‌گیرد.
	 */

}
