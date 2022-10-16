using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;
using System.IO;

namespace RecoverDisk.StorageAccess
{
    public class DiskInfo
    {
        public string Model { get; set; } = null;
        public string Type { get; set; } = null;
        public string SerialNumber { get; set; } = null;
        public string FileName { get; set; } = null;
        public string Description { get; set; } = null;
        public string InterfaceType { get; set; } = null;
        public string MediaType { get; set; } = null;
        public string SizeString { get; set; } = null;

        public string[] Properties { get; set; } = null;

        public ulong TotalSectors { get; set; } = 0;
        public ulong TotalSize { get; set; } = 0;

        public int BytesPerSector { get; set; } = 0;
        public int PartitionCount { get; set; } = 0;

        public static DiskInfo FromImageFile(string filename)
        {
            DiskInfo dinfo = new DiskInfo();
            dinfo.FileName = filename;
            dinfo.Model = dinfo.Type = "Disk Image File";
            dinfo.BytesPerSector = 1024;
            dinfo.TotalSize = (ulong)(new FileInfo(filename).Length);
            updateParams(dinfo);

            return dinfo;
        }

        static void updateParams(DiskInfo di)
        {
            di.TotalSectors = di.TotalSize / (ulong)di.BytesPerSector;
            di.SizeString = string.Format("{0:0.00}GB", di.TotalSize / 1000000000.0);
        }

        public static DiskInfo[] GetAllDrives()
        {
            List<DiskInfo> hdCollection = new List<DiskInfo>();

            ManagementObjectSearcher searcher = new
                ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                if (wmi_HD["Size"] == null)
                    continue; // probably unmounted sd card
                DiskInfo di = new DiskInfo();
                di.Model = wmi_HD["Model"].ToString();
                di.Type = wmi_HD["InterfaceType"].ToString();
                di.FileName = wmi_HD["DeviceID"].ToString();
                di.BytesPerSector = int.Parse(wmi_HD["BytesPerSector"].ToString());
                List<string> props = new List<string>();
                foreach (var prop in wmi_HD.Properties)
                    if (prop.Value != null)
                        props.Add(string.Format("{0}: {1}", prop.Name, prop.Value.ToString()));
                di.Properties = props.ToArray();
                di.TotalSize = (ulong)wmi_HD["Size"];
                updateParams(di);
                hdCollection.Add(di);
            }

            searcher = new
                ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                foreach (DiskInfo hd in hdCollection)
                {
                    if (wmi_HD["Tag"].ToString() == hd.FileName)
                    {
                        if (wmi_HD["SerialNumber"] == null)
                            hd.SerialNumber = "None";
                        else
                            hd.SerialNumber = wmi_HD["SerialNumber"].ToString();
                    }
                }
            }

            return hdCollection.ToArray();
        }
    }
}
