using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RecoverDisk.StorageAccess
{
    public class DiskImageIO : IStorageIO
    {
        readonly FileStream _filestream;
        protected DiskInfo diskInfo;

        public DiskImageIO(DiskInfo dinfo)
        {
            diskInfo = dinfo;
            _filestream = new FileStream(dinfo.FileName, FileMode.Open, FileAccess.ReadWrite);
        }

        public DiskInfo GetDiskInfo()
        {
            return diskInfo;
        }

        public void Close()
        {
            _filestream.Close();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _filestream.Dispose();
        }

        public void Seek(long offset, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            _filestream.Seek(offset, seekOrigin);
        }

        public void ReadBytes(byte[] data, int length)
        {
            _filestream.Read(data, 0, length);
        }

        public void WriteBytes(byte[] data, int length)
        {
            _filestream.Write(data, 0, length);
        }

        public List<SectorRegion> GetBadSectorMap()
        {
            return new List<SectorRegion>(); // empty list
        }

        public void ClearBadSectorMap()
        {

        }

    }
}
