using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class GETHOMEDETECTOR
    {
        public int LREF { get; set; }
        public int ROOMREF { get; set; }
        public int DEVICEREF { get; set; }
        public int VALUE { get; set; }
        public DateTime UPDATETIME { get; set; }
        public string DEVICENAME { get; set; }
        public string DEVICETYPE { get; set; }
        public string BETWEENVALUE { get; set; }
        public string PINNR { get; set; }
    }
}