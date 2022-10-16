using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverDisk.StorageAccess
{
    #region Delegates

    public delegate void ProgessEventHandler(object sender, ProgressUpdateEventArgs e);
    public delegate void LogEventHandler(object sender, LogEventArgs e);

    #endregion

    #region EventArgs

    public class ProgressUpdateEventArgs : EventArgs
    {
        public int Percent { get; set; }
        public int Value { get; set; }
    }

    public class LogEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    #endregion

    public class EventReporter
    {
        #region Event Handler

        public event LogEventHandler OnEventLog;
        public event ProgessEventHandler OnProgress;

        public virtual void EventLog(string message)
        {
            OnEventLog?.Invoke(this, new LogEventArgs { Message = message });
        }

        public virtual void UpdateProgress(int percent, int value = 0)
        {
            OnProgress?.Invoke(this, new ProgressUpdateEventArgs { Percent = percent, Value = value });
        }

        #endregion
    }
}
