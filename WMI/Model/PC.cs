using System.Collections.Generic;

namespace WMI.Model
{
    public class PC
    {
        public string PcInfo { get; set; }
        public List<Disk> Disks { get; set; }
        public List<string> PcItems { get; set; }
    }
}
