
namespace Model
{
    public class MQTTHubResponse
    {
        public bool DupFlag { get; set; }
        public string Message { get; set; }
        public int QoSLevel { get; set; }
        public bool Retain { get; set; }
        public string Topic { get; set; }
    }
}