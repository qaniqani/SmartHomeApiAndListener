using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;

namespace Model
{
    public class RoomDeviceValueDto
    {
        public int Lref { get; set; }
        public int RoomRef { get; set; }
        public int DeviceRef { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string BetweenValue { get; set; }
        public string PinNr { get; set; }
        public int Value { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}