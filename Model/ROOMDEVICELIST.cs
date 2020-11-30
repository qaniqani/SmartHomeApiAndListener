using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class ROOMDEVICELIST
    {
        [Key]
        public int LREF { get; set; }
        public string HOMEROOMNAME { get; set; }
        public string DEVICENAME { get; set; }
        public int DEVICEREF { get; set; }
        public int ROOMREF { get; set; }
        public int USERREF { get; set; }
        public int VALUE { get; set; }
        public DateTime UPDATETIME { get; set; }
        public int STATUS { get; set; }
    }
}