using Belatrix.LoggerPluggable.Interfaces;
using Belatrix.LoggerPluggable.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.LoggerPluggable
{
    public class LoggerBelatrix
    {
        private static IList<ILogManager> LogManagers;

        public LoggerBelatrix()
        {
            if(LogManagers == null)
            {
                LogManagers = new List<ILogManager>();

                var loggerSection = RegisterLoggerConfig.GetConfig();
                foreach (LoggerPluginElement element in loggerSection.LoggerManagers)
                {
                    Dictionary<string, string> Parameters = new Dictionary<string, string>();
                    foreach (ParamPluginElement subelement in element.Constructor)
                    {
                        Parameters.Add(subelement.Key, subelement.Value);
                    }

                    LogManagers.Add(LoggerFactory.Create(element.Type, element.Assembly, Parameters));
                }
            }             
        }

        public void Message(string message, EventType eventType)
        {
            LogManagers.ToList().ForEach(o => o.AddEvent(message, eventType));
        }
    }
}
