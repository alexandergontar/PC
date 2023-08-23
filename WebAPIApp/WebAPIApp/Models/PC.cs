using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Models
{
    public class PC
    {
        [Key]
        public int Id { get; set; }
        public List<Disk> Disks { get; set; }

       // [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string PcItems { get; set; }
    }
}
