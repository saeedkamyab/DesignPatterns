using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{

    public interface ILogger
    {
        void Log(string message);
    }
    public abstract class LoggerFactory
    {
        public abstract ILogger CreateLogger();
    }

    #region File Logger
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Log to File: " + message);
        }
    }
    public class FileLoggerFactory : LoggerFactory
    {
        public override ILogger CreateLogger()
        {
            return new FileLogger();
        }
    }
    #endregion


    #region DataBase Logger
    public class DataBaseLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Log to DataBase: " + message);
        }
    }
    public class DataBaseLoggerFactory:LoggerFactory
    {
        public override ILogger CreateLogger()
        {
            return new DataBaseLogger();
        }
    }
    #endregion




    class Program3
    {
        static void Main(string[] args)
        {
            LoggerFactory factory = new FileLoggerFactory();
            LoggerFactory dbFactory = new DataBaseLoggerFactory();
           
            ILogger logger = factory.CreateLogger();
            logger.Log("This is a log message for file.");
          
            logger=dbFactory.CreateLogger();
            logger.Log("This is a log message for database.");
        }
    }
}
