using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RecoverDisk.StorageAccess
{
    public class DiskIO : IStorageIO
    {
        #region Const

        int SectorSize = 512;

        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const uint CREATE_NEW = 1;
        const uint CREATE_ALWAYS = 2;
        const uint OPEN_EXISTING = 3;

        #endregion

        readonly SafeFileHandle _filestream;
        Dictionary<long, bool> badSectorMap;
        long lastOffset;
        const int READ_OK = 1;
        DiskInfo diskInfo;
        
        public DiskInfo GetDiskInfo()
        {
            return diskInfo;
        }

        public DiskIO(DiskInfo dinfo)
        {
            diskInfo = dinfo;
            SectorSize = dinfo.BytesPerSector;
            _filestream = NativeMethods.CreateFile(dinfo.FileName, GENERIC_READ, 3, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (_filestream.IsInvalid) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            ClearBadSectorMap();
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
            long newptr = 0;
            if (offset % SectorSize != 0) throw new Exception("Seek Error: Offset should be multiple of media SectorSize " + SectorSize);
            NativeMethods.SetFilePointerEx(_filestream, offset, ref newptr, (uint)seekOrigin);
            lastOffset = offset;
        }

        public void ReadBytes(byte[] data, int length)
        {
            int res = 0;
            int readcount;
            if (length % SectorSize != 0)
            {
                int newlen = length + SectorSize - length % SectorSize;
                byte[] tmpbuff = new byte[newlen];
                res = NativeMethods.ReadFile(_filestream, data, length, out readcount, IntPtr.Zero);
                Array.Copy(tmpbuff, data, length);
            }
            else
                res = NativeMethods.ReadFile(_filestream, data, length, out readcount, IntPtr.Zero);
            if (res == READ_OK)
                lastOffset += length;
            else
            {
                // bad sectors detected. read one by one and update map
                long cursect = lastOffset / SectorSize;
                byte[] tmpdata = new byte[SectorSize];
                for (int i = 0; i < length; i += SectorSize, cursect++)
                {
                    Seek(lastOffset);
                    res = NativeMethods.ReadFile(_filestream, tmpdata, SectorSize, out readcount, IntPtr.Zero);
                    int copylen = SectorSize;
                    if ((i + SectorSize) > length)
                        copylen = length - i;
                    if (res == READ_OK)
                        Array.Copy(tmpdata, 0, data, i, copylen);
                    else
                    {
                        badSectorMap[cursect] = true;
                        //Array.Copy(tmpdata, 0, data, i, SectorSize);
                        Array.Clear(data, i, copylen);
                    }
                    lastOffset += SectorSize;
                }
                Seek(lastOffset);
            }
        }

        public void WriteBytes(byte[] data, int length)
        {
            throw new NotImplementedException();
        }

        public List<SectorRegion> GetBadSectorMap()
        {
            long[] keys = badSectorMap.Keys.ToArray();
            Array.Sort(keys);
            SectorRegion region = null;
            List<SectorRegion> res = new List<SectorRegion>();
            foreach (long key in keys)
            {
                if (region != null && key == region.toSector + 1)
                    region.toSector = key;
                else
                {
                    region = new SectorRegion();
                    region.fromSector = region.toSector = key;
                    res.Add(region);
                }
            }
            return res;
        }

        public void ClearBadSectorMap()
        {
            badSectorMap = new Dictionary<long, bool>();
        }

    }

}
