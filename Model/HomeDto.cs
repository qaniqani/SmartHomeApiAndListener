using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class HomeDto
    {
        public int Lref { get; set; }
        public int BlokRef { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
