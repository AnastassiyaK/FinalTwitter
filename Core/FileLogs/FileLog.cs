using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FileLogs
{
    public class FileLog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void WriteMessagesInFile(string message)
        {

            logger.Debug(message);

        }
    }
}
