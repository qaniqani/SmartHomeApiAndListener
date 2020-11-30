using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Model;
using Smart.Services;

namespace Smart
{
    [HubName("mqtt")]
    public class MqttHub : Hub
    {
        MQTTService mqtt = new MQTTService();

        public void Hello()
        {
            //var user = service.GetUser();
            Clients.All.hello("selam");
        }

        public void Send()
        {
            Clients.All.SendMessage();
        }
        public void MQTTReceived(MQTTHubResponse response)
        {
            Clients.All.Send(response);
        }

        public void MQTTSend(string command)
        {
            var com = command.Split('/');
            var topic = string.Format("{0}/{1}", com[0], com[1]);
            mqtt.Publish(topic, command);
        }
    }
}