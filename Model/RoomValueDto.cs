using System.Collections.Generic;

namespace Model
{
    public class RoomValueDto
    {
        public RoomDto Room { get; set; }
        public IEnumerable<RoomDeviceValueDto> DeviceValue { get; set; }
    }
}