using Belatrix.LoggerPluggable.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.LoggerPluggable.Interfaces
{
    public interface ILogRepository
    {
        void SaveMessage(MessageLog message);
    }
}
