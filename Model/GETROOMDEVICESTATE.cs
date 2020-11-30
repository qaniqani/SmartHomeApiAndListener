using System;

namespace Model
{
    public class GETROOMDEVICESTATE
    {
        public int LREF { get; set; }
        public int DEVICEREF { get; set; }
        public int VALUE { get; set; }
        public DateTime UPDATETIME { get; set; }
        public string DEVICENAME { get; set; }
        public string DEVICETYPE { get; set; }
        public string BETWEENVALUE { get; set; }
        public string PINNR { get; set; }
    }
}