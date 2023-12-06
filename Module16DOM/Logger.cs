using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module16DOM
{
    public class Logger
    {
        private static string logFilePath = @"C:\Users\RepublikONE\source\repos\Module16DOM\ffff.txt";

        public static void LogAction(string action)
        {
            try
            {
                using (StreamWriter logWriter = new StreamWriter(logFilePath, true))
                {
                    logWriter.WriteLine($"{DateTime.Now}: {action}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при логировании: {ex.Message}");
            }
        }
    }
}
