using Belatrix.LoggerPluggable.Types;
using System;

namespace Belatrix.LoggerPluggable.Interfaces
{
    public interface ILogManager
    {
        void AddEvent(string message, EventType eventType);
    }
}
