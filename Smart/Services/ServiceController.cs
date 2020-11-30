using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using Model;
using SmartApi.Providers;
using System.Web.Configuration;
using Microsoft.AspNet.SignalR;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Smart.Services
{
    [RoutePrefix("api")]
    public class ServiceController : ApiController
    {
        private static string _userName = "";
        private static string _password = "";

        private SmartService service = new SmartService(_userName, _password, Tool.GetConnectionString());
        private MQTTService mqtt = new MQTTService();

        public ServiceController()
        {

        }

        [HttpGet]
        [Route("{topic}/{clientRef}/{roomRef}/{deviceRef}/{pinNr}/{deviceType}/{value}")]
        [ResponseType(typeof(IEnumerable<RoomDeviceDto>))]
        public IHttpActionResult ServiceRequest(
            string topic, //ABlok
            string clientRef, //xxxxxxx
            int roomRef, //1
            int deviceRef, //2
            string pinNr, //13
            string deviceType, //digitalWrite
            int value, //0-1
            string userName, //xxx
            string password) //xxx
        {
            _userName = userName;
            _password = password;

            var message = string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}", topic, clientRef, roomRef, deviceRef, pinNr, deviceType, value, userName);

            //db'de cihazin son halini kaydet
            service.SetDeviceSetting(roomRef, deviceRef, value);

            //gelen istegi logla
            #region Add Log
            var response = new MQTTResponse
            {
                Topic = topic,
                DupFlag = false,
                Message = Encoding.UTF8.GetBytes(message),
                QoSLevel = MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                Retain = false
            };
            service.AddLog(response);
            #endregion

            //gelen istegi cihaza gonder

            mqtt.Publish(topic, message);

            return Ok();
        }

        [HttpGet]
        [Route("Start")]
        public IHttpActionResult Start()
        {
            var blok = service.BlokActiveSelectService();
            foreach (var item in blok)
            {
                mqtt.Subscribe(item.TOPIC);
            }
            return Ok("Ok");
        }

        [HttpGet]
        [Route("Check")]
        [ResponseType(typeof(string))]
        public IHttpActionResult Check()
        {
            //servisin calisip calismadigini kontrol et.
            return Ok("Ok");
        }
    }
}