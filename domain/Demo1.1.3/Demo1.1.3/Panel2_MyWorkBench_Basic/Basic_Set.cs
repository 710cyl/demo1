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
using System.Drawing.Printing;

namespace Demo1._1._3
{
    public partial class Basic_Set : UserControl
    {
        NewBasic nb;
        StringReader streamToPrint = null;
        Font printFont;
        public Basic_Set()
        {
            InitializeComponent();
            //gridView2.Columns[0].Caption = "编号";
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

                bs = JsonConvert.DeserializeObject<List<Basic_Set>>(msg);
                gridControl2.DataSource = bs;
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
            nb = new NewBasic();
            nb.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string localFilePath  = ShowSaveFileDialog();
            
            if (localFilePath !=null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }   
        }

        public string ShowSaveFileDialog() //保存文件地址
        {
            string localFilePath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel表格(*.xls)|*.xls"; //设置文件类型
            sfd.FilterIndex = 1;//默认文件类型显示顺序
            sfd.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
            if (sfd.ShowDialog()==DialogResult.OK) // 点击保存按钮进入
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

        private void toolStripButton8_Click(object sender, EventArgs e) //复选功能
        {
            if (this.gridView2.OptionsSelection.MultiSelect == true)
            {
                if (MessageBox.Show("是否关闭复选框", "复选框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    this.gridView2.OptionsSelection.MultiSelect = false;
                   // this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                }
            }
            else if(MessageBox.Show("是否打开复选框", "复选框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.gridView2.OptionsSelection.MultiSelect = true;
                this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }  
        }

        private void toolStripButton3_Click(object sender, EventArgs e) //导入数据
        {
            string dataString = getDataTable();

            if (dataString != null)
            {
                 using (var ws = new WebSocket("ws://localhost:9000/BatchSave"))
                {
                      ws.Connect();
                      ws.Send(dataString);
                      ws.Close();
                 }
                MessageBox.Show("导入成功！！");
            }
               
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linesPerPage = 0;//记录每页最大行数
            float yPos = 0;//记录将要打印的一行数据在垂直方向的位置
            int count = 0;//记录每页已打印行数
            float leftMargin = e.MarginBounds.Left;//左边距
            float topMargin = e.MarginBounds.Top;//顶边距
            string line = null;//从RichTextBox中读取一段字符将存到line中
            //每页最大行数=一页纸打印区域的高度/一行字符的高度
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
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

        private void 页面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.ShowDialog();
        }

        private void 页面预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
                printDocument1.Print();
        }
    }
}
