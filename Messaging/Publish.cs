using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Messaging
{
    public class Publish
    {
        private string _host, _username, _password, _clientName;
        public Publish(string host, string userName, string password, string clientName)
        {
            _host = host;
            _username = userName;
            _password = password;
            _clientName = clientName;
        }

        public void SendMessage(string value)
        {
            MqttClient client = new MqttClient(IPAddress.Parse(_host));

            var result = client.Connect(_clientName, _username, _password).ToString();
            // publish a message on "/home/temperature" topic with QoS 2 
            if (result == "0")
            {
                client.Publish("ABlok", Encoding.UTF8.GetBytes(value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            }
        }
    }
}
