using Model;
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
    public class Subscribe
    {
        private string _host, _username, _password, _clientName;
        public Subscribe(string host, string userName, string password, string clientName)
        {
            _host = host;
            _username = userName;
            _password = password;
            _clientName = clientName;
        }

        public void Subscribes()
        {
            var client = new MqttClient(IPAddress.Parse(_host));
            // register to message received 
            var result = client.Connect(_clientName, _username, _password).ToString();
            if (result == "0")
            {
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                // subscribe to the topic "/home/temperature" with QoS 2 
                client.Subscribe(new string[] {"ABlok"}, new byte[] {MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});
            }
        }

        public void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = new MQTTResponse
            {
                DupFlag = e.DupFlag,
                Message = e.Message,
                QoSLevel = e.QosLevel,
                Retain = e.Retain,
                Topic = e.Topic
            };
        }
    }
}
