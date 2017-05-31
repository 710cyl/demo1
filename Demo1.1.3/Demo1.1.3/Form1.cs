using Demo1._1._3.Panel2_Basic_UserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public MainOganization main_oganization;
        public MainRole main_role;
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

        /*        private void Form1_Load(object sender, EventArgs e)
                {
                   u1 = new UserControl1();
                    u2 = new UserControl2();
                }*/

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

        private void accordionControlElement35_Click(object sender, EventArgs e)
        {
            main_basic = new Basic_Set();
            main_basic.Show();
            main_basic.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(main_basic);

        }

        private void accordionControlElement36_Click(object sender, EventArgs e)
        {
            internal_fleet = new Internal_Fleet();
            internal_fleet.Show();
            internal_fleet.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(internal_fleet);
        }

        private void accordionControlElement37_Click(object sender, EventArgs e)
        {
            up = new UnloadingPoint();
            up.Show();
            up.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(up);
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

        private void accordionControlElement44_Click(object sender, EventArgs e)
        {
            ca = new CapitalAccount();
            ca.Show();
            ca.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ca);
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

   
    }
}
