using Belatrix.LoggerPluggable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.LoggerPluggable
{
    public class LoggerFactory
    {
        public static ILogManager Create(string type, string assembly, Dictionary<string, string> parameters)
        {
            Assembly loggerAssembly = Assembly.Load(assembly);

            Type loggerType = loggerAssembly.GetType(type);

            object loggerInstance = Activator.CreateInstance(loggerType, parameters);

            return loggerInstance as ILogManager;

        }
    }
}
