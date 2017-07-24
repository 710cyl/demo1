using Demo1._1._3.Panel1_SystemManagement;
using Demo1._1._3.Panel2_Basic_UserControl;
using Demo1._1._3.Panel2_MyWorkBench;
using Demo1._1._3.Properties;
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
namespace Demo1._1._3
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {

        public MainOganization main_oganization;
        public MainRole main_role;
        public TaskManagement tm;
        public Journal journal;
        public Link link;
        public MainUser muser;

        public Basic_Set main_basic;
        public Internal_Fleet internal_fleet;
        public UnloadingPoint up;
        public VarietyMaterial vm;
        public ExternalFleet ef;
        public WarehouseFile wf;
        public OwnVehicle ov;
        public OfficeSupplies os;
        public MaintenanceMaterial mm;
        public CapitalAccount ca;
        public CustomerFile cf;
        public WarehousingPrice wp;
        public OrderFile of;

        public GodownEntry ge;
        public OutboundOrder obo;
        public TransferList tl;
        public LotteryNumber lotn;
        public TransportationRegister tr;
        public FleetPrice fleetp;
        public FleetPayment fleetpay;
        public ShipperPrice shipperp;
        public TransportationClearing tpc;
        public CarReimbursement carr;
        public Panel2_MyWorkBench.OilGasRegister ogr;
        public Demo1._1._3.Panel2_MyWorkBench.DriverCheck drc;
        public CarFee carf;

        /*        private void Form1_Load(object sender, EventArgs e)
                {
                   u1 = new UserControl1();
                    u2 = new UserControl2();
                }*/
        public FunctionClass fc;

        public Form1()
        {
            InitializeComponent();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement1_Click_1(object sender, EventArgs e)
        {

        }

        private void navigationPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        /**************************系统管理，左测导航栏点击事件*********************************/
        private void accordionControlElement1_Click_2(object sender, EventArgs e)
        {
            main_oganization = new MainOganization();
            main_oganization.Show();
            main_oganization.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(main_oganization);

        }
        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            main_role = new MainRole();
            main_role.Show();
            main_role.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(main_role);

        }
        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            tm = new TaskManagement();
            tm.Show();
            tm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(tm);
        }
        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            journal = new Journal();
            journal.Show();
            journal.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(journal);
        }
        private void accordionControlElement34_Click(object sender, EventArgs e)
        {
            link = new Link();
            link.Show();
            link.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(link);
        }
        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            muser = new MainUser();
            muser.Show();
            muser.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(muser);
        }

        /***************************************************************************************/


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement30_Click(object sender, EventArgs e)
        {
            
        }

        private void accordionControl3_Click(object sender, EventArgs e)
        {

        }
        public List<T> showData<T>(T t, string nowpage)
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

        /****************************我的工作台左测导航栏点击事件****************************************/
        private void accordionControlElement35_Click(object sender, EventArgs e)
        {
            main_basic = new Basic_Set();
            main_basic.Show();
            main_basic.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(main_basic);
            domain.Basic_Set basic_set = new domain.Basic_Set();
            //Basic_Set dbs = new Basic_Set();
            main_basic.gridControl2.DataSource = showData<domain.Basic_Set>(basic_set, main_basic.now_Page.ToString());
            main_basic.gridView2.Columns[0].Caption ="编号";
            main_basic.gridView2.BestFitColumns();

        }

        
        private void accordionControlElement36_Click(object sender, EventArgs e)
        {
            internal_fleet = new Internal_Fleet();
            internal_fleet.Show();
            internal_fleet.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(internal_fleet);
            domain.Internal_Vehicle div = new Internal_Vehicle();
            internal_fleet.gridControl2.DataSource = showData<domain.Internal_Vehicle>(div, internal_fleet.now_Page.ToString());
        }

        private void accordionControlElement37_Click(object sender, EventArgs e)
        {
            up = new UnloadingPoint();
            up.Show();
            up.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(up);
            domain.Decorate dec = new Decorate();
            domain.Discharge dis = new Discharge();
            domain.Transportations trans = new Transportations();
            up.gridControl2.DataSource = showData<domain.Decorate>(dec,up.now_Page_Dec.ToString());
            up.gridControl3.DataSource = showData<domain.Discharge>(dis,up.now_Page_Dis.ToString());
            up.gridControl4.DataSource = showData<domain.Transportations>(trans,up.now_Page_Trans.ToString());
        }

        private void accordionControlElement38_Click(object sender, EventArgs e)
        {
            vm = new VarietyMaterial();
            vm.Show();
            vm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(vm);
        }

        private void accordionControlElement39_Click(object sender, EventArgs e)
        {
            ef = new ExternalFleet();
            ef.Show();
            ef.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ef);
        }

        private void accordionControlElement40_Click(object sender, EventArgs e)
        {
            wf = new WarehouseFile();
            wf.Show();
            wf.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(wf);
        }

        private void accordionControlElement41_Click(object sender, EventArgs e)
        {
            ov = new OwnVehicle();
            ov.Show();
            ov.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ov);
        }

        private void accordionControlElement42_Click(object sender, EventArgs e)
        {
            os = new OfficeSupplies();
            os.Show();
            os.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(os);
        }

        private void accordionControlElement43_Click(object sender, EventArgs e)
        {
            mm = new MaintenanceMaterial();
            mm.Show();
            mm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(mm);
        }

        private void accordionControlElement44_Click(object sender, EventArgs e) //账户资金
        {
            ca = new CapitalAccount();
            ca.Show();
            ca.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ca);
            CapitalAccount dca = new CapitalAccount();
            domain.Fund_Accounts fund_account = new domain.Fund_Accounts();
            ca.gridControl2.DataSource=showData<domain.Fund_Accounts>(fund_account, dca.now_Page.ToString());     
        }

        private void accordionControlElement45_Click(object sender, EventArgs e)
        {
            cf = new CustomerFile();
            cf.Show();
            cf.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(cf);
        }

        private void accordionControlElement46_Click(object sender, EventArgs e)
        {
            wp = new WarehousingPrice();
            wp.Show();
            wp.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(wp);
        }

        private void accordionControlElement47_Click(object sender, EventArgs e)
        {
            of = new OrderFile();
            of.Show();
            of.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(of);
        }

        private void accordionControlElement62_Click(object sender, EventArgs e)
        {
            ge = new GodownEntry();
            ge.Show();
            ge.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ge);
        }

        private void accordionControlElement63_Click(object sender, EventArgs e)
        {
            obo = new OutboundOrder();
            obo.Show();
            obo.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(obo);
        }

        private void accordionControlElement64_Click(object sender, EventArgs e)
        {
            tl = new TransferList();
            tl.Show();
            tl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(tl);
        }

        private void accordionControlElement70_Click(object sender, EventArgs e)
        {
            lotn = new LotteryNumber();
            lotn.Show();
            lotn.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(lotn);
        }

        private void accordionControlElement65_Click(object sender, EventArgs e)
        {
            tr = new TransportationRegister();
            tr.Show();
            tr.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(tr);
        }

        private void accordionControlElement66_Click(object sender, EventArgs e)
        {
            fleetp = new FleetPrice();
            fleetp.Show();
            fleetp.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(fleetp);
        }

        private void accordionControlElement79_Click(object sender, EventArgs e)
        {
            fleetpay = new FleetPayment();
            fleetpay.Show();
            fleetpay.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(fleetpay);
        }

        private void accordionControlElement67_Click(object sender, EventArgs e)
        {
            shipperp = new ShipperPrice();
            shipperp.Show();
            shipperp.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(shipperp);
        }

        private void accordionControlElement76_Click(object sender, EventArgs e)
        {
            tpc = new TransportationClearing();
            tpc.Show();
            tpc.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(tpc);
        }

        private void accordionControlElement77_Click(object sender, EventArgs e)
        {
            carr = new CarReimbursement();
            carr.Show();
            carr.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(carr);
        }

        private void accordionControlElement78_Click(object sender, EventArgs e)
        {
            ogr = new Panel2_MyWorkBench.OilGasRegister();
            ogr.Show();
            ogr.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ogr);
        }

        private void accordionControlElement82_Click(object sender, EventArgs e)
        {
            drc = new Demo1._1._3.Panel2_MyWorkBench.DriverCheck();
            drc.Show();
            drc.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(drc);
            domain.Driver_Check driver_check = new domain.Driver_Check();
            drc.gridControl2.DataSource = showData<domain.Driver_Check>(driver_check,drc.now_Page.ToString());
            drc.gridView2.BestFitColumns();
            drc.gridView2.Columns[0].Caption = "考核单号";
            drc.gridView2.Columns[1].Caption = "考核类别";
            drc.gridView2.Columns[2].Caption = "考核月份";
            drc.gridView2.Columns[3].Caption = "车队";
            drc.gridView2.Columns[4].Caption = "车号";
            drc.gridView2.Columns[5].Caption = "司机";
            drc.gridView2.Columns[6].Caption = "考核金额";
            drc.gridView2.Columns[7].Caption = "工资金额";
            drc.gridView2.Columns[8].Caption = "考核下达人";
            drc.gridView2.Columns[9].Caption = "录入人员";
            drc.gridView2.Columns[10].Caption = "录入时间";
            drc.gridView2.Columns[11].Caption = "考核事由";
            drc.gridView2.Columns[12].Caption = "记账日期";
        }

        private void accordionControlElement83_Click(object sender, EventArgs e)
        {
            carf = new CarFee();
            carf.Show();
            carf.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(carf);
            domain.Charter_Fee_Main charter_fee_main = new domain.Charter_Fee_Main();
            carf.gridControl1.DataSource = showData<domain.Charter_Fee_Main>(charter_fee_main, carf.now_Page.ToString());
            carf.gridView1.BestFitColumns();
            carf.gridView1.Columns[9].Visible = false;
            carf.gridView1.Columns[0].Caption = "扣费单号";
            carf.gridView1.Columns[1].Caption = "扣费月份";
            carf.gridView1.Columns[2].Caption = "记账日期";
            carf.gridView1.Columns[3].Caption = "开始时间";
            carf.gridView1.Columns[4].Caption = "录入人";
            carf.gridView1.Columns[5].Caption = "录入时间";
            carf.gridView1.Columns[6].Caption = "修改人";
            carf.gridView1.Columns[7].Caption = "修改时间";
            carf.gridView1.Columns[8].Caption = "截止时间";


            List<Charter_Fee_Detail> cfdlist = new List<Charter_Fee_Detail>();
            string str;
            string js;
            str = null;
            js = null;
            str = carf.gridView1.GetFocusedRowCellDisplayText(carf.gridView1.Columns[0]);

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
                carf.gridControl2.DataSource = cfdlist;
               
                carf.gridView2.Columns[0].Caption = "车单号";
                carf.gridView2.Columns[1].Caption = "车队";
                carf.gridView2.Columns[2].Caption = "车号";
                carf.gridView2.Columns[3].Caption = "司机";
                carf.gridView2.Columns[4].Caption = "运输量";
                carf.gridView2.Columns[5].Caption = "运输产值";
                carf.gridView2.Columns[6].Caption = "集运量";
                carf.gridView2.Columns[7].Caption = "集运产值";
                carf.gridView2.Columns[8].Caption = "司机比例";
                carf.gridView2.Columns[9].Caption = "包车费";
                carf.gridView2.Columns[10].Caption = "备注";
                carf.gridView2.Columns[11].Caption = "扣费月份";
                carf.gridView2.Columns[12].Caption = "记账日期";
                carf.gridView2.Columns[13].Caption = "车队标识";
                carf.gridView2.Columns[14].Caption = "录入人";
                carf.gridView2.Columns[15].Caption = "录入时间";
                carf.gridView2.Columns[16].Caption = "修改人";
                carf.gridView2.Columns[17].Caption = "修改时间";
                carf.gridView2.Columns[18].Caption = "截止时间";
                carf.gridView2.Columns[19].Caption = "扣费单号";
            }
            else
            {
                MessageBox.Show("无有效数据");
            }

        }

        /*********************************************************************************************************/
    }
}
