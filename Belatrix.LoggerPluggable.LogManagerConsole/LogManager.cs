using Belatrix.LoggerPluggable.Interfaces;
using Belatrix.LoggerPluggable.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.LoggerPluggable.LogManagerConsole
{
    public class LogManager : ILogManager
    {
        public LogManager(Dictionary<string, string> _params)
        {
            
        }

        public void AddEvent(string message, Types.EventType eventType)
        {
            var messageLog = new MessageLog(message, eventType.GetHashCode());
            Console.WriteLine(messageLog.Title.ToUpper());
            Console.WriteLine(string.Format("RESPONSE: {0}", messageLog.Message));
            Console.WriteLine(string.Format("DATE: {0}", DateTime.Now));
        }
    }
}
