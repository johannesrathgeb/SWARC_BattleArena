using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BattleArena
{
    class LoggingSystem
    {
        private static LoggingSystem instance;
        private string logText;
        private List<string> logList = new List<string>();
        private LoggingSystem()
        {
            logList.Add("-------------------------------------------------" + "\n");
            logList.Add("New Game started" + "\n");
            logList.Add("-------------------------------------------------" + "\n");
        }

        public static LoggingSystem getInstance()
        {
            if(instance == null)
            {
                instance = new LoggingSystem();
            }
            return instance;
        }

        public void createLog(string instanceName, string user, DateTime time)
        {
            logText = user + " called " + instanceName + " at " + time + "\n";
            Console.WriteLine(logText);
            logList.Add(logText);
        }

        public void saveToFile()
        {
            foreach(string text in logList)
            {
                File.AppendAllText("log.txt", text);
            }
        }
    }
}
