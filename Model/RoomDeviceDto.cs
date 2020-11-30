using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Model
{
    public class RoomDeviceDto
    {
        public RoomDto Room { get; set; }
        public IEnumerable<DeviceDto> Devices { get; set; } 
    }
}