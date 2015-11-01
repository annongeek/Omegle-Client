using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace Omegle_Client
{
    class OmegleLibrary
    {
        private event WebExceptionEvent WebException;
        private Color _chatColor;
        private FormMain _form;
        private string[] serverList;
        private string[] antiNudeServerList;
        private List<string> Interests = new List<string>();
        protected Timer updateTimer;
        private bool isConnected = false;
        private string _Id;
        private string _Server;
        private string _Language;
        private bool _Throws;
        private status _Status;
        public enum status
        {
            Stopped,
            Started
        }
        public OmegleLibrary(FormMain form,Color chatColor)
        {
           
            _form = form;
            _chatColor = chatColor;
            GetServers();
            GetAccess();
            _Id = string.Empty;
            updateTimer = new Timer(TimerCallBack);
            _Status = status.Stopped;
            isConnected = false;
            _Throws = true;
            _Server = serverList[0];
        }

        public void Reconnect()
        {
            Disconnect();
            Connect();
        }

        public void Connect()
        {
            GetID();
            Start();
            isConnected = true;
        }

        public void Disconnect()
        {
            Stop();
            SendDisconnect();
            _Id = string.Empty;
            isConnected = false;
        }

        private void Start()
        {
            _Status = status.Started;
            updateTimer.Change(0, Timeout.Infinite);
        }

        private void Stop()
        {
            _Status = status.Stopped;
            updateTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void Listen()
        {
            PostSubmitter eventlisten = new PostSubmitter();
            eventlisten.Url = String.Format("http://{0}.omegle.com/events", _Server);
            eventlisten.PostItems.Add("id", _Id);
            eventlisten.Type = PostSubmitter.PostTypeEnum.Post;
            eventlisten.WebExceptionEvent += WebException;
            Parse(eventlisten.Post());
        }

        private void Parse(string response)
        {
             if (response == null) return;
            JArray events;
            try
            {
                events = JsonConvert.DeserializeObject<JArray>(response);
            }
            catch
            {
                return;
            }

            if (events != null)
            {
                foreach (JToken ev in events)
                {
                    string event_ = ev[0].ToString();
                    switch (event_)
                    {
                        case "connected":
                            isConnected = true;
                            _form.Chat("Status: ", Color.Gray, FontStyle.Bold, false);
                            _form.Chat("Connected", Color.Green, FontStyle.Regular, true);
                            break;
                        case "strangerDisconnected":
                            _form.Chat("Stranger Disconnected", Color.Red, FontStyle.Bold, true);
                            Reconnect();
                            break;
                        case "gotMessage":
                             _form.Chat("Stranger: ", _chatColor, FontStyle.Bold, false);
                            _form.Chat(ev[1].ToString(), Color.Black, FontStyle.Regular, true);
                            break;
                        case "waiting":
                             _form.Chat("Status: ", Color.Gray, FontStyle.Bold, false);
                            _form.Chat("Waiting", Color.Blue, FontStyle.Regular, true);
                            break;
                        
                        case "identDigests":
                            break;
                        case "typing":
                             _form.Chat("Stranger: ", Color.Red, FontStyle.Bold, false);
                            _form.Chat("Started Typing", Color.Blue, FontStyle.Regular, true);
                            break;
                        case "stoppedTyping":
                            _form.Chat("Stranger: ", Color.Red, FontStyle.Bold, false);
                            _form.Chat("Stop Typing", Color.Blue, FontStyle.Regular, true);
                            break;
                        case "count":
                            break;
                        case "recaptchaRequired":
                            break;
                        case "recaptchaRejected":
                            break;
                        case "commonLikes":
                            break;
                        case "suggestSpyee":
                            break;
                        case "error":
                            break;
                        case "spyMessage":
                            break;
                        case "spyTyping":
                            break;
                        case "spyStoppedTyping":
                            break;
                        case "spyDisconnected":
                            break;
                        case "question":
                            break;
                        default:
                       
                            break;
                    }
                }
            }
        }

        protected void TimerCallBack(object info)
        {
            updateTimer.Change(Timeout.Infinite, Timeout.Infinite);
            Listen();
            if (_Status == status.Started)
                updateTimer.Change(1000, 1000);
        }

        #region Topic Post String
        private string GetTopicPostString()
        {
            int numTopics = this.Interests.Count;
            var sbTopics = new StringBuilder();
            for (int i = 0; i < numTopics; i++)
            {
                sbTopics.AppendFormat("\"{0}\"", this.Interests[i]);
                if (i < numTopics - 1)
                {
                    sbTopics.Append(",");
                }
            }
            return "[" + sbTopics.ToString() + "]";
        }
        #endregion

        #region Connection Made
        private void GetAccess()
        {
            PostSubmitter sendPost = new PostSubmitter();
            sendPost.Url = string.Format("http://wawadmin.omegle.com/redir/hometest?track=mon-videoy-adcm-y");
            sendPost.Type = PostSubmitter.PostTypeEnum.Get;
            var strStatus = sendPost.Post();
        }
        private void GetServers()
        {
            PostSubmitter sendPost = new PostSubmitter();
            sendPost.Url = string.Format("http://omegle.com/status");
            sendPost.Type = PostSubmitter.PostTypeEnum.Get;
            var strStatus = sendPost.Post();
            var dictStatus = JsonConvert.DeserializeObject<dynamic>(strStatus);
            var listServers = new List<string>();
            var listAntiNudeServers  = new List<string>();
            foreach (string server in dictStatus.servers)
                listServers.Add(server.Split('.')[0]);
            foreach (string server in dictStatus.antinudeservers)
                listAntiNudeServers.Add(server.Split('.')[0]);
            serverList = listServers.ToArray<string>();
            antiNudeServerList = listAntiNudeServers.ToArray<string>();
        }

        private void GetID()
        {
            PostSubmitter sendPost = new PostSubmitter();
            sendPost.Url = String.Format("http://{0}.omegle.com/start?rcs=1&spid=bf069a88b6dedc0cb9207c2413c703d0c890f6b65cf282613b108efd2b9c9b58&randid=SVZ75ZSW&group=unmon&lang=en&camera=%20", _Server);
            sendPost.Type = PostSubmitter.PostTypeEnum.Post;

            if (Interests.Count > 0)
                sendPost.Url += "&topics=" + GetTopicPostString();
            if (_Language != null)
                sendPost.Url += "&lang=" + _Language;
            if (!_Throws)
                sendPost.WebExceptionEvent += WebException;
           
            _Id = sendPost.Post();
            _Id = _Id.TrimStart('"');
            _Id = _Id.TrimEnd('"');
        }

        private string SendDisconnect()
        {
            PostSubmitter sendPost = new PostSubmitter();
            sendPost.Url = String.Format("http://{0}.omegle.com/disconnect", _Server);
            sendPost.PostItems.Add("id", _Id);
            sendPost.Type = PostSubmitter.PostTypeEnum.Post;

            if (!_Throws)
                sendPost.WebExceptionEvent += WebException;

            return sendPost.Post();
        }

        public void StartTyping()
        {
            PostSubmitter sendPost = new PostSubmitter();
            sendPost.Url = String.Format("http://{0}.omegle.com/typing", _Server);
            sendPost.PostItems.Add("id", _Id);
            sendPost.Type = PostSubmitter.PostTypeEnum.Post;
            if (!_Throws)
                sendPost.WebExceptionEvent += WebException;

            sendPost.Post();
        }

        public void StopTyping()
        {
            PostSubmitter sendPost = new PostSubmitter();
            sendPost.Url = String.Format("http://{0}.omegle.com/stoppedtyping", _Server);
            sendPost.PostItems.Add("id", _Id);
            sendPost.Type = PostSubmitter.PostTypeEnum.Post;
            if (!_Throws)
                sendPost.WebExceptionEvent += WebException;
        }

        public string SendMessageRaw(string message)
        {
            //Send Message format: [url]http://bajor.omegle.com/send?id=Id&msg=MSG[/url]

            PostSubmitter sendPost = new PostSubmitter();
            sendPost.Url = String.Format("http://{0}.omegle.com/send", _Server);
            sendPost.PostItems.Add("id", _Id);
            sendPost.PostItems.Add("msg", message);
            sendPost.Type = PostSubmitter.PostTypeEnum.Post;
            if (!_Throws)
                sendPost.WebExceptionEvent += WebException;

            return sendPost.Post();
        }

        public string SendMessage(string message)
        {
            return SendMessageRaw(message);
        }
        #endregion
    }

}
