using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.ByteCode.Castle;
using domain;
using WebSocketSharp;
using Basic_SetTest;
using System.Threading;
using Newtonsoft.Json;
namespace testBasicSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            showData();
        }

        public void showData()
        {
            List<Basic_Set> bs = null;
            string msg = null;
            using (var ws = new WebSocket("ws://localhost:9000/ShowData"))
            {
                ws.Connect();
                ws.Send("连接成功！！");
                ws.OnMessage += (sender, e) =>
                   msg = e.Data;
                Thread.Sleep(1500);

                //MessageBox.Show(msg);
                bs = JsonConvert.DeserializeObject<List<Basic_Set>>(msg);
                gridControl1.DataSource = bs;

            }

        }
    }
}
