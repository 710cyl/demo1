using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3
{
    public partial class Basic_Set : UserControl
    {
        public Basic_Set()
        {
            InitializeComponent();
            BindDataSource(InitBaseDB());

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

        //显示基础系统数据库数据
       private DataTable InitBaseDB()
        {
            DataTable dt = new DataTable("");
            dt.Rows.Add(new object[] {});
            return dt;
        }

        private void BindDataSource(DataTable dt)  
         {  
             gridControl2.DataSource = dt;   
         }  
    }
}
