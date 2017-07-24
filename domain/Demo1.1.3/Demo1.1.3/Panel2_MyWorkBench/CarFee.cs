using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WebSocketSharp;
using Newtonsoft.Json;
using domain;

namespace Demo1._1._3.Panel2_MyWorkBench
{
    public partial class CarFee : UserControl
    {

        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码

        public long total_Page2 = 0; //页码总条目
        public long now_Page2 = 1; //当前页码
        domain.Charter_Fee_Main cfm = new domain.Charter_Fee_Main();
        domain.Charter_Fee_Detail cfd = new domain.Charter_Fee_Detail();
        FunctionClass fc = new FunctionClass();

        public CarFee()
        {
            InitializeComponent();


            total_Page = fc.getTotal<domain.Charter_Fee_Main>(cfm, total_Page);
            fc.InitPage(dataNavigator_Charter_Fee_Main, total_Page, now_Page);


        }


        private void dataNavigator_Charter_Fee_Main_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator_Charter_Fee_Main.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Charter_Fee_Main cfm = new domain.Charter_Fee_Main();
                    gridControl1.DataSource = fc.showData<domain.Charter_Fee_Main>(cfm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_Charter_Fee_Main.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Charter_Fee_Main cfm = new domain.Charter_Fee_Main();
                    gridControl1.DataSource = fc.showData<domain.Charter_Fee_Main>(cfm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_Charter_Fee_Main.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Charter_Fee_Main cfm = new domain.Charter_Fee_Main();
                    gridControl1.DataSource = fc.showData<domain.Charter_Fee_Main>(cfm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_Charter_Fee_Main.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Charter_Fee_Main cfm = new domain.Charter_Fee_Main();
                    gridControl1.DataSource = fc.showData<domain.Charter_Fee_Main>(cfm, now_Page.ToString());
                }
            }
        }

        private void dataNavigator_Charter_Fee_Detail_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page2 < total_Page2)
                {
                    now_Page2++;
                    dataNavigator_Charter_Fee_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.Charter_Fee_Detail cfd = new domain.Charter_Fee_Detail();
                    gridControl2.DataSource = fc.showData<domain.Charter_Fee_Detail>(cfd, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page2 > 1)
                {
                    now_Page2--;
                    dataNavigator_Charter_Fee_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.Charter_Fee_Detail cfd = new domain.Charter_Fee_Detail();
                    gridControl2.DataSource = fc.showData<domain.Charter_Fee_Detail>(cfd, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page2 = 1;
                    dataNavigator_Charter_Fee_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.Charter_Fee_Detail cfd = new domain.Charter_Fee_Detail();
                    gridControl2.DataSource = fc.showData<domain.Charter_Fee_Detail>(cfd, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page2 = total_Page2;
                    dataNavigator_Charter_Fee_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.Charter_Fee_Detail cfd = new domain.Charter_Fee_Detail();
                    gridControl2.DataSource = fc.showData<domain.Charter_Fee_Detail>(cfd, now_Page2.ToString());
                }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            List<Charter_Fee_Detail> cfdlist = new List<Charter_Fee_Detail>();
            string str;
            string js;
            str = null;
            js = null; 
            str = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[0]);

            if (str != null)
            {
                using (var ws = new WebSocket("ws://localhost:9000/ShowDetail")) 
                {
                    ws.Connect();
                    ws.Send(str);
                    while (js == null)
                    {
                        ws.OnMessage += (sender2, e2) => js = e2.Data;
                    }
                    ws.Close();
                 }

                  cfdlist = JsonConvert.DeserializeObject<List<Charter_Fee_Detail>>(js);
                  this.gridControl2.DataSource = cfdlist;

                  gridView2.Columns[0].Caption = "车单号";
                  gridView2.Columns[1].Caption = "车队";
                  gridView2.Columns[2].Caption = "车号";
                  gridView2.Columns[3].Caption = "司机";
                  gridView2.Columns[4].Caption = "运输量";
                  gridView2.Columns[5].Caption = "运输产值";
                  gridView2.Columns[6].Caption = "集运量";
                  gridView2.Columns[7].Caption = "集运产值";
                  gridView2.Columns[8].Caption = "司机比例";
                  gridView2.Columns[9].Caption = "包车费";
                  gridView2.Columns[10].Caption = "备注";
                  gridView2.Columns[11].Caption = "扣费月份";
                  gridView2.Columns[12].Caption = "记账日期";
                  gridView2.Columns[13].Caption = "车队标识";
                  gridView2.Columns[14].Caption = "录入人";
                  gridView2.Columns[15].Caption = "录入时间";
                  gridView2.Columns[16].Caption = "修改人";
                  gridView2.Columns[17].Caption = "修改时间";
                  gridView2.Columns[18].Caption = "截止时间";
                  gridView2.Columns[19].Caption = "扣费单号";

            }
            else
            {
                MessageBox.Show("无有效数据");
            }

        }
    }
}
