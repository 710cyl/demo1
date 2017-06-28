using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using SuperSocket.SocketBase.Protocol;
using MySql.Data;
using MySql.Data.MySqlClient;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace LogisticsSystemSuperSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://localhost:9000");
            wssv.AddWebSocketService<LogIn> ("/LogIn");
            wssv.Start();
            Console.WriteLine("服务器已启动，按任意按键关闭");
            Console.ReadKey(true);

            wssv.Stop();
           
        }

    }

    public class LogIn : WebSocketBehavior
    {
       protected override void OnMessage(MessageEventArgs e)
        {
            //var msg = e.Data == "BALUS"
            //    ? "true"
            //    : "true";

            string receiveMsg = e.Data; //接收数据
            string isLogIn = "";
            string constr = "server=127.0.0.1;User Id=root;password=root;Database=test";
            MySqlConnection mycon = new MySqlConnection(constr);
            MySqlCommand sqlcmd = new MySqlCommand();

            mycon.Open();

            sqlcmd.CommandText = receiveMsg;
            sqlcmd.Connection = mycon;
            MySqlDataReader sqlDr = sqlcmd.ExecuteReader();

            if (sqlDr.Read())
            {
                isLogIn = "true";
            }

            else
            {
                isLogIn = "false";
            }

            Send(isLogIn);
        }
    }
}
