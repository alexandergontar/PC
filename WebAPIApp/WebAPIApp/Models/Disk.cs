using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Models
{
    public class Disk
    {
        [Key]
        public int Id { get; set; }
        public string DiskName { get; set; }
        public UInt64 VolumeSize { get; set; }
        public UInt64 FreeSpace { get; set; }
    }
}
