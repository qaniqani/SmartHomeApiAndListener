using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListenerWinForm.Properties;
using Model;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ListenerWinForm
{
    public partial class Form1 : Form
    {
        private MqttClient _client;

        private static readonly string HostName = Resources.mqtt_HOST_NAME;
        private static readonly string Username = Resources.mqtt_USERNAME;
        private static readonly string Password = Resources.mqtt_PASSWORD;
        private static readonly string Clientname = Resources.mqtt_CLIENTNAME;

        private static readonly string ServiceUsername = Resources.Service_Username;
        private static readonly string ServicePassword = Resources.Service_Password;

        private WebApi api;

        private delegate void SetTextCallback(MQTTResponse response);

        public Form1()
        {
            InitializeComponent();
            api = new WebApi("http://smart.nvisionsoft.net", ServiceUsername, ServicePassword);
            api.Login();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //GetTopics();
            disconnectToolStripMenuItem.Enabled = false;
            btnDisconnect.Enabled = false;
        }

        private void SetText(MQTTResponse response)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (lvListener.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                Invoke(d, response);
            }
            else
            {
                var message = Encoding.UTF8.GetString(response.Message);
                var split = message.Split('/');

                var item = new ListViewItem(response.Topic);
                item.Name = response.Topic;
                item.SubItems.Add(split[1]);
                item.SubItems.Add(response.QoSLevel.ToString());
                item.SubItems.Add(response.Retain.ToString());
                item.SubItems.Add(message);
                lvListener.Items.Insert(0, item);

                int count = lvListener.Items.Count;
                if (count > 50)
                    lvListener.Items.RemoveAt(50);
            }
        }

        private void GetTopics()
        {
            var result = api.Bloks();
            lvTopics.Items.Clear();
            foreach (var item in result)
            {
                var lvi = new ListViewItem(item.LREF.ToString());
                lvi.Tag = item;
                lvi.SubItems.Add(item.TOPIC);
                lvTopics.Items.Add(lvi);
            }
            lvTopics.Refresh();
        }

        private void refreshTopicListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTopics();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            if (lvTopics.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvTopics.SelectedItems)
                {
                    //MessageBox.Show(item.Tag + " - " + item.SubItems[1].Text);
                    var blok = item.Tag as BLOK;
                    var lvi = new ListViewItem(blok.LREF.ToString());
                    lvi.Name = blok.LREF.ToString();
                    lvi.Tag = blok;
                    lvi.SubItems.Add(blok.NAME);
                    lvi.SubItems.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));

                    if (!lvSubscribe.Items.ContainsKey(blok.LREF.ToString()))
                    {
                        Subscribe(blok);
                        lvSubscribe.Items.Add(lvi);
                    }
                }
                lvTopics.Focus();
            }
        }

        private void btnUnsubsribe_Click(object sender, EventArgs e)
        {
            if (lvSubscribe.SelectedItems.Count > 0)
            {
                var item = lvSubscribe.SelectedItems[0];
                var blok = item.Tag as BLOK;
                UnSubscribe(blok);
                if (lvSubscribe.Items.ContainsKey(blok.LREF.ToString()))
                {
                    lvSubscribe.Items.Remove(item);
                }
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void clearListenerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvListener.Items.Clear();
        }

        #region //MQTT Methods

        public bool Connect()
        {
            if (_client == null)
                _client = new MqttClient(IPAddress.Parse(HostName));

            if (!_client.IsConnected)
            {
                lblMQTTStatus.Text = "Connected";
                lblMQTTStatus.ForeColor = Color.Green;
                var result = (_client.Connect(Clientname, Username, Password).ToString() == "0" ? true : false);
                CreateReceviced();
                btnConnect.Enabled = false;
                connectToolStripMenuItem.Enabled = false;
                btnDisconnect.Enabled = true;
                disconnectToolStripMenuItem.Enabled = true;
                return result;
            }

            lblMQTTStatus.Text = "Disconnect";
            lblMQTTStatus.ForeColor = Color.Red;

            return false;
        }

        public bool Disconnect()
        {
            if (_client == null)
                _client = new MqttClient(IPAddress.Parse(HostName));

            if (_client.IsConnected)
            {
                _client.Disconnect();
                lvSubscribe.Items.Clear();

                lblMQTTStatus.Text = "Disconnect";
                lblMQTTStatus.ForeColor = Color.Red;

                btnConnect.Enabled = true;
                connectToolStripMenuItem.Enabled = true;
                btnDisconnect.Enabled = false;
                disconnectToolStripMenuItem.Enabled = false;

                lvListener.Items.Clear();
            }

            return false;
        }

        public bool Publish(string topic, string message)
        {
            if (_client == null)
                _client = new MqttClient(IPAddress.Parse(HostName));

            if (!_client.IsConnected)
                Connect();

            if (_client.IsConnected)
            {
                _client.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                return true;
            }

            return false;
        }

        public bool Subscribe(BLOK bloks)
        {
            //sistem tum bloklari takip etsin.
            if (_client == null)
                _client = new MqttClient(IPAddress.Parse(HostName));

            if (!_client.IsConnected)
                Connect();

            if (!_client.IsConnected) return false;

            _client.Subscribe(new[] {bloks.TOPIC + "/#"}, new[] {MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});

            return true;
        }

        public bool UnSubscribe(BLOK bloks)
        {
            //sistem tum bloklari takip etsin.
            if (_client == null)
                _client = new MqttClient(IPAddress.Parse(HostName));

            if (!_client.IsConnected)
                Connect();

            if (!_client.IsConnected) return false;

            _client.Unsubscribe(new[] {bloks.TOPIC + "/#"});

            return true;
        }

        public bool CreateReceviced()
        {
            if (_client.IsConnected)
            {
                _client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                return true;
            }

            return false;
        }

        public void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var messages = Encoding.UTF8.GetString(e.Message);

            //form.AddListener(response);
            if (!messages.Contains(Clientname) && !e.Topic.Contains("MeStatus"))
            {
                var response = new MQTTResponse
                {
                    Topic = e.Topic,
                    Retain = e.Retain,
                    Message = e.Message,
                    QoSLevel = e.QosLevel,
                    DupFlag = e.DupFlag
                };

                api.Log(response);
                SetText(response);
            }
            //cihaz kapanip acildiysa db'den eski durumuna bak ve tekrar gonder.
            if (e.Topic.Contains("MeStatus"))
            {
                //evin cihazlarini listele
                var devices = api.GetHomeStatus(messages.Split('/')[0]);
                if (!devices.Any()) return;

                //ilgili cihaza durumunu tekrar gonder
                foreach (var item in devices)
                {
                    string topic = string.Format("{0}/{1}", item.TOPIC, item.CLIENTID);
                    var message = string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}",
                        item.TOPIC,
                        item.CLIENTID,
                        item.ROOMREF,
                        item.DEVICEREF,
                        item.PINNR,
                        item.DEVICETYPE,
                        item.VALUE,
                        Clientname);

                    _client.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                        true);
                }
            }
            else
            {
                try
                {
                    var url = messages.Split('/');
                    var topic = url[0];
                    var clientId = url[1];
                    var roomRef = Convert.ToInt32(url[2]);
                    var deviceRef = Convert.ToInt32(url[3]);
                    var pinNr = url[4];
                    var deviceType = url[5];
                    var value = Convert.ToInt32(url[6]);
                    var userName = url[7];

                    api.SetDeviceSetting(roomRef, deviceRef, value);
                }
                catch
                {
                    // ignored
                }
            }

        }
        #endregion
    }
}