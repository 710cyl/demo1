using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace LogisticSystemServer
{
    public partial class LogInServer : Form
    {
        public LogInServer()
        {
            InitializeComponent();
            socketServer();
         
        }

        private void socketServer()
        {
            //建立一个socket
            Socket tcpServer = new Socket(AddressFamily.InterNetwork 
                ,SocketType.Stream,ProtocolType.Tcp);
            //绑定ip和port端口号
            IPAddress ipaddress = new IPAddress(new byte[] {127,0,0,1});
            EndPoint point = new IPEndPoint(ipaddress,7788);

            string constr = "server=127.0.0.1;User Id=root;password=root;Database=test";
            MySqlConnection mycon = new MySqlConnection(constr);
            MySqlCommand sqlcmd = new MySqlCommand();


            tcpServer.Bind(point);//向系统申请一个可用的ip地址和端口号用于通信
            //开始监听
            tcpServer.Listen(100);//设置最大的连接数

            Socket ClientSocket = tcpServer.Accept();
          
                //使用返回的socket向客户端发送消息
                string isLogIn = "false";


                if (mycon.State == ConnectionState.Open)
                {
                    mycon.Close();
                }

                mycon.Open();

                byte[] data = new byte[1000];
                int length = ClientSocket.Receive(data);
                string receiveMsg = Encoding.UTF8.GetString(data, 0, length);
                sqlcmd.CommandText = receiveMsg;
                sqlcmd.Connection = mycon;
                MySqlDataReader sqlDr = sqlcmd.ExecuteReader();

                if (sqlDr.Read())
                {
                    isLogIn = "true";
                }

                else
                    isLogIn = "false";

                byte[] str = Encoding.UTF8.GetBytes(isLogIn);

                ClientSocket.Send(str);
            
            
        }

       
    }
}
