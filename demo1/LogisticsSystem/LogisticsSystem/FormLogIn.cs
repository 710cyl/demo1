using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using WebSocketSharp;
using System.Threading;
using WebSocketSharp.Server;
using System.Net;
using System.Net.Sockets;

namespace LogisticsSystem
{
    public partial class FormLogIn : Form
    {
        
        public FormLogIn()
        {
            InitializeComponent();
        }

    

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x4e:
                case 0xd:
                case 0xe:
                case 0x14:
                    base.WndProc(ref m);
                    break;
                case 0x84://鼠标点任意位置后可以拖动窗体
                    this.DefWndProc(ref m);
                    if (m.Result.ToInt32() == 0x01)
                    {
                        m.Result = new IntPtr(0x02);
                    }
                    break;
                case 0xA3://禁止双击最大化
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private extern static IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        //窗体关闭消息
        private const uint WM_CLOSE = 0x0010;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SendMessage(this.Handle, WM_CLOSE, 0, 0);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "/最小化按钮悬停.jpg");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "/最小化按钮1.1.png");

        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox3.BackgroundImage = Image.FromFile(Application.StartupPath + "/关闭按钮悬停.jpg");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.BackgroundImage = Image.FromFile(Application.StartupPath + "/关闭按钮1.1.png");
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox4.Image = Image.FromFile(Application.StartupPath + "/登录按钮悬停1.1.png");

        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.Image = Image.FromFile(Application.StartupPath + "/登录按钮1.1.png");
        }
        private void logInServer()
        {
           
        }
    
        private void pictureBox4_Click(object sender1, EventArgs e1)
        {
            if (textBoxId.Text == "")
            {
                MessageBox.Show("用户名不能为空");
                return;

            }
            if (textBoxPswd.Text == "")
            {
                MessageBox.Show("密码不能为空");
                return;

            }

            string messageToServer = "select authorities from test.customer where idcustomers='"
                    + this.textBoxId.Text + "'and passwrdcustomsers='" + this.textBoxPswd.Text + "'";

            

            using (var ws = new WebSocket("ws://localhost:9000/LogIn"))
            {
                ws.Connect();
                ws.Send(messageToServer);
                string message = "";
                ws.OnMessage += (sender, e) =>
                         message = e.Data;
                Thread.Sleep(500);
                        if (message.Equals("true"))
                        {
                            MessageBox.Show("欢迎来到XX物流管理");
                            this.Hide();

                            FormMain formMain = new FormMain();
                            formMain.Show();
                        }
                        else
                        {
                            MessageBox.Show("用户名、密码、登录类型不匹配，请重试！", "【提示】");
                        }
            }
        }
    }
    
}
