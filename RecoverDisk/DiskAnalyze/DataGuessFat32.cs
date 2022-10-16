using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RecoverDisk.StorageAccess;

namespace RecoverDisk.DiskAnalyze
{
    public class DataGuessFat32 : DataGuess
    {
        IStorageIO storageIo;
        const int sectorsInBuffer = 100;
        const string fatStartBeforePattern = "0000000000000000";
        const string fatStartAfterPattern = "F8FFFF0FFFFFFFFF";
        byte[] buffer;
        int bytesPerSector;

        public DataGuessFat32(IStorageIO sio)
        {
            storageIo = sio;
            bytesPerSector = sio.GetDiskInfo().BytesPerSector;
            buffer = new byte[sectorsInBuffer * bytesPerSector];
        }

        long SearchPattern(long startSearch, long endSearch, string beforePattern, string afterPattern)
        {
            byte[] searchBefore = DUtils.StrToByte(fatStartBeforePattern);
            byte[] searchAfter = DUtils.StrToByte(fatStartAfterPattern);
            for (long i = startSearch; i < endSearch; i += sectorsInBuffer - 1)
            {
                storageIo.Seek(i * bytesPerSector);
                storageIo.ReadBytes(buffer, buffer.Length);
                int res = DUtils.MatchPattern(buffer, bytesPerSector, searchBefore, searchAfter);
                if (res >= 0)
                    return i + res;
            }
            return 0;
        }

        public override Dictionary<string, long> GuessOsParameters()
        {
            Dictionary<string, long> res = new Dictionary<string, long>();
            DiskInfo di = storageIo.GetDiskInfo();

            int sectorsPerCluster = 64;
            int fatEntriesPerSector = di.BytesPerSector / 4;

            long maxFatSectors = ((long)di.TotalSectors / sectorsPerCluster) / fatEntriesPerSector;

            // guess FAT start sector
            long fatstart = SearchPattern(1, 10000, fatStartBeforePattern, fatStartAfterPattern);
            res["FatStart"] = fatstart;

            // Guess Fat Size
            long maxFatSectorsSearch = fatstart + maxFatSectors * 2;
            long fat2start = SearchPattern(fatstart, maxFatSectorsSearch, fatStartBeforePattern, fatStartAfterPattern);
            long fatsize = fat2start - fatstart;
            res["FatSize"] = fatsize;

            // Guess Root Dir Start
            long rootdirstart = fatstart + 2 * fatsize;
            res["RootDirStart"] = rootdirstart;

            // Guess Root Entry Size
            res["RootEntrySize"] = 0;

            // Guess Data Cluster Size
            res["ClusterSize"] = 64;

            return res;
        }

        public override long[] ScanForDirectoryLists(FileSystemBase fs, ref int clusternum, int parentDirectory = -1)
        {
            List<long> dirsFound = new List<long>();
            int bytepersector = storageIo.GetDiskInfo().BytesPerSector;
            byte[] databuff = new byte[bytepersector];
            BootSectorCommon bs = fs.BootSector;
            StopTask = false;
;
            int numClusters = (int)(bs.FatSizeInBytes / bs.BytesPerFatConst); // FixMe: need accurate calculation

            for (; clusternum < numClusters; clusternum++)
            {
                if (StopTask)
                    break;

                if (DUtils.UpdatePeriodPassed())
                    UpdateProgress(clusternum * 100 / numClusters, clusternum);
                int fatEntry = ((FileSystemFAT)fs).GetFatEntry(clusternum) & (int)bs.MaxFatEntrySzConst;
                if (fatEntry == 0 || fatEntry == bs.BadClusterFlagConst)
                    continue;

                storageIo.Seek(fs.GetAbsoluteLocation(clusternum));
                storageIo.ReadBytes(databuff, databuff.Length);

                // guess if this cluster is a directory listing by looking for the '.' and '..' entries
                if (DUtils.SequenceEqual(databuff, 0, ".          ") &&
                    DUtils.SequenceEqual(databuff, 32, "..         "))
                {
                    try
                    {
                        FatEntry entry = FileSystemFAT.ParseFatEntry(databuff, 32);
                        if ((entry.Attribute & (int)EntryAttributes.Directory) != 0)
                        {
                            if (parentDirectory == -1 || entry.StartCluster == parentDirectory)
                            {
                                dirsFound.Add(clusternum);
                                // log the result
                                StreamWriter sw = new StreamWriter("ScanedDirs.txt", true);
                                sw.WriteLine(string.Format("{0}, {1}", clusternum, fs.GetAbsoluteLocation(clusternum) / bytepersector));
                                sw.Close();
                            }
                        }
                    }
                    catch { }
                }
            }
            return dirsFound.ToArray();
        }

    }
}
