using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Model;

namespace ListenerWinForm
{
    public class WebApi
    {
        private static string _userName;
        private static string _password;
        private static string _domainAddress;

        private static CookieWebClient _webClient;

        public WebApi(string domainAddress, string adminUsername, string adminPassword)
        {
            _domainAddress = domainAddress;
            _userName = adminUsername;
            _password = adminPassword;

            _webClient = new CookieWebClient();
        }

        public void Login()
        {
            //api/login?username=A1-001&password=19881988
            //service login
            var login = _webClient.DownloadString(string.Format("{0}/api/AdminLogin?username={1}&password={2}", _domainAddress, _userName, _password));

            //service set cookie
            var getCookie =
                _webClient.CookieContainer.GetCookies(
                    new Uri(string.Format("{0}/api/AdminLogin?username={1}&password={2}", _domainAddress, _userName,
                        _password)));
            _webClient.CookieContainer.SetCookies(new Uri(_domainAddress), getCookie.ToString());
        }

        public IEnumerable<BLOK> Bloks()
        {
            //get bloks
            var response = _webClient.DownloadString(string.Format("{0}/api/bloks?username={1}&password={2}", _domainAddress, _userName, _password));

            var model =  JsonConvert.DeserializeObject<IEnumerable<BLOK>>(response);
            return model.Any() ? model : Enumerable.Empty<BLOK>();
        }

        public IEnumerable<GETHOMESTATUS> GetHomeStatus(string clientId)
        {
            //get bloks
            var response = _webClient.DownloadString(string.Format("{0}/api/home/{1}?username={2}&password={3}", 
                _domainAddress, 
                clientId,
                _userName, 
                _password));

            var model = JsonConvert.DeserializeObject<IEnumerable<GETHOMESTATUS>>(response);
            return model.Any() ? model : Enumerable.Empty<GETHOMESTATUS>();
        }

        public IEnumerable<ROOMDEVICEVALUE> SetDeviceSetting(int roomRef, int deviceRef, int value)
        {
            //get bloks
            var response = _webClient.DownloadString(string.Format("{0}/api/SetSetting/{1}/{2}/{3}/?username={4}&password={5}",
                _domainAddress,
                roomRef,
                deviceRef,
                value,
                _userName,
                _password));

            var model = JsonConvert.DeserializeObject<IEnumerable<ROOMDEVICEVALUE>>(response);
            return model.Any() ? model : Enumerable.Empty<ROOMDEVICEVALUE>();
        }

        public void Log(MQTTResponse response)
        {

            //get bloks
            var message = Encoding.UTF8.GetString(response.Message).Split('/');
            Debug.Write(message);
            //ABlok/7584a0766efa4f09a62ed5/1/4/9/Temperature/5/A1-001
            //0-1 topic, : ABlok/7584a0766efa4f09a62ed5
            //1 clientId, : 7584a0766efa4f09a62ed5 
            //2 roomRef, : 1
            //3 deviceRef, : 4
            //4 pinNr, : 9
            //5 deviceRef, : Temperature
            //6 value, : 5
            //7 clientName :A1-001
            try
            {
                var url = string.Format(@"{0}/api/log/?topic={1}&clientId={2}&roomRef={3}&deviceRef={4}&pinNr={5}&deviceType={6}&value={7}&clientName={8}&qoSLevel={9}&retain={10}&username={11}&password={12}",
                _domainAddress,
                response.Topic,
                message[1],
                message[2],
                message[3],
                message[4],
                message[5],
                message[6],
                message[7],
                response.QoSLevel,
                response.Retain,
                _userName,
                _password);
                _webClient.DownloadString(url);
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class CookieWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; private set; }

        /// <summary>
        /// This will instanciate an internal CookieContainer.
        /// </summary>
        public CookieWebClient()
        {
            this.CookieContainer = new CookieContainer();
        }

        /// <summary>
        /// Use this if you want to control the CookieContainer outside this class.
        /// </summary>
        public CookieWebClient(CookieContainer cookieContainer)
        {
            this.CookieContainer = cookieContainer;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request == null) return base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            return request;
        }
    }
}
