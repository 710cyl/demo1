using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp;
using Newtonsoft.Json;

namespace Demo1._1._3.MyWorkBench_SkipForm
{
    public partial class NewBasic : Form
    {
        domain.Basic_Set bs = new domain.Basic_Set();
        public Basic_Set main_basic;

        public NewBasic()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //********************
        //客户端发送数据（新建）
        //********************
        public void saveData(domain.Basic_Set bs)
        {
            string json;
            json = JsonConvert.SerializeObject(bs);
            using (var ws = new WebSocket("ws://localhost:9000/SaveData"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }
            
        }

        //********************
        //按钮“关闭”单击事件
        //********************
        private void simpleButton2_Close_Click(object sender, EventArgs e)
        {
            Close();
            
        }
        //********************
        //按钮“保存”单击事件
        //********************
        private void simpleButton1_Save_Click(object sender, EventArgs e)
        {

            bs.ID = new Guid();

            bs.position_Set = textBox_position_Set.Text;
            bs.account_Receive = Convert.ToDecimal(textBox_account_Receive.Text);
            bs.account_Pay = Convert.ToDecimal(textBox_account_Pay.Text);
            bs.storage_Mode = textBox_storage_Mode.Text;
            bs.outStorage_Mode = textBox_outStorage_Mode.Text;
            bs.transportation_Mode = textBox_transportation_Mode.Text;
            bs.post_Property = textBox_post_Property.Text;
            bs.borrow_Property = textBox_borrow_Property.Text;
            bs.customer_Type = textBox_customer_Type.Text;
            bs.expense_Category = textBox_expense_Category.Text;
            bs.nationality = textBox_nationality.Text;
            bs.storage = TextBox_storage.Text;
            bs.refund_Mode = textBox_refund_Mode.Text;
            bs.oil_Varirety = textBox_oil_Varirety.Text;
                  
            saveData(bs);
            Close();
            //main_basic = new Basic_Set();
            //domain.Basic_Set basic_set = new domain.Basic_Set();
            //showData<domain.Basic_Set>(basic_set);

        }
        //public void showData<T>(T t)
        //{
        //    List<T> bs = null;
        //    string msg = null;
        //    string sendMsg = t.GetType().Name.ToString();
        //    using (var ws = new WebSocket("ws://localhost:9000/ShowData"))
        //    {
        //        ws.Connect();
        //        ws.Send(sendMsg);
        //        while (msg == null)
        //        {
        //            ws.OnMessage += (sender, e) =>
        //            msg = e.Data;
        //        }
        //        ws.Close();
        //        bs = JsonConvert.DeserializeObject<List<T>>(msg);
        //        main_basic.gridControl2.DataSource = bs;
        //    }
        //}
    }
}
