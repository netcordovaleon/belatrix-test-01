using Belatrix.LoggerPluggable.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.LoggerPluggable.LogManagerFile
{
    public class LogRepository : ILogRepository
    {
        private string pathFile;
        private string fileName;
        public LogRepository() { }

        public LogRepository(Dictionary<string, string> parameters)
        {
            this.pathFile = parameters["PathFile"];
            this.fileName = parameters["FileName"];
        }

        public void SaveMessage(Types.MessageLog message)
        {
            try
            {
                string fileName = string.Empty;
                fileName = string.Format(@"{0}\{1}_{2}.log", this.pathFile, this.fileName, DateTime.Now.ToString("ddMMyyyyHHmmss"));
                
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(message.Title);
                    sw.WriteLine(message.Message);
                    sw.WriteLine(DateTime.Now.ToLongDateString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
