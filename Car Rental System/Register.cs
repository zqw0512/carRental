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
    public partial class Insertname : Form
    {
        private SqlDataAdapter da;
        private SqlConnection con;
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
        public Insertname()
        {
            InitializeComponent();
            b.DataSource = ".";
            b.InitialCatalog = "wkdl";
            b.IntegratedSecurity = true;
            con = new SqlConnection(b.ConnectionString);
            //this.skinengine1.skinfile = "macos.ssk";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text.Trim();
            string pwd = textBox2.Text.Trim();
            string cpwd = textBox3.Text.Trim();
            string fullName = textBox4.Text.Trim();
            string address = textBox5.Text.Trim();
            string phone = textBox6.Text.Trim();

            try
            {
                if (name.Length == 0 || pwd != cpwd)
                {
                    MessageBox.Show("The information is incomplete！", "System");
                }
                else
                {
                        da = new SqlDataAdapter();
                        string str = "insert into userlogin (uname ,uPassword ,usa, uFullName, uAddress, uPhone, uReservation) values('" + name + "','" + pwd + "','member','" + fullName + "','" + address + "','" + phone +"','none')";
                    MessageBox.Show(str);
                        da.InsertCommand = con.CreateCommand();
                        da.InsertCommand.CommandText = str;
                        con.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Sign up Successfully","System");
                        this.Dispose(true);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry！"+"\n\n"+"The user already exists");
                this.Dispose(true);
            }
        }

       
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != textBox2.Text.Trim())
            {
                errorProvider1.BlinkRate = 1000;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                errorProvider1.SetError(this.textBox3, "Two passwords are inconsistent！");
            }
            else
            {
                errorProvider1.SetError((Control)sender, null);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
