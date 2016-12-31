using System;

namespace Console_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instance of LogConsoleWriter
            Badget.libLog.LogToConsole logToConsole = new Badget.libLog.LogToConsole();

            Console.Title = "Badget Console Test";
            Badget.libLog.LogFileWriter.WriteEntry(logToConsole, new Badget.libLog.LogFileEntry("Test Error", Badget.libLog.LogStates.Error));
            Badget.libLog.LogFileWriter.WriteEntry(logToConsole, new Badget.libLog.LogFileEntry("Test Warning", Badget.libLog.LogStates.Warning));
            Badget.libLog.LogFileWriter.WriteEntry(logToConsole, new Badget.libLog.LogFileEntry("Test Info", Badget.libLog.LogStates.Info));
            Badget.libLog.LogFileWriter.WriteEntry(logToConsole, new Badget.libLog.LogFileEntry("Test Message", Badget.libLog.LogStates.Message));
            Badget.libLog.LogFileWriter.WriteEntry(logToConsole, new Badget.libLog.LogFileEntry("Test None", Badget.libLog.LogStates.None));

            Console.WriteLine();
            Console.Write("Testing support for Console-ReadEntry: ");
            try
            {
                Badget.libLog.LogFileWriter.ReadEntry(logToConsole, 0);
                WriteColored("Supported", ConsoleColor.Green);
            }
            catch { WriteColored("Not supported", ConsoleColor.Red); }
            Console.WriteLine();
            Console.ReadKey(true);
        }

        static void WriteColored(string msg, ConsoleColor color)
        {
            var fgcol = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ForegroundColor = fgcol;
        }
    }
}