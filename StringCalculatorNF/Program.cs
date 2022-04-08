using StringCalculatorNF.Interfaces;
using StringCalculatorNF.Logger;
using StringCalculatorNF.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorNF
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                var getDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string logFileFullPath = string.Format(@"{0}\{1}", getDirectory, "log.txt");

                string choose = string.Empty;
                bool run = true;
                do
                {
                    Console.WriteLine("Welcome to String Calculator!!!");
                    Console.WriteLine("Choose your result output method below:");
                    Console.WriteLine("'1' - log to console, '2' - log to file, '9' - exit program");

                    choose = Console.ReadLine();
                    if (choose == "1" || choose == "2") run = false;
                    if (choose == "9") return;
                } while (run);

                ILogger myLogger = null;
                
                if (choose == "1")
                {
                    myLogger = new ConsoleLogger();
                }
                else if (choose == "2")
                {
                    myLogger = new FileLogger(logFileFullPath);
                }
                CustomLogger customLogger = new CustomLogger(myLogger);
                StringCalculator stringCalculator = new StringCalculator(myLogger);


                var questions = new List<string>();

                var newInput = "( 1.1 - 1 ) + ( ( 1 + 1 ) * ( 1.1 * 1 ) )";
                questions.Add(newInput);
                questions.Add("1 + 1");
                questions.Add("2 * 2");
                questions.Add("1 + 2 + 3");
                questions.Add("6 / 2");
                questions.Add("11 + 23"); //34
                questions.Add("11.1 + 23"); // 34.1
                questions.Add("1 + 1 * 3"); // 4

                customLogger.WriteLog("*** GROUP 1 QUESTIONS (No bracket) ***");
                foreach (var question in questions)
                {
                    var result = stringCalculator.Calculate(question);
                    //Console.WriteLine();
                }

                var questions2 = new List<string>();
                questions2.Add("( 11.5 + 15.4 ) + 10.1"); // 37.0
                questions2.Add("23 - ( 29.3 - 12.5 )"); //6.2
                questions2.Add("( 1 / 2 ) - 1 + 1"); //0.5

                customLogger.WriteLog(System.Environment.NewLine);
                customLogger.WriteLog("*** GROUP 2 QUESTIONS (With Brackets) ***");
                foreach (var question in questions2)
                {
                    var result = stringCalculator.Calculate(question);
                    //Console.WriteLine();
                }

                var questions3 = new List<string>();
                questions3.Add("10 - ( 2 + 3 * ( 7 - 5 ) )"); //2

                customLogger.WriteLog(System.Environment.NewLine);
                customLogger.WriteLog("*** GROUP 3 QUESTIONS (With Nested Brackets) ***");
                foreach (var question in questions3)
                {
                    var result = stringCalculator.Calculate(question);
                    //Console.WriteLine();
                }

                if (choose == "2")
                {
                    Console.WriteLine(string.Format("see your 'result' at log file at this path {0}", logFileFullPath));
                }

                Console.WriteLine("...completed...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }

        }
    }
    
}
