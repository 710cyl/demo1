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
using System.Reflection;
using System.Data.OleDb;
using Newtonsoft.Json.Converters;
using Demo1._1._3.MyWorkBench_SkipForm;
using System.IO;
using DevExpress.XtraEditors;
using System.Drawing.Printing;

namespace Demo1._1._3
{
        public class FunctionClass //存有各个表功能的相关接口的接口定义
        {
            public void InitPage(DataNavigator datanavigator, long total_Page, long now_Page) //初始化分页
            {
                datanavigator.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
            }

              public long getTotal<T>(T t,long total_Page) //获得总条目函数
            {
                 using (var ws = new WebSocket("ws://localhost:9000/GetCount"))
               {
                    ws.Connect();
                    string sendMsg = t.GetType().Name.ToString();
                    ws.Send(sendMsg); //传类名
                    while (total_Page == 0)
                    {
                         ws.OnMessage += (sender, e) =>
                                    total_Page = (Convert.ToInt64(e.Data) / 50) + 1;
                    }
                 }
                    return total_Page;
             }

        public void DeleteData(DevExpress.XtraGrid.Views.Grid.GridView gv)  //删除函数
        {
            string deleteIndex = gv.GetFocusedValue().ToString();
            if (MessageBox.Show("是否删除此消息？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                deleteData(deleteIndex);
                gv.DeleteRow(gv.FocusedRowHandle);
            }
            else
            {

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

        public string ShowSaveFileDialog() //保存文件地址
        {
            string localFilePath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel表格(*.xls)|*.xls"; //设置文件类型
            sfd.FilterIndex = 1;//默认文件类型显示顺序
            sfd.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
            if (sfd.ShowDialog() == DialogResult.OK) // 点击保存按钮进入
            {
                localFilePath = sfd.FileName.ToString();//获取文件路径
            }
            return localFilePath;
        }

        public string ReadFileDialog()//读取文件地址
        {
            string localFilePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel表格(*.xls)|*.xls";
            ofd.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
            if (ofd.ShowDialog() == DialogResult.OK) // 点击保存按钮进入
            {
                localFilePath = ofd.FileName.ToString();//获取文件路径
            }
            return localFilePath;
        }

        public string getDataTable()   
        {
            string localFilePath = ReadFileDialog();//获取上传文件信息
            if (localFilePath != "")
            {
                string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                           localFilePath +
                           ";Extended Properties='Excel 8.0;HDR=YES;';";
                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [Sheet$]", con);
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                // List<Basic_Set> data = new List<Basic_Set>();
                DataTable data = new DataTable();
                sda.Fill(data);
                string dataString = JsonConvert.SerializeObject(data, new DataTableConverter());
                return dataString;
            }
            return null;
        }


        public List<T> showData<T>(T t, string nowpage) //显示数据
        {
            List<T> bs = null;
            string msg = null;
            string sendMsg = t.GetType().Name.ToString();
            using (var ws = new WebSocket("ws://localhost:9000/ShowData"))
            {
                ws.Connect();
                ws.Send(sendMsg);
                using (var wsp = new WebSocket("ws://localhost:9000/NowPage"))
                {
                    wsp.Connect();
                    wsp.Send(nowpage);
                    wsp.Close();
                }
                while (msg == null)
                {
                    ws.OnMessage += (sender, e) =>
                    msg = e.Data;
                }
                ws.Close();
                bs = JsonConvert.DeserializeObject<List<T>>(msg);
                //   main_basic.gridControl2.DataSource = bs;
            }
            return bs;
        }

          public void PrintDocument(object sender, PrintPageEventArgs e)
        {
            Font printFont = null;
            StringReader streamToPrint = null;
            //记录每页最大行数
            float yPos = 0;//记录将要打印的一行数据在垂直方向的位置
            int count = 0;//记录每页已打印行数
            float leftMargin = e.MarginBounds.Left;//左边距
            float topMargin = e.MarginBounds.Top;//顶边距
            string line = null;//从RichTextBox中读取一段字符将存到line中
            //每页最大行数=一页纸打印区域的高度/一行字符的高度
            float linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            //如果当前页已打印行数小于每页最大行数而且读出数据不为null，继续打印
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {   //yPos为要打印的当前行在垂直方向上的位置
                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black,
                leftMargin, yPos, new StringFormat());//打印
                count++;//已打印行数加1
            }
            //是否需要打印下一页
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }  

        public void PageSet(PageSetupDialog psd, PrintDocument printDocument) //页面设置
        {
            psd.Document = printDocument;
            psd.ShowDialog();
        }

        public void PageView(PageSetupDialog psd, PrintDocument printDocument)
        {
            psd.Document = printDocument;
            psd.ShowDialog();
        }
        //********************
        //客户端发送数据（新建）
        //********************
        public void saveData<T>(T t)
        {
            string json;
            json = JsonConvert.SerializeObject(t);
            using (var ws = new WebSocket("ws://localhost:9000/SaveData"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }
        }

        //********************
        //客户端发送数据（更新）
        //********************
        public void updateData<T>(T t)
        {
            string json;
            json = JsonConvert.SerializeObject(t);

            using (var ws = new WebSocket("ws://localhost:9000/UpdateData"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }

        }
    }
}
