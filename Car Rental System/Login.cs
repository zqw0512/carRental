using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Car_rental_system
{
    public partial class Login : Form
    {
        private SqlConnection con;
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
        Random rnd = new Random();

        public Login()
        {
            InitializeComponent();
            //this.skinengine1.skinfile = "macos.ssk";
            b.DataSource = ".";
            b.InitialCatalog = "wkdl";
            b.IntegratedSecurity = true;
            con = new SqlConnection(b.ConnectionString);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBTools db = new DBTools(".", "wkdl", true, "sa", "wdxg");
            SqlDataReader b = db.getResult("Select * from userlogin where uname='" + textBox1.Text.Trim() + "'and uPassword='" + textBox2.Text.Trim() + "'");

            try
            {
                if (b.Read())
                {
                    db.Disconnect();

                    DBTools dc = new DBTools(".", "wkdl", true, "sa", "wdxg");
                    SqlDataReader bb = db.getResult("Select * from userlogin where uname='" + textBox1.Text.Trim() + "'and usa='admin'");

                    DLname c = DLname.getInstance();
                    c.Str = textBox1.Text;

                    if (bb.Read())
                    {
                        dc.Disconnect();
                        MessageBox.Show("Hello administrator.", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm mfa = new MainForm();
                        mfa.Text = "Administrator System";
                        mfa.Show();
                    }
                    else
                    {
                        dc.Disconnect();
                        MessageBox.Show("Hello VIP member", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm mfb = new MainForm();
                        mfb.Text = "Member System";
                        mfb.Show();
                    }
                    dc.Disconnect();
                    this.Hide();
                }
                else
                {
                    db.Disconnect();
                    MessageBox.Show("Login failed! Please check your input.","Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Hello guest.", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainForm mfa = new MainForm();
            mfa.Text = "Guest System";
            mfa.Show();
            this.Hide();
        }
    }
}