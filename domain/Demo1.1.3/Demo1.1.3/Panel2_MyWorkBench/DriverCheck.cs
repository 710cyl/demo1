using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Demo1._1._3.MyWorkBench_SkipForm;

namespace Demo1._1._3.Panel2_MyWorkBench
{
    public partial class DriverCheck : UserControl
    {
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        domain.Driver_Check dc = new domain.Driver_Check();
        FunctionClass fc = new FunctionClass();
        New_DriverCheck new_drivercheck;

        public DriverCheck()
        {
            InitializeComponent();


            total_Page = fc.getTotal<domain.Driver_Check>(dc, total_Page);
            fc.InitPage(dataNavigator_Driver_Check, total_Page, now_Page);
        }

        private void dataNavigator_Driver_Check_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator_Driver_Check.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Driver_Check cfm = new domain.Driver_Check();
                    gridControl2.DataSource = fc.showData<domain.Driver_Check>(cfm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_Driver_Check.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Driver_Check cfm = new domain.Driver_Check();
                    gridControl2.DataSource = fc.showData<domain.Driver_Check>(cfm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_Driver_Check.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Driver_Check cfm = new domain.Driver_Check();
                    gridControl2.DataSource = fc.showData<domain.Driver_Check>(cfm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_Driver_Check.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Driver_Check cfm = new domain.Driver_Check();
                    gridControl2.DataSource = fc.showData<domain.Driver_Check>(cfm, now_Page.ToString());
                }
            }
        }

        //新建
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new_drivercheck = new New_DriverCheck();
            new_drivercheck.ShowDialog();
        }
    }
}
