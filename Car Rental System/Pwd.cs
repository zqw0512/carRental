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
    public partial class Pwd : Form
    {        
        private SqlConnection con;
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();              
        private string s = "";
        public Pwd()
        {
            b.DataSource = ".";
            b.InitialCatalog = "wkdl";
            b.IntegratedSecurity = true;
            con = new SqlConnection(b.ConnectionString);
            InitializeComponent();
            //this.skinengine1.skinfile = "macos.ssk";
        }
        public Pwd(string str)
        {
            s = str;
            InitializeComponent();
        }

        private void Pwd_Load(object sender, EventArgs e)
        {
            DLname c = DLname.getInstance();
            textBox1.Text = c.Str;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text.Trim().ToString();
            string pwd = textBox2.Text.Trim().ToString();
            if (textBox2.Text.Trim().Length==0 || textBox3.Text.Trim()!=textBox2.Text.Trim())
            {
                MessageBox.Show("Failed, password and confirm password are not equal or empty！", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DBTools db = new DBTools(".", "wkdl", true, "sa", "wdxg");
                    SqlDataReader b = db.getResult("update userlogin set uPassword='" + pwd + "'where uName='" + name + "'");
                    db.Disconnect();
                    b.Close();
                    MessageBox.Show("Change password successfully！", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose(true);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
    }
}
