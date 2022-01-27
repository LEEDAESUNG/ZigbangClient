using Newtonsoft.Json.Linq;
using SimpleUdp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace Movill
{
    public partial class Form1 : Form
    {
        static UdpEndpoint udpServer;
        CommonUtil MyUtil = new CommonUtil();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MyUtil.FileLogger("[Movill Client] 프로그램 시작");

            CConfig.apt_idx = Int32.Parse(MyUtil.Get_Ini("Movill", "APTCODE")); //아파트 고유코드
            CConfig.apt_name = MyUtil.Get_Ini("Movill", "APTNAME"); //아파트 명칭

            lbl_Code.Text = "아파트코드 : " + CConfig.apt_idx + "(" + CConfig.apt_name + ")";

            //udpServer = new UdpEndpoint("127.0.0.1", 18697);
            udpServer = new UdpEndpoint("192.168.100.200", 18697);
            udpServer.EndpointDetected += EndpointDetected;
            udpServer.DatagramReceived += DatagramReceived;
            udpServer.StartServer();

            //mySock = new MySocket(CConfig.HostRcvPort, this);
        }
        public void EndpointDetected(object sender, EndpointMetadata md)
        {
            //Console.WriteLine("Endpoint detected: " + md.Ip + ":" + md.Port);
        }

        public void DatagramReceived(object sender, Datagram dg)
        {
            //Console.WriteLine("[" + dg.Ip + ":" + dg.Port + "]: " + Encoding.UTF8.GetString(dg.Data));

            try
            {
                string str = Encoding.UTF8.GetString(dg.Data);
                string msg = JwtEncoder.JwtDecode(str, "www.jawootek.com");
                Console.WriteLine(msg);

                string[] data = msg.Split('_');
                string gateNo = data[0];
                string carNo = data[1];
                string dong = data[2];
                string ho = data[3];
                string inout = data[4];


                string pdata = "[Recv from Host] ";
                if (inout == "IN") pdata += "입차";
                else pdata += "출차";
                pdata += ", 차량번호:" + carNo + ", 동:" + dong + ", 호수:" + ho;
                Logger("==========================================================", listBox1);
                Logger(pdata, listBox1);
                MyUtil.FileLogger("==========================================================");
                MyUtil.FileLogger(pdata);

                if (inout == "IN")
                    InCarProc(carNo, dong, ho, gateNo);
                else
                    OutCarProc(carNo, dong, ho, gateNo);
            } catch(Exception ex) {
                MyUtil.FileLogger("[Recv from Host] Err : " + ex.Message);
                Logger("[Recv from Host] Err : " + ex.Message, listBox1);
            }

            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new MethodInvoker(delegate ()
            //    {
            //        listBox1.Items.Add(pdata);
            //        listBox1.SelectedIndex = listBox1.Items.Count - 1;
            //    }));
            //}
            //else
            //{
            //    listBox1.Items.Add(pdata);
            //    listBox1.SelectedIndex = listBox1.Items.Count - 1;
            //}

            
        }



        private void btnAuthorization_Click(object sender, EventArgs e)
        {
            try
            {
                string pdata = "";
                string token = "";
                byte[] byte1 = Encoding.ASCII.GetBytes("grant_type=client_credentials");

                HttpWebRequest bearerReq = WebRequest.Create(CConfig.tokenRoute) as HttpWebRequest;
                bearerReq.Method = "POST";
                bearerReq.ContentType = "application/x-www-form-urlencoded";
                bearerReq.ContentLength = byte1.Length;
                //bearerReq.KeepAlive = false;
                bearerReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(CConfig.clientId + ":" + CConfig.secretKey)));
                Stream newStream = bearerReq.GetRequestStream();
                newStream.Write(byte1, 0, byte1.Length);

                MyUtil.FileLogger("[Send to Movill] Authorization : 액세스 토큰 요청");

                WebResponse bearerResp = bearerReq.GetResponse();

                using (var reader = new StreamReader(bearerResp.GetResponseStream(), Encoding.UTF8))
                {
                    var response = reader.ReadToEnd();
                    //Bearer bearer = JsonConvert.DeserializeObject<Bearer>(response);
                    //accessToken = bearer.access_token;
                    //Console.WriteLine(response);

                    var res = JObject.Parse(response);
                    try
                    {
                        //txtOAuth.Text = res["token_type"].ToString() + "  " + res["access_token"].ToString() + "  " + res["expires_in"].ToString();
                        CConfig.authToken = res["access_token"].ToString();

                        pdata = "[Recv from Movill] Authorization : 액세스 토큰 가져오기 성공" + CConfig.authToken.Substring(0, 15) + "*****";
                        Logger(pdata, listBox1);
                        MyUtil.FileLogger(pdata);
                    }
                    catch(Exception ex)
                    {
                        //txtOAuth.Text = res["error_description"].ToString() + "  " + res["error"].ToString();
                        CConfig.authToken = res["error_description"].ToString() + "  " + res["error"].ToString();

                        pdata = "[Recv from Movill] Authorization : 액세스 토큰 가져오기 실패! : " + CConfig.authToken;
                        Logger(pdata, listBox1);
                        MyUtil.FileLogger(pdata);
                    }
                }

            }
            catch (WebException ex)
            {
                txtOAuth.Text = ex.Message;
                MyUtil.FileLogger("[Recv from Movill] Authorization : 액세스 토큰 가져오기 실패!!, " + txtOAuth.Text);
            }
        }

        private void timer_nowTime_Tick(object sender, EventArgs e)
        {
            lbl_NowDT.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            DateTimeOffset now = DateTimeOffset.UtcNow;
            long unixTimeMilliseconds = now.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 입차 LPR 차량정보
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InCar_Click(object sender, EventArgs e)
        {
            //차량번호, 동, 호수, LPR번호
            string pdata = "[Movill Client] 테스트 입구버튼 누름";
            pdata += ", 차량번호:" + txt_Carno.Text + ", 동:" + txt_Dong.Text + ", 호수:" + txt_Ho.Text;
            Logger("==========================================================", listBox1);
            Logger(pdata, listBox1);
            MyUtil.FileLogger("==========================================================");
            MyUtil.FileLogger(pdata);

            InCarProc(txt_Carno.Text, txt_Dong.Text, txt_Ho.Text, txt_LPRNo.Text);
        }

        public void Logger(string msg, ListBox lb)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    lb.Items.Insert(0, "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + msg);
                }));
            }
            else
            {
                lb.Items.Insert(0, "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + msg);
            }
        }
        public void InCarProc(string carno, string dong, string ho, string lprno)
        {
            string res = "";
            string pdata;
            txtInOutResponse.Text = "";

            try
            {
                var json = new JObject();
                json.Add("apt_idx", CConfig.apt_idx);
                json.Add("car_number", carno);
                json.Add("lpr_number", lprno);
                json.Add("dong", dong);
                json.Add("ho", ho);
                DateTimeOffset now = DateTimeOffset.UtcNow;
                long unixTimeMilliseconds = now.ToUnixTimeMilliseconds();
                json.Add("in_date", unixTimeMilliseconds);

                for (int i = 0; i < 3; i++)
                {
                    Logger("[Send to Movill] Http Web Request", listBox1);
                    MyUtil.FileLogger("[Send to Movill] Http Web Request");

                    res = callHttpWebRequest(CConfig.carInRoute, json);

                    if (res == "SUCCESS")
                    {
                        //txtInOutResponse.Text = res;

                        pdata = "[Recv from Movill] " + carno + ":" + res;
                        Logger(pdata, listBox1);
                        //MyUtil.FileLogger(pdata);

                        break;
                    }
                    else
                    {
                        //txtInOutResponse.Text = res + " ... retry" + (i + 1);

                        pdata = "[Recv from Movill] " + carno + ":" + res + " ... retry" + (i + 1);
                        Logger(pdata, listBox1);
                        //MyUtil.FileLogger(pdata);

                        if (res.Contains("401") || res.Contains("403")) //액세스 토큰 문제
                        {
                            btnAuthorization_Click(null, null); //액세스 토큰 가져오기 재실행
                        }
                        MyUtil.Delay_Time(1000);
                    }
                }
            }
            catch(Exception ex)
            {
                MyUtil.FileLogger("[InCarProc] Error : " + ex.Message);
                Logger("[InCarProc] Error : " + ex.Message, listBox1);
            }

        }

        /// <summary>
        /// 출차 LPR 차량정보
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutCar_Click(object sender, EventArgs e)
        {
            //차량번호, 동, 호수, LPR번호
            string pdata = "[Movill Client] 테스트 출구버튼 누름";
            pdata += ", 차량번호:" + txt_Carno.Text + ", 동:" + txt_Dong.Text + ", 호수:" + txt_Ho.Text;
            Logger("==========================================================", listBox1);
            Logger(pdata, listBox1);
            MyUtil.FileLogger("==========================================================");
            MyUtil.FileLogger(pdata);

            OutCarProc(txt_Carno.Text, txt_Dong.Text, txt_Ho.Text, txt_LPRNo.Text);
        }

        public void OutCarProc(string carno, string dong, string ho, string lprno)
        {
            string res = "";
            string pdata;
            txtInOutResponse.Text = "";

            try
            {
                var json = new JObject();
                json.Add("apt_idx", CConfig.apt_idx);
                json.Add("car_number", carno);
                json.Add("lpr_number", lprno);
                json.Add("dong", dong);
                json.Add("ho", ho);
                DateTimeOffset now = DateTimeOffset.UtcNow;
                long unixTimeMilliseconds = now.ToUnixTimeMilliseconds();
                json.Add("out_date", unixTimeMilliseconds);

                for (int i = 0; i < 3; i++)
                {
                    Logger("[Send to Movill] Http Web Request", listBox1);
                    MyUtil.FileLogger("[Send to Movill] " + "Http Web Request");
                    res = callHttpWebRequest(CConfig.carOutRoute, json);

                    if (res == "SUCCESS")
                    {
                        //txtInOutResponse.Text = res;
                        pdata = "[Recv from Movill] SUCCESS " + carno + ":" + res;
                        Logger(pdata, listBox1);
                        MyUtil.FileLogger(pdata);

                        break;
                    }
                    else
                    {
                        //txtInOutResponse.Text = res + " ... retry" + (i + 1);

                        pdata = "[Recv from Movill] FAILED!! " + carno + ":" + res + " ... retry" + (i + 1);
                        Logger(pdata, listBox1);
                        MyUtil.FileLogger(pdata);

                        if (res.Contains("401") || res.Contains("403")) //액세스 토큰 문제
                        {
                            btnAuthorization_Click(null, null); //액세스 토큰 가져오기 재실행
                        }
                        MyUtil.Delay_Time(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                MyUtil.FileLogger("[OutCarProc] Error : " + ex.Message);
                Logger("[OutCarProc] Error : " + ex.Message, listBox1);
            }
        }
        public string callHttpWebRequest(string url, JObject json)
        {
            string result = "";
            try
            {
                HttpWebRequest webReq = WebRequest.Create(url) as HttpWebRequest;
                webReq.Method = "POST";
                webReq.Headers["Authorization"] = "Bearer " + CConfig.authToken;
                //webReq.Headers["Authorization"] = "Bearer " + "xa61RJebuOt3KqzgwBbBzns1urTAWVLO"; //테스트
                webReq.ContentType = "application/json";

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(json.ToString());
                webReq.ContentLength = byteArray.Length;

                using (var streamWriter = webReq.GetRequestStream())
                {
                    streamWriter.Write(byteArray, 0, byteArray.Length);
                }

                try
                {
                    WebResponse webResp = webReq.GetResponse();
                    using (var reader = new StreamReader(webResp.GetResponseStream(), Encoding.UTF8))
                    {
                        var response = reader.ReadToEnd();
                        var res = JObject.Parse(response);
                        //res = res.ToString().Replace("", "").Trim();
                        //MyUtil.FileLogger("[Recv from Movill] " + res.ToString());
                        string res2 = res.ToString().Replace("\r\n", "").Trim();
                        MyUtil.FileLogger("[Recv from Movill] " + res2);

                        if (res["message"].ToString() == "SUCCESS")
                        {
                            result = res["message"].ToString(); //정상
                        }
                        else
                        {
                            result = res["error"].ToString(); //토큰만료
                        }
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Message.Contains("400"))
                        MyUtil.FileLogger("[Recv from Movill] Invalid parameters(400)");
                    else if (ex.Message.Contains("401"))
                        MyUtil.FileLogger("[Recv from Movill] Unauthenticated, invalid token(401)");
                    else if (ex.Message.Contains("403"))
                        MyUtil.FileLogger("[Recv from Movill] Unauthorized, invalid token(403)");
                    else if (ex.Message.Contains("404"))
                        MyUtil.FileLogger("[Recv from Movill] Not Found(404)");
                    else if (ex.Message.Contains("405"))
                        MyUtil.FileLogger("[Recv from Movill] Requested method is not supported(405)");
                    else if (ex.Message.Contains("500"))
                        MyUtil.FileLogger("[Recv from Movill] Internal Server Error(500)");
                    else
                        MyUtil.FileLogger("[Recv from Movill] UnKnow Error:" + ex.Message);

                    result = ex.Message;
                }
            }
            catch(Exception e)
            {
                result = e.Message;
                MyUtil.FileLogger("[Recv from Movill] Exception : " + e.Message);
            }

            return result;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyUtil.FileLogger("[Movill Client] 프로그램 종료!!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String sTime = DateTime.Now.ToString("HH:mm:ss");
            if (sTime.Equals("00:00:00"))
            {
                listBox1.Items.Clear();
            }
        }

    }
}
