using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBasicExample
{
    class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();

            //LogDel logDel = new LogDel(log.LogTextToFile);
            LogDel log1,log2;

            log1 = new LogDel(log.LogTextToScreen);
            log2 = new LogDel(log.LogTextToFile);

            Console.WriteLine("enter your name: ");

            var name = Console.ReadLine();
          

            //logDel(name);
            LogDel multiLog = log1 + log2;
            //multiLog(name);

            LogText(multiLog, name);

            Console.ReadKey();
        }
        static void LogText(LogDel logDel,string text)
        {
            logDel(text);
        }
        static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}:{text}");
        }
        static void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))

            {
                sw.WriteLine($"{DateTime.Now}:{text}");
            };    
        }
        
    }
    public class Log
    {
        public void LogTextToScreen(string text )
        {
            Console.WriteLine($"{DateTime.Now}:{text}");
        }
        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))

            {
                sw.WriteLine($"{DateTime.Now}:{text}");
            };
        }
    }
}
