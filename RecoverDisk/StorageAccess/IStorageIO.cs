using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RecoverDisk.StorageAccess
{
    public class SectorRegion
    {
        public long fromSector;
        public long toSector;
        public override string ToString()
        {
            return string.Format("{0}-{1}", fromSector, toSector);
        }
    }

    public interface IStorageIO : IDisposable
    {
        void Close();
        void Seek(long offset, SeekOrigin seekOrigin = SeekOrigin.Begin);
        void ReadBytes(byte[] data, int length);
        void WriteBytes(byte[] data, int length);
        List<SectorRegion> GetBadSectorMap();
        void ClearBadSectorMap();
        DiskInfo GetDiskInfo();
    }
}
