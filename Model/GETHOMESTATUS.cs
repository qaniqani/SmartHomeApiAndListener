using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class GETHOMESTATUS
    {
        public string TOPIC { get; set; }
        public string CLIENTID { get; set; }
        public int ROOMREF { get; set; }
        public int DEVICEREF { get; set; }
        public string PINNR { get; set; }
        public string DEVICETYPE { get; set; }
        public int VALUE { get; set; }
    }
}