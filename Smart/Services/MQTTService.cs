using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using Model;
using SmartApi.Providers;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Smart.Services
{
    public class MQTTService
    {
        private static readonly string _userName;
        private static readonly string _password;

        private static readonly string HostName = WebConfigurationManager.AppSettings["mqtt.HOST_NAME"];
        private static readonly string Username = WebConfigurationManager.AppSettings["mqtt.USERNAME"];
        private static readonly string Password = WebConfigurationManager.AppSettings["mqtt.PASSWORD"];
        private static readonly string Clientname = WebConfigurationManager.AppSettings["mqtt.CLIENTNAME"];

        public string _webUsername = "WebUser";

        private readonly SmartService _service = new SmartService(_userName, _password, Tool.GetConnectionString());
        private static MqttClient _client;
        private IHubContext _context = GlobalHost.ConnectionManager.GetHubContext<MqttHub>();

        public void Publish(string topic, string message)
        {
            if (_client == null)
                _client = new MqttClient(IPAddress.Parse(HostName));

            if (!_client.IsConnected)
            {
                _client.Connect(Clientname, Username, Password);
                _client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            }

            if (_client.IsConnected)
                _client.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }

        public void Subscribe(string topic)
        {
            //sistem tum bloklari takip etsin.
            if (_client == null)
                _client = new MqttClient(IPAddress.Parse(HostName));

            if (!_client.IsConnected)
            {
                _client.Connect(Clientname, Username, Password);
                _client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            }

            if (!_client.IsConnected) return;

            _client.Subscribe(new[] { topic + "/#" }, new[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        public void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string messages = Encoding.UTF8.GetString(e.Message);
            var response = new MQTTHubResponse
            {
                Topic = e.Topic,
                Retain = e.Retain,
                Message = messages,
                QoSLevel = e.QosLevel,
                DupFlag = e.DupFlag
            };

            _context.Clients.All.MQTTReceived(response);
        }
    }
}