using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Model
{
    public class HomeRoomsDto
    {
        public HomeDto Home { get; set; }
        public IEnumerable<RoomDto> Rooms { get; set; }
    }
}