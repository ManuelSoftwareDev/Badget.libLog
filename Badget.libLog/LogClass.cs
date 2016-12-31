using System;
using System.Collections.Generic;
using System.IO;

namespace Badget.libLog
{
    public interface ILogFile
    {
        string FileName { get; }
    }

    public interface ILogEntry
    {
        string EventName { get; set; }
        LogStates State { get; set; }
        DateTime Time { get; }
    }

    public enum LogStates
    {
        Default = 150,
        Error = 10,
        Info = 15,
        Warning = 30,
        Message = 50,
        None = 0
    }

    public sealed class LogToConsole : ILogFile
    {
        public string FileName => "System.Console";
    }

    public sealed class LogFile : ILogFile
    {
        public LogFile(string FileName)
        {
            _fName = FileName;
            if (!File.Exists(FileName))
                File.Create(FileName, 10).Close();
        }
        private string _fName = "";

        public string FileName => _fName;
    }

    public class LogFileEntry : ILogEntry
    {
        public LogFileEntry(string Message, LogStates State = LogStates.Message)
        {
            this.EventName = Message;
            this.State = State;
            this._time = DateTime.Now;
        }
        public LogFileEntry(string Message, LogStates State, DateTime t)
        {
            this.EventName = Message;
            this.State = State;
            this._time = t;
        }

        protected DateTime _time;

        public string EventName { get; set; }
        public LogStates State { get; set; }
        public DateTime Time { get => _time; }
    }

    internal class LogStaticEntry : ILogEntry
    {
        public DateTime _time { get; set; }
        public string EventName { get; set; }
        public LogStates State { get; set; }
        public DateTime Time { get => _time; }
    }

    public static class LogFileWriter
    {
        private class ConsoleWriter
        {
            public static void WriteColored(ConsoleColor col, string msg)
            {
                var fgcol = Console.ForegroundColor;
                Console.ForegroundColor = col;
                Console.Write(msg);
                Console.ForegroundColor = fgcol;
            }
            public static ConsoleColor ColorFromState(LogStates state)
            {
                switch (state)
                {
                    case LogStates.Error:
                        return ConsoleColor.Red;
                    case LogStates.Info:
                        return ConsoleColor.Cyan;
                    default:
                    case LogStates.Default:
                    case LogStates.None:
                    case LogStates.Message:
                        return Console.ForegroundColor;
                    case LogStates.Warning:
                        return ConsoleColor.Yellow;
                }
            }
        }

        public static void WriteEntry(ILogFile file, ILogEntry entry)
        {
            if (file.GetType().Name == "LogToConsole")
            {
                ConsoleWriter.WriteColored(ConsoleWriter.ColorFromState(entry.State), "[" + entry.State.ToString() + "]");
                Console.Write(" [" + entry.Time.ToLongTimeString() + "] ");
                ConsoleWriter.WriteColored(ConsoleWriter.ColorFromState(entry.State), entry.EventName);
                Console.WriteLine();
                return;
            }
            FileStream fs = null;
            if (System.IO.File.Exists(file.FileName))
                fs = System.IO.File.Open(file.FileName, FileMode.Append);
            else
                fs = System.IO.File.Create(file.FileName);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(fs);
            writer.WriteLine(LogEntryToString(entry));
            writer.Flush();
            writer.Close();
            try { fs.Close(); fs.Dispose(); writer.Dispose(); } catch { }
            fs = null;
            writer = null;
        }

        public static ILogEntry ReadEntry(ILogFile file, int index)
        {
            if (file.GetType().Name == "LogToConsole")
            { throw new NotSupportedException("Can't read entry from Console yet."); }

            if (index < 0)
                throw new ArgumentOutOfRangeException("index");

            string[] lines = System.IO.File.ReadAllLines(file.FileName);

            if (index >= lines.Length)
                throw new ArgumentOutOfRangeException("index");

            string line = lines[index];
            if (line.Replace(" ", "").Length == 0)
                return null;
            string[] splitted = line.Split(' ');
            LogStaticEntry entry = new LogStaticEntry()
            {
                State = StringToLogState(splitted[0])
            };
            DateTime dt = DateTime.Now;
            if (entry.State == LogStates.None && DateTime.TryParse(splitted[0].Replace("[", "").Replace("]", ""), out dt))
            { entry._time = dt; entry.EventName = line.Replace(splitted[0] + " ", ""); return entry; }
            else if (DateTime.TryParse(splitted[1].Replace("[", "").Replace("]", ""), out dt))
                entry._time = dt;
            else
                entry._time = DateTime.MinValue;
            entry.EventName = line.Replace(splitted[0] + " " + splitted[1] + " ", "");
            return entry;
        }

        public static ILogEntry[] ReadEntries(LogFile file)
        {
            if (file.GetType().Name == "LogToConsole")
            {
                throw new NotSupportedException("Can't read entries from Console yet.");
            }
                List<ILogEntry> entries = new List<ILogEntry>();
            for (int i = 0; i < System.IO.File.ReadAllLines(file.FileName).Length; i++)
            { var entry = ReadEntry(file, i); if (entry != null) entries.Add(entry); }
            return entries.ToArray();
        }

        public static void WriteEntries(LogFile file, params ILogEntry[] entries)
        {
            foreach (var entry in entries)
                WriteEntry(file, entry);
        }
        private static LogStates StringToLogState(string str)
        {
            switch (str.ToLower().Replace("[", "").Replace("]", ""))
            {
                case "error":
                    return LogStates.Error;
                case "info":
                    return LogStates.Info;
                case "message":
                    return LogStates.Message;
                case "warning":
                    return LogStates.Warning;
                default:
                    return LogStates.None;
            }
        }
        private static string LogEntryToString(ILogEntry entry)
        {
            string final = "";
            switch (entry.State)
            {
                case LogStates.Error:
                    final = "[ERROR] ";
                    break;
                case LogStates.Info:
                    final = "[INFO] ";
                    break;
                default:
                case LogStates.Default:
                case LogStates.Message:
                    final = "[MESSAGE] ";
                    break;
                case LogStates.None:
                    final = "";
                    break;
                case LogStates.Warning:
                    final = "[WARNING] ";
                    break;
            }
            if (entry.Time != null)
                final += "[" + entry.Time.ToLongTimeString() + "]";
            else
                final += "[" + DateTime.Now.ToLongTimeString() + "]";

            final += " " + entry.EventName;
            if (final.StartsWith(" "))
                final = final.Remove(0, 1);
            return final;
        }
    }
}
