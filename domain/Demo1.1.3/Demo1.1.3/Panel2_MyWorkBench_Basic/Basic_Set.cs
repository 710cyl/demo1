using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
namespace Demo1._1._3
{
    public partial class Basic_Set : UserControl
    {
        public Basic_Set()
        {
            InitializeComponent();
            
            //showData();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }

        public void showData()
        {
            List<Basic_Set> bs = null;
            string msg = null;
            using (var ws = new WebSocket("ws://localhost:9000/ShowData"))
            {

                ws.Connect();
                ws.Send("连接成功！！");
                while (msg == null)
                {
                    ws.OnMessage += (sender, e) =>
                    msg = e.Data;
                }
                //Thread.Sleep(2000);
                //MessageBox.Show(msg);
                bs = JsonConvert.DeserializeObject<List<Basic_Set>>(msg);
                gridControl2.DataSource = bs;
                gridView2.OptionsView.ColumnAutoWidth = false;
            }
        }

        public void deleteData(string deleteIndex)
        {
            using (var ws = new WebSocket("ws://localhost:9000/DeleteData"))
            {
                ws.Connect();
                ws.Send(deleteIndex);
                ws.Close();
            }
        }
        private void toolStripButtonDelete_Click(object sender, EventArgs e) //Delete
        {
            string deleteIndex = gridView2.GetFocusedValue().ToString();
            MessageBox.Show(deleteIndex);
            deleteData(deleteIndex);
            gridView2.DeleteRow(gridView2.FocusedRowHandle); 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
