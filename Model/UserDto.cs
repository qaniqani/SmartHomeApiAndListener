using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class UserDto
    {
        public int Lref { get; set; }
        public string Topic { get; set; }
        public string HomeClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public int SmartHomeStatus { get; set; }
        public int UserType { get; set; }
    }
}