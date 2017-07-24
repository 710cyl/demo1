using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3.MyWorkBench_SkipForm
{


    public partial class New_DriverCheck : Form
    {


        public New_DriverCheck()
        {
            InitializeComponent();
            bindCbox();
        }
        public class Info
        {
            public string Id { get; set; }
            public string Name { get; set; }

        }
        private void bindCbox()
        {
            IList<Info> infoList = new List<Info>();
            Info info_type1 = new Info() { Id = "1", Name = "奖励" };
            Info info_type2 = new Info() { Id = "2", Name = "罚款" }; 
            infoList.Add(info_type1);
            infoList.Add(info_type2);
            comboBox_check_type.DataSource = infoList;
            comboBox_check_type.ValueMember = "Id";
            comboBox_check_type.DisplayMember = "Name";
            comboBox_check_type.SelectedIndex = -1;

            IList<Info> infoList1 = new List<Info>();
            Info info1 = new Info() { Id = "1", Name = "车队一" };
            Info info2 = new Info() { Id = "2", Name = "车队二" };
            Info info3 = new Info() { Id = "3", Name = "车队三" };
            infoList1.Add(info1);
            infoList1.Add(info2);
            infoList1.Add(info3);
            comboBox_motorcade.DataSource = infoList1;
            comboBox_motorcade.ValueMember = "Id";
            comboBox_motorcade.DisplayMember = "Name";
            comboBox_motorcade.SelectedIndex = -1;

            comboBox_car_id.SelectedIndex = -1;
            comboBox_driver.SelectedIndex = -1;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_motorcade.SelectedIndex == 0)
            {
                IList<Info> infoList2 = new List<Info>();
                Info info1_1 = new Info() { Id = "1", Name = "车队一京A1234" };
                Info info1_2 = new Info() { Id = "2", Name = "车队一京B1234" };
                Info info1_3 = new Info() { Id = "3", Name = "车队一京C1234" };
                infoList2.Add(info1_1);
                infoList2.Add(info1_2);
                infoList2.Add(info1_3);
                comboBox_car_id.DataSource = infoList2;
                comboBox_car_id.ValueMember = "Id";
                comboBox_car_id.DisplayMember = "Name";


                IList<Info> infoList3 = new List<Info>();
                Info info2_1 = new Info() { Id = "1", Name = "车队一李白" };
                Info info2_2 = new Info() { Id = "2", Name = "车队一荆轲" };
                Info info2_3 = new Info() { Id = "3", Name = "车队一韩信" };
                infoList3.Add(info2_1);
                infoList3.Add(info2_2);
                infoList3.Add(info2_3);
                comboBox_driver.DataSource = infoList3;
                comboBox_driver.ValueMember = "Id";
                comboBox_driver.DisplayMember = "Name";
            }
            else if (comboBox_motorcade.SelectedIndex == 1)
            {
                IList<Info> infoList2 = new List<Info>();
                Info info1_1 = new Info() { Id = "1", Name = "车队二京A1234" };
                Info info1_2 = new Info() { Id = "2", Name = "车队二京B1234" };
                Info info1_3 = new Info() { Id = "3", Name = "车队二京C1234" };
                infoList2.Add(info1_1);
                infoList2.Add(info1_2);
                infoList2.Add(info1_3);
                comboBox_car_id.DataSource = infoList2;
                comboBox_car_id.ValueMember = "Id";
                comboBox_car_id.DisplayMember = "Name";

                IList<Info> infoList3 = new List<Info>();
                Info info2_1 = new Info() { Id = "1", Name = "车队二甄姬" };
                Info info2_2 = new Info() { Id = "2", Name = "车队二王昭君" };
                Info info2_3 = new Info() { Id = "3", Name = "车队二干将莫邪" };
                infoList3.Add(info2_1);
                infoList3.Add(info2_2);
                infoList3.Add(info2_3);
                comboBox_driver.DataSource = infoList3;
                comboBox_driver.ValueMember = "Id";
                comboBox_driver.DisplayMember = "Name";
            }
            else if (comboBox_motorcade.SelectedIndex == 2)
            {
                IList<Info> infoList2 = new List<Info>();
                Info info1_1 = new Info() { Id = "1", Name = "车队三京A1234" };
                Info info1_2 = new Info() { Id = "2", Name = "车队三京B1234" };
                Info info1_3 = new Info() { Id = "3", Name = "车队三京C1234" };
                infoList2.Add(info1_1);
                infoList2.Add(info1_2);
                infoList2.Add(info1_3);
                comboBox_car_id.DataSource = infoList2;
                comboBox_car_id.ValueMember = "Id";
                comboBox_car_id.DisplayMember = "Name";

                IList<Info> infoList3 = new List<Info>();
                Info info2_1 = new Info() { Id = "1", Name = "车队三程咬金" };
                Info info2_2 = new Info() { Id = "2", Name = "车队三亚瑟" };
                Info info2_3 = new Info() { Id = "3", Name = "车队三刘邦" };
                infoList3.Add(info2_1);
                infoList3.Add(info2_2);
                infoList3.Add(info2_3);
                comboBox_driver.DataSource = infoList3;
                comboBox_driver.ValueMember = "Id";
                comboBox_driver.DisplayMember = "Name";
            }
            else
                return;
        }
        //保存按钮单击事件
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
