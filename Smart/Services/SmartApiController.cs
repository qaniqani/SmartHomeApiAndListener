using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Model;
using SmartApi.Providers;

namespace Smart.Services
{
    [RoutePrefix("api")]
    public class SmartApiController : ApiController
    {
        private static string _userName = "";
        private static string _password = "";

        private SmartService service = new SmartService(_userName, _password, Tool.GetConnectionString());

        [HttpGet]
        [Route("login")]
        [ResponseType(typeof(IEnumerable<USER>))]
        public IHttpActionResult Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = service.UserLogin(username, password);
                if (user != null)
                {
                    HttpContext.Current.Session["user"] = user;

                    return Ok(user);
                }

                return NotFound();
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("AdminLogin")]
        [ResponseType(typeof(IEnumerable<USER>))]
        public IHttpActionResult AdminLogin(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = service.AdminLogin(username, password);
                if (user != null)
                {
                    HttpContext.Current.Session["admin"] = user;

                    return Ok(user);
                }

                return NotFound();
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("bloks")]
        [ResponseType(typeof(IEnumerable<BLOK>))]
        public IHttpActionResult Bloks(string username, string password)
        {
            _userName = username;
            _password = password;

            var blok = service.BlokActiveSelect();
            return Ok(blok);
        }

        [HttpGet]
        [Route("homes")]
        [ResponseType(typeof(IEnumerable<HOME>))]
        public IHttpActionResult Homes(string username, string password)
        {
            _userName = username;
            _password = password;

            var home = service.HomeActiveSelect();
            return Ok(home);
        }

        [HttpGet]
        [Route("home/{clientRef}/room")]
        [ResponseType(typeof(IEnumerable<HomeRoomsDto>))]
        public IHttpActionResult HomeRooms(string clientRef, string username, string password)
        {
            _userName = username;
            _password = password;

            var rooms = service.RoomList(clientRef);
            return Ok(rooms);
        }

        [HttpGet]
        [Route("home/{clientRef}/room/{roomRef}/device")]
        [ResponseType(typeof (IEnumerable<RoomDeviceDto>))]
            public IHttpActionResult RoomDevice(string clientRef, int roomRef, string username, string password)
            {
                _userName = username;
                _password = password;

                var roomDevices = service.RoomDevices(clientRef, roomRef);
                return Ok(roomDevices);
            }

        [HttpGet]
        [Route("home/{clientRef}")]
        [ResponseType(typeof(IEnumerable<GETHOMESTATUS>))]
        public IHttpActionResult GetHomeStatus(string clientRef, string username, string password)
        {
            _userName = username;
            _password = password;

            var homeStatus = service.GetHomeStatus(clientRef);
            return Ok(homeStatus);
        }

        [HttpGet]
        [Route("log")]
        public IHttpActionResult Log(string topic, string clientId, string roomRef, string deviceRef, string pinNr, string deviceType, string value, string clientName, string qoSLevel, string retain, string username, string password)
        {
            _userName = username;
            _password = password;
            //log/ABlok/ABlok/7584a0766efa4f09a62ed5/7/5/9/CarDoor/150/TT3/1/True?username=A1-001&password=19881988
            var message = string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}", 
                topic, 
                clientId, 
                roomRef, 
                deviceRef, 
                pinNr, 
                deviceRef, 
                value, 
                clientName);
            var response = new MQTTResponse
            {
                Topic = topic,
                Message = System.Text.Encoding.UTF8.GetBytes(message),
                QoSLevel = (byte)Convert.ToInt32(qoSLevel),
                Retain = Convert.ToBoolean(retain)
            };

            service.AddLog(response);
            return Ok();
        }

        [HttpGet]
        [Route("SetSetting/{roomRef}/{deviceRef}/{value}")]
        [ResponseType(typeof(IEnumerable<ROOMDEVICEVALUE>))]
        public IHttpActionResult SetDeviceSetting(int roomRef, int deviceRef, int value, string username, string password)
        {
            _userName = username;
            _password = password;

            var status = service.SetDeviceSetting(roomRef, deviceRef, value);
            return Ok(status);
        }
    }
}
