﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Web;
using System.Windows.Forms;

namespace Demo1._1._3
{
    public partial class Basic_Set : UserControl
    {
        public Basic_Set()
        {
            InitializeComponent();

            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
            sqlDataSource2.Fill();
            //dataShow("基本系统");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

       void dataShow(string str)
        {


            string constr = "server=127.0.0.1;User Id=root;password=root;Database=test";
            MySqlConnection mycon = new MySqlConnection(constr);
            MySqlCommand sqlcmd = new MySqlCommand();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from "+str,mycon);
                       
            DataSet ds = new DataSet();
            sda.Fill(ds);
            this.gridControl1.DataSource = ds.Tables[0]; 
        }
  

       
    }
}
