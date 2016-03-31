using Belatrix.LoggerPluggable.Interfaces;
using Belatrix.LoggerPluggable.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.LoggerPluggable.LogManagerDataBase
{
    public class LogManager : ILogManagerRepository
    {

        Dictionary<string, string> parameters;

        public LogManager(Dictionary<string, string> parameters)
        {
            this.parameters = parameters;
        }

        public ILogRepository LogRepository
        {
            get
            {
                return (ILogRepository)new LogRepository(this.parameters);
            }
        }

        public void AddEvent(string message, Types.EventType eventType)
        {
            //var messageLog = new MessageLog()
            //{
            //    Message = message,
            //    Event = eventType.GetHashCode()
            //};
            var messageLog = new MessageLog(message, eventType.GetHashCode());

            this.LogRepository.SaveMessage(messageLog);
        }
    }
}
