using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class ROOMDEVICEVALUE
    {
        [Key]
        public int LREF { get; set; }
        [Required]
        public int DEVICEREF { get; set; }
        [Required]
        public int ROOMREF { get; set; }
        [Required]
        public int USERREF { get; set; }
        [Required]
        public int VALUE { get; set; }
        [Required]
        public DateTime UPDATETIME { get; set; }
        [Required]
        public int STATUS { get; set; }
    }
}