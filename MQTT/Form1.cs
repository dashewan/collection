using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Protocol;
using MQTTnet.Server;
using MQTTnet.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client;
using System.Net;
using MQTTnet.Client.Receiving;
using Newtonsoft.Json;

namespace MQTT
{
    public partial class Form1 : Form
    {
        private IMqttServer mqttServer = null;
        private IMqttClient mqttClient = null;


        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                // 创建MQTT服务配置的构建器
                MqttServerOptionsBuilder optionsBuilder = new MqttServerOptionsBuilder();
                optionsBuilder.WithDefaultEndpointBoundIPAddress(IPAddress.Parse("127.0.0.1"));
                optionsBuilder.WithDefaultEndpointPort(3333);
                // 为构建器添加连接验证的处理过程
                optionsBuilder.WithConnectionValidator(context =>
                {
                    // 验证ClientID的长度
                    if (context.ClientId.Length < 2)
                    {
                        context.ReasonCode = MqttConnectReasonCode.ClientIdentifierNotValid;
                        return;
                    }
                    // 验证用户名和密码
                    if (context.Username != "User01" || context.Password != "123456")
                    {
                        context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                        return;
                    }
                    // 标记当前连接请求的ReasonCode为Success
                    context.ReasonCode = MqttConnectReasonCode.Success;
                });
                // 利用MqttFactory创建MQTT服务器
                mqttServer = new MqttFactory().CreateMqttServer();
                mqttServer.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(new Action<MqttApplicationMessageReceivedEventArgs>(MqttApplicationMessageReceived));
                mqttServer.ClientConnectedHandler = new MqttServerClientConnectedHandlerDelegate(new Action<MqttServerClientConnectedEventArgs>(MqttClientConnected));
                mqttServer.ClientDisconnectedHandler = new MqttServerClientDisconnectedHandlerDelegate(new Action<MqttServerClientDisconnectedEventArgs>(MqttServerClientDisconnected));
               // mqttServer.ClientSubscribedTopicHandler = new MqttServerClientSubscribedHandlerDelegate(new Action<MqttServerClientSubscribedTopicEventArgs>(MqttClientSubscribed));
                // 采用异步方式启动服务(使用服务配置构建器创建的对象)
                mqttServer.StartAsync(optionsBuilder.Build());
                listBox1.Items.Add("MQTT服务启动成功，绑定3333端口");
                DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DataLoad()
        {
            int time=timerSend.Interval/1000;
            Random rd = new Random();
            rd.Next(1, 10);
            OperateData operateData = new OperateData()
            {
                StartDateTime = DateTime.Now.AddSeconds(-time),
                EndDateTime = DateTime.Now,
                Period= time,
                SupplyCount=100,
                ReadCount =80,
                MulIDCount =20,
                SortCount =80,
                ExceptionCount =20,
            };
            string operateJson=JsonConvert.SerializeObject(operateData);
            this.txtOperateJson.Text = operateJson;
            ExceptionData exceptionData = new ExceptionData()
            {
                StartDateTime = DateTime.Now.AddSeconds(-time),
                EndDateTime = DateTime.Now,
                Period = time,
              
            };
            exceptionData.ExceptionCode[401] = 30;
            string exceptionJson = JsonConvert.SerializeObject(exceptionData);
            this.txtExcetpionJson.Text = exceptionJson;
            ChuteData chute = new ChuteData()
            {
                StartDateTime = DateTime.Now.AddSeconds(-time),
                EndDateTime = DateTime.Now,
                Period = time,

            };
            chute.Chutes =new Dictionary<string, int>();
            chute.Chutes["001"] = 20;
            chute.Chutes["002"] = 40;
            chute.Chutes["003"] = 80;
            chute.Chutes["005"] = 90;
            chute.Chutes["007"] = 20;
            string holeJson = JsonConvert.SerializeObject(chute);
            this.txtHoleJson.Text = holeJson;
        }
        private void MqttClientSubscribed(MqttServerClientSubscribedTopicEventArgs obj)
        {
            try
            {
                listBox1.Items.Add("客户端ID:" + obj.ClientId.ToString() + "订阅信息：" + obj.TopicFilter.ToString() );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void MqttServerClientDisconnected(MqttServerClientDisconnectedEventArgs obj)
        {
            try
            {
                listBox1.Items.Add("客户端ID:" +obj.ClientId.ToString() +"断开类型：" +obj.DisconnectType.ToString()+ " 断开连接");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MqttClientConnected(MqttServerClientConnectedEventArgs obj)
        {
            try
            {
                listBox1.Items.Add("客户端ID:"+obj.ClientId.ToString()+ "连接成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 mqttClient = new MqttFactory().CreateMqttClient();
                 MqttClientOptionsBuilder optionbuilder = new MqttClientOptionsBuilder();
                 //optionbuilder.WithClientId(Guid.NewGuid().ToString().ToUpper());
                optionbuilder.WithClientId("123456");
                optionbuilder.WithTcpServer("10.34.168.58", 3333);
                //optionbuilder.WithTcpServer("127.0.0.1", 3333);
                optionbuilder.WithCredentials("User01","123456");
                 MqttClientAuthenticateResult result=  mqttClient.ConnectAsync(optionbuilder.Build()).Result;
                 if (result.ResultCode.ToString() == "Success")
                {
                    label3.Text = "连接成功";
                    label3.ForeColor = Color.Green;
                }
                 //订阅主题
                var topics = new List<MqttTopicFilter>();
                topics.Add(new MqttTopicFilter() { Topic = "001/Operate" });
                mqttClient.SubscribeAsync(new MQTTnet.Client.Subscribing.MqttClientSubscribeOptions()
                {
                    TopicFilters = topics
                });
                //接收消息
                mqttClient.ApplicationMessageReceivedHandler=new MqttApplicationMessageReceivedHandlerDelegate(new Action<MqttApplicationMessageReceivedEventArgs>(MqttClinetApplicationMessageReceived));
            }
            catch (Exception ex)
            {
                label3.Text = "连接失败";
                label3.ForeColor = Color.Red;
                string str = ex.Message;
            }
        }

        private void MqttClinetApplicationMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            try
            {
                string text = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                string Topic = e.ApplicationMessage.Topic;
                string QoS = e.ApplicationMessage.QualityOfServiceLevel.ToString();
                string Retained = e.ApplicationMessage.Retain.ToString();
                listBox1.Items.Add("ClientTopic:" + Topic + "; QoS: " + QoS + "; Retained: " + Retained + ";");
                listBox1.Items.Add("ClientMsg: " + text);


            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// 接收消息触发事件
        /// </summary>
        /// <param name="e"></param>
        private  void MqttApplicationMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            try
            {
                string text = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                string Topic = e.ApplicationMessage.Topic;
                string QoS = e.ApplicationMessage.QualityOfServiceLevel.ToString();
                string Retained = e.ApplicationMessage.Retain.ToString();
                if (Topic== "Operate")
                {
                  OperateData operateData=  JsonConvert.DeserializeObject<OperateData>(text);
                }
                else if (Topic == "Excetpion")
                {

                    ExceptionData excetpionData = JsonConvert.DeserializeObject<ExceptionData>(text);
                }
                else if(Topic == "Chute")
                {
                    ChuteData holeData = JsonConvert.DeserializeObject<ChuteData>(text);
                }
                
                listBox1.Items.Add("ServerTopic:" + Topic + "; QoS: " + QoS + "; Retained: " + Retained + ";");
                listBox1.Items.Add("ServerMsg: " + text);
                e.ReasonCode = MqttApplicationMessageReceivedReasonCode.Success;

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log(txtOperateTopic.Text  ,txtOperateJson.Text);
          

        }
        public void log(string topic,string payload)
        {
            try
            {
                MQTTnet.Client.Publishing.MqttClientPublishResult Result = mqttClient.PublishAsync(new MqttApplicationMessage()
                {
                    Topic = topic,
                    Payload = Encoding.UTF8.GetBytes(payload)

                }).Result;
                listBox1.Items.Add("RMsg: " + Result.ReasonCode.ToString());
            }
            catch
            {
                closeConnect();
                MessageBox.Show("连接被迫断开");
            }
            
        }
        public void closeConnect()
        {
            if (mqttClient!=null&&mqttClient.IsConnected)
            {
                mqttClient.DisconnectAsync();
                label3.Text = "连接断开";
                label3.ForeColor = Color.Red;
                
            }
            if (timerSend.Enabled)
            {
                timerSend.Stop();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            closeConnect();
        }

        private void btnExcetionSend_Click(object sender, EventArgs e)
        {
            log(txtExcetpionTopic.Text, txtExcetpionJson.Text);
        }

        private void btnHoleSend_Click(object sender, EventArgs e)
        {
            log(txtHoleTopic.Text, txtHoleJson.Text);
        }

        private void btnTimeSend_Click(object sender, EventArgs e)
        {
            if (btnTimeSend.Text == "定时发送中")
            {
                btnTimeSend.Text = "定时发送";
                timerSend.Stop();
            }
            else
            {
                btnTimeSend.Text = "定时发送中";
                timerSend.Start();
            }
            
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            DataLoad();
            button3_Click(sender,e);
            btnExcetionSend_Click(sender, e);
            btnHoleSend_Click(sender, e);
        }
    }
}
