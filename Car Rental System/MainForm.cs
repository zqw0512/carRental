using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Car_rental_system
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ////this.skinengine1.skinfile = "macos.ssk";
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login lg = new Login();
            lg.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pwd p = new Pwd();          
            p.ShowDialog();
        }

        private void 商品管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Select sel = new Select();
            
            if (this.Text == "Guest System")
            {
                sel.Text = "Guest System";
                sel.ShowDialog();
            }
            else if (this.Text == "Member System")
            {
                sel.Text = "Member System";
                sel.ShowDialog();
            } else
            {
                sel.Text = "Adminstrator System";
                sel.ShowDialog();
            }
        }
       

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.Text == "Guest System")
            {
                changePasswordToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;
            }
            else if (this.Text == "Member System")
            {
                usersToolStripMenuItem.Enabled = false;
                signUpToolStripMenuItem.Enabled = false;
            }
            //timer1.Enabled = true;
            //label1.ForeColor = Color.Red;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            //label1.Text = dt.ToLocalTime().ToString();
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 关于WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Text == "Guest System")
            {
                MessageBox.Show("Sorry. Please sign up first.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                Sell sel = new Sell();
                sel.ShowDialog();
            }
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.ShowDialog();
        }

        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insertname insa = new Insertname();
            insa.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ryan's representation");
        }

        private void 人事管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}