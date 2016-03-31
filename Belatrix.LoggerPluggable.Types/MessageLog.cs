using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.LoggerPluggable.Types
{
    public class MessageLog
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int Event { get; set; }

        public MessageLog() { }

        public MessageLog(string _message, int eventType) {
            switch (eventType)
            {
                case (int)EventType.Success: 
                    this.Title = string.Format("Operation Result : {0}", "Success");
                    break;
                case (int)EventType.Warning:
                    this.Title = string.Format("Operation Result : {0}", "Warning");
                    break;
                case (int)EventType.Error:
                    this.Title = string.Format("Operation Result : {0}", "Error");
                    break;
            }
            this.Message = _message;
            this.Event = eventType;
        }
    }
}
