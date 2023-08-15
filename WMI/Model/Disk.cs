using System;

namespace WMI.Model
{
    public class Disk
    {
        public string DiskName { get; set; }
        public UInt64 VolumeSize { get; set; }
        public UInt64 FreeSpace { get; set; }
    }
}
