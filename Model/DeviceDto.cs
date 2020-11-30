using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class DeviceDto
    {
        public int Lref { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string BetweenValue { get; set; }
        public string PinNr { get; set; }
        public string DevicePicture { get; set; }
        public int SequenceNr { get; set; }
        public int Value { get; set; }
    }
}