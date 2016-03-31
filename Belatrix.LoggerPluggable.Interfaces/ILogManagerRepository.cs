using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.LoggerPluggable.Interfaces
{
    public interface ILogManagerRepository : ILogManager
    {
        ILogRepository LogRepository { get; }
    }
}
