using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecoverDisk.StorageAccess;

namespace RecoverDisk.DiskAnalyze
{
    public class DataGuess : EventReporter
    {
        public delegate void ProgessEventHandler(object sender, ProgressUpdateEventArgs e);
        public delegate void LogEventHandler(object sender, LogEventArgs e);
        public bool StopTask;

        public virtual Dictionary<string, long> GuessOsParameters()
        {
            throw new NotImplementedException();
        }

        public virtual long[] ScanForDirectoryLists(FileSystemBase fs, ref int clusternum, int parentDirectory = -1)
        {
            throw new NotImplementedException();
        }

    }
}
