
namespace Model
{
    public class MQTTResponse
    {
        public bool DupFlag { get; set; }
        public byte[] Message { get; set; }
        public byte QoSLevel { get; set; }
        public bool Retain { get; set; }
        public string Topic { get; set; }
    }
}