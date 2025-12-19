using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public interface IButton
    {
        void Render();
    }
    public interface ITextbox
    {
        void Render();
    }

    #region DarkTheme
    public class DarkButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Dark Button");
        }
    }
    public class DarkTextbox : ITextbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering Dark Textbox");
        }
    }
    #endregion

    #region LightTheme
    public class LightButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Light Button");
        }
    }
    public class LightTextbox : ITextbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering Light Textbox");
        }
    }
    #endregion


    public interface IUIFactory
    {
        IButton CreateButton();
        ITextbox CreateTextbox();
    }

    #region Factories
    public class DarkThemeFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new DarkButton();
        }
        public ITextbox CreateTextbox()
        {
            return new DarkTextbox();
        }
    }

    public class LightThemeFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new LightButton();
        }
        public ITextbox CreateTextbox()
        {
            return new LightTextbox();
        }
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {

            IUIFactory factory;
            Console.WriteLine("Theme? (dark/light)");
            var theme = Console.ReadLine();
            if (theme == "dark")
            {
                factory = new DarkThemeFactory();
                var button=factory.CreateButton();
                button.Render();
            }
            else
            {
                factory = new LightThemeFactory();
                var button = factory.CreateButton();
                button.Render();
            }

        }
    }
}
